﻿using Aliyun.OpenServices;
using Aliyun.OpenServices.OpenStorageService;
using SPMerge.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPMerge
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connStr = DBHelper.GetConnString();

            Regex reg = new Regex("Database\\s*=\\s*([^;]*);\\s*User\\sId\\s*=\\s*([^;]*);\\s*Password\\s*=\\s*([^;]*)");

            Match match = reg.Match(connStr);

            if (match.Groups.Count != 4)
            {
                MessageBox.Show("数据库配置格式出错");
                txtDBName.Text = "";
                txtUserName.Text = "";
                txtPassword.Text = "";
            }
            else
            {
                txtDBName.Text = match.Groups[1].Value;
                txtUserName.Text = match.Groups[2].Value;
                txtPassword.Text = match.Groups[3].Value;
            }

            RefreshDBConnectionStatus();
        }

        private void RefreshDBConnectionStatus()
        {

            string connStr = DBHelper.GetConnString();

            Regex reg = new Regex("Database\\s*=\\s*([^;]*);");

            Match match = reg.Match(connStr);



            if (DBHelper.Test() == false)
            {
                lblConnectionStatus.Text = "无法连接当前数据库";
            }
            else
            {
                lblConnectionStatus.Text = string.Format("数据库连接成功:{0}", match.Groups[1].Value);
                toolTip1.SetToolTip(lblConnectionStatus, lblConnectionStatus.Text);
            }
        }

        private void btnChangeConnectionString_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDBName.Text) ||
                string.IsNullOrWhiteSpace(txtUserName.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("数据库名或用户名或密码为空");

                return;
            }

            string str = "Server=.;Database={0};User Id={1};Password={2};";
            str = string.Format(str, txtDBName.Text, txtUserName.Text, txtPassword.Text);
            DBHelper.SaveConnString(str);
            this.RefreshDBConnectionStatus();

        }

        private void btnSearchSPCount_Click(object sender, EventArgs e)
        {
            DataTable dt = DBHelper.QuerySql("select Id,DbDatabase,Name from ServiceProvider where deploystatus=1");

            lblSPCount.Text = "发现SP数量：" + dt.Rows.Count.ToString();
            Dictionary<string, int[]> dic = new Dictionary<string, int[]>();
            int start = 100000;

            foreach (DataRow dr in dt.Rows)
            {
                lsvSPList.Items.Add(new ListViewItem(dr["Name"].ToString()));
                dic.Add(dr["DbDatabase"].ToString(), new int[] { start, int.Parse(dr["Id"].ToString()) });
                start += 100000;
            }
            DBHelper.DBMapper = dic;




            chbStep1.Checked = true;
        }

        private bool CheckOrder(int step)
        {

            foreach (Control ctl in this.grbProcess.Controls)
            {
                if (ctl is CheckBox)
                {
                    if (ctl.Name.CompareTo("chkStep" + step) > 0)
                    {
                        if (((CheckBox)ctl).Checked == false)
                        {
                            MessageBox.Show("请检查执行顺序");
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void btnCreateDB_Click(object sender, EventArgs e)
        {
            if (!this.CheckOrder(2))
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(this.txtNewDBName.Text))
            {
                MessageBox.Show("新库名不能为空");
                return;
            }

            try
            {
                this.prgbar.ProgressBar.Maximum = 100;
                this.prgbar.Step = 10;
                this.prgbar.PerformStep();
                DBHelper.ExecuteSqlFile("./createdb.sql", "", this.txtNewDBName.Text);
                this.prgbar.PerformStep();

                FileInfo[] fileInfos = new DirectoryInfo("./Deploy/Information/").GetFiles();
                foreach (var item in fileInfos)
                {
                    this.lblCreateNewDBStatus.Text = "正在创建:" + item.Name;
                    DBHelper.ExecuteSqlFile(item.FullName, string.Format("use [{0}]", this.txtNewDBName.Text));
                    this.prgbar.PerformStep();

                }


                this.lblCreateNewDBStatus.Text = "数据库创建成功";

                this.prgbar.Value = 0;


                this.chbStep2.Checked = true;

                this.txtNewDBName.Enabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }




        }

        private void btnDropDB_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtNewDBName.Text))
            {
                MessageBox.Show("新库名不能为空");
                return;
            }
            try
            {
                DBHelper.ExecuteSql(string.Format("drop database [{0}]", this.txtNewDBName.Text));
                this.lblCreateNewDBStatus.Text = "删除成功";
                this.txtNewDBName.Enabled = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }


        }

        private void btnRemoveConstraint_Click(object sender, EventArgs e)
        {
            string restoreConstraint = string.Format(@"use [{0}]; SELECT  'ALTER TABLE ' + PT + ' WITH CHECK CHECK CONSTRAINT ' + FK + ';'
FROM 
(SELECT 
    OBJECT_NAME(constraint_object_id) as FK,
    OBJECT_NAME(parent_object_id) as PT
    FROM [sys].[foreign_key_columns] ) T
ORDER BY FK", this.txtNewDBName.Text);

            DataTable dt = DBHelper.QuerySql(restoreConstraint);

            StringBuilder sb = new StringBuilder();

            foreach (DataRow dr in dt.Rows)
            {
                sb.AppendLine(dr[0].ToString());
            }


            string path = "./fk_idx.sql";
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            File.WriteAllText(path, sb.ToString());

            string sql = string.Format(@"use [{0}]; SELECT  'IF EXISTS (SELECT * FROM sys.foreign_keys 
   WHERE object_id = OBJECT_ID(N''[dbo].' + FK +''') 
   AND parent_object_id = OBJECT_ID(N''[dbo].' + PT + ''')) 
   ALTER TABLE ' + PT + ' NOCHECK CONSTRAINT ' + FK + ';'
FROM 
(SELECT 
    OBJECT_NAME(constraint_object_id) as FK,
    OBJECT_NAME(parent_object_id) as PT
    FROM [sys].[foreign_key_columns] ) T
ORDER BY FK", this.txtNewDBName.Text);

            dt = DBHelper.QuerySql(sql);


            foreach (DataRow dr in dt.Rows)
            {
                string s = dr[0].ToString();

                DBHelper.ExecuteSql(string.Format("use [{0}]\r\n", this.txtNewDBName.Text) + s);
            }

            this.lblRemoveConstraintCount.Text = "已去除表数目:" + dt.Rows.Count;

            this.chbStep3.Checked = true;

        }

        private void btnGenerateSQLFile_Click(object sender, EventArgs e)
        {
            Dictionary<string, int[]> dic = DBHelper.DBMapper;

            if (Directory.Exists("./CreateFile/"))
            {
                try
                {
                    Directory.Delete("./CreateFile", true);

                }
                catch (Exception exc)
                {

                }
            }
            Directory.CreateDirectory("./CreateFile/");
            Directory.CreateDirectory("./CreateFile/Meta/");

            GenerateMetadataSQL();
            foreach (KeyValuePair<string, int[]> p in dic)
            {
                DBHelper.DBName = p.Key;

                CleanDB();

                Directory.CreateDirectory("./CreateFile/" + p.Key + "/");

                GenerateSQLFile(p.Value);
            }

            this.chbStep4.Checked = true;
        }

        private void CleanDB()
        {
            string sql = @"delete Widget where DashboardId in (select Id from Dashboard where UserId not in (select Id from [User]))
delete Dashboard where UserId  not in (select Id from [User])";
            DBHelper.ExecuteSql(sql);
        }

        private void GenerateSQLFile(int[] delta)
        {
            List<UpgradeObject> list = new UpgradeObjects().List;
            CommonProcessor processor = new CommonProcessor();
            foreach (UpgradeObject item in list)
            {
                processor.UpgradeColumnsName = item.UpdateColumns;
                processor.TableName = item.TableName;
                processor.SpName = DBHelper.DBName;
                processor.Delta = delta[0];
                processor.SpId = delta[1];
                processor.GenerateSQL();
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            DirectoryInfo[] dirs = new DirectoryInfo("./CreateFile/").GetDirectories();

            DBHelper.DBName = this.txtNewDBName.Text;

            foreach (DirectoryInfo item in dirs)
            {
                FileInfo[] files = item.GetFiles();
                foreach (FileInfo file in files)
                {
                    DBHelper.ExecuteSqlFile(file.FullName, "");
                }
            }

            this.chbStep5.Checked = true;

        }


        private void btnRestore_Click(object sender, EventArgs e)
        {
            DBHelper.DBName = this.txtNewDBName.Text;
            DBHelper.ExecuteSqlFile("./fk_idx.sql", "");

            string removeFK = "ALTER TABLE UserRole DROP CONSTRAINT FK_UserRole_Role";
            DBHelper.ExecuteSql(removeFK);

            string insert = "insert into UserRole(UserId,RoleId) values(1,-1)";
            DBHelper.ExecuteSql(insert);

            this.chbStep6.Checked = true;

        }

        private void btnOthers_Click(object sender, EventArgs e)
        {
            DBHelper.DBName = this.txtNewDBName.Text;
            UpdateHierarchy();


            MessageBox.Show("恭喜你，千辛万苦完成了升级！！");

            this.Close();
        }


        private void UpdateHierarchy()
        {
            DataTable dt = DBHelper.QuerySql("select * from Hierarchy order by pathlevel,updatetime");

            foreach (DataRow dr in dt.Rows)
            {
                var sql = new StringBuilder("DECLARE @parent hierarchyid, @left hierarchyid, @path hierarchyid, @pathlevel int;");
                if (dr["ParentId"] is DBNull)
                {
                    sql.Append(@"SET @parent = hierarchyid::GetRoot();");
                    sql.Append(@"SET @left= (SELECT TOP 1 Path from Hierarchy WHERE TYPE=-1 ORDER BY Id DESC);");
                    sql.Append("if(@left = 0x) set @left = null; ");
                }
                else
                {
                    sql.Append(@"SET @parent =(SELECT Path from Hierarchy WHERE Id=" + dr["ParentId"].ToString() + ");");
                    sql.Append(@"SET @left= (SELECT TOP 1 Path from Hierarchy WHERE ParentId=" + dr["ParentId"].ToString() + " ORDER BY Id DESC);");
                    sql.Append("if(@left = 0x) set @left = null; ");
                }
                sql.Append(@"
SET @path = @parent.GetDescendant(@left,NULL);
SET @pathlevel = @path.GetLevel();
UPDATE Hierarchy SET Path=@path, PathLevel=@pathlevel where ID=" + dr["Id"].ToString());
                DBHelper.ExecuteSql(sql.ToString());
            }
        }

        private void GenerateMetadataSQL()
        {
            DBHelper.DBName = null;

            CommonProcessor cp = new CommonProcessor();

            cp.SpId = -1;
            cp.TableName = "User";
            cp.SpName = "Meta";
            cp.UpgradeColumnsName = new string[] { };
            cp.Delta = 0;
            cp.GenerateSQL();

            cp.TableName = "AppKeySecret";
            cp.GenerateSQL();

            string s = @"select 1 from sys.objects where object_id = OBJECT_ID('RecordCount')";

            DataTable dt = DBHelper.QuerySql(s);

            if (dt.Rows.Count == 1)
            {

                cp.TableName = "RecordCount";
                cp.UpgradeColumnsName = new string[] { "CustomerId" };
                cp.IncludingSp = true;
                cp.GenerateSQL();
            }




            cp.TableName = "ServiceProvider";
            cp.IncludingSp = false;
            cp.UpgradeColumnsName = new string[] { };
            cp.SelectColumnsName = new string[] { "Id", "UserName", "Name", "Address", "Telephone", "Email", "StartDate", "Status", "Comment", "DeployStatus", "UpdateTime", "UpdateUser" };
            Dictionary<string, string> columnValue = new Dictionary<string, string>();
            columnValue.Add("1", "Domain,N'SEChina'");
            columnValue.Add("3", "Domain,N'sp_demo'");
            columnValue.Add("4", "Domain,N'controlsys'");
            columnValue.Add("5", "Domain,N'excellent'");
            columnValue.Add("6", "Domain,N'colorlife'");
            columnValue.Add("7", "Domain,N'gcdw'");
            columnValue.Add("8", "Domain,N'watersupply'");
            cp.ColumnValue = columnValue;
            cp.GenerateSQL();

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            UploadImageToOSS();
            this.chbStep7.Checked = true;
        }


        private void UploadImageToOSS()
        {
            string accId = this.txtAccessId.Text;
            string accKey = this.txtAccessKey.Text;
            string proxy = this.txtProxy.Text;
            string proxyHost = "";
            string proxyPort = "";
            ClientConfiguration config = null;
            if (!string.IsNullOrWhiteSpace(proxy))
            {
                string[] m = proxy.Split(':');
                proxyHost = m[0];
                proxyPort = m[1];
                config = new ClientConfiguration
                {
                    ProxyHost = proxyHost,
                    ProxyPort = int.Parse(proxyPort)
                };
            }

            OssClient client = new OssClient(new Uri("http://oss-cn-hangzhou.aliyuncs.com"), accId, accKey, config);

            foreach (KeyValuePair<string, int[]> p in DBHelper.DBMapper)
            {
                DBHelper.DBName = p.Key;

                ExportBuildingCover(client, p.Value[0]);

            }
        }

        private void ExportBuildingCover(OssClient client, int delta)
        {
            //OssObject obj = client.GetObject("sejazz", "cover-100001");

            var sql = "select id, buildingId, Picture from BuildingPicture";

            DataTable dt = DBHelper.QuerySql(sql);

            this.prgbar.Step = 1;
            this.prgbar.Value = 0;
            this.prgbar.Maximum = dt.Rows.Count;
            foreach (DataRow dr in dt.Rows)
            {
                byte[] ss = (byte[])dr["Picture"];
                using (MemoryStream oStream = new MemoryStream(ss))
                {
                    using (var oimg = Image.FromStream(oStream))
                    {
                        string type = "";
                        if (oimg.RawFormat.Guid == ImageFormat.Jpeg.Guid)
                        {
                            type = "image/jpg";
                        }
                        else if (oimg.RawFormat == ImageFormat.Png)
                        {
                            type = "image/png";
                        }
                        else
                        {
                            type = "image/gif";
                        }
                        long id = long.Parse(dr["Id"].ToString()) + delta;
                        //File.WriteAllBytes("test.jpg", oStream.ToArray());
                        oStream.Position = 0;

                        PutObjectResult ret = client.PutObject("sejazz", "cover-" + id.ToString(), oStream, new ObjectMetadata { ContentType = type });
                    }

                    this.prgbar.PerformStep();
                }

            }
        }

        private void btnTestProxy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtProxy.Text))
            {
                MessageBox.Show("Proxy is empty");
                return;
            }
            string proxy = this.txtProxy.Text;
            string[] mm = proxy.Split(':');
            if (mm.Length != 2)
            {
                MessageBox.Show("Proxy is wrong");
                return;
            }
            string proxyHost = mm[0];
            string proxyPort = mm[1];
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create("http://www.baidu.com");
            httpRequest.Timeout = 2000;
            httpRequest.Method = "GET";
            httpRequest.Proxy = new WebProxy(proxyHost, int.Parse(proxyPort));
            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            if (httpResponse.StatusCode != HttpStatusCode.OK)
            {
                MessageBox.Show("Proxy is not blocked");
            }
            else
            {
                MessageBox.Show("Proxy is good");
            }


        }






    }
}
