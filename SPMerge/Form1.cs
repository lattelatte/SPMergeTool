﻿using SPMerge.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
            DataTable dt = DBHelper.QuerySql("select DbDatabase,Name from ServiceProvider where deploystatus=1");

            lblSPCount.Text = "发现SP数量：" + dt.Rows.Count.ToString();
            Dictionary<string, int> dic = new Dictionary<string, int>();
            int start = 100000;

            foreach (DataRow dr in dt.Rows)
            {
                lsvSPList.Items.Add(new ListViewItem(dr["Name"].ToString()));
                dic.Add(dr["DbDatabase"].ToString(), start);
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

            this.chbStep4.Checked = true;

        }

        private void btnGenerateSQLFile_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> dic = DBHelper.DBMapper;

            foreach (KeyValuePair<string, int> p in dic)
            {
                DBHelper.DBName = p.Key;

                GenerateSQLFile(p.Value);
            }
        }

        private void GenerateSQLFile(int delta)
        {

        }

        private void btnAddSPColumn_Click(object sender, EventArgs e)
        {

        }





    }
}
