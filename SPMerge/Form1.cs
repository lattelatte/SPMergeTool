using SPMerge.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            foreach (DataRow dr in dt.Rows)
            {
                lsvSPList.Items.Add(new ListViewItem(dr["Name"].ToString()));
            }

            chbStep1.Checked = true;
        }

        private bool CheckOrder(int step)
        {

            foreach (Control ctl in this.grbProcess.Controls)
            {
                if (ctl is CheckBox)
                {
                    if (ctl.Name.CompareTo("chkStep" + step) < 0)
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




        }





    }
}
