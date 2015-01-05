namespace SPMerge
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnChangeConnectionString = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSPCount = new System.Windows.Forms.Label();
            this.btnSearchSPCount = new System.Windows.Forms.Button();
            this.btnCreateDB = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chbStep1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.btnDropDB = new System.Windows.Forms.Button();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.button9 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lsvSPList = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblConnectionStatus);
            this.groupBox1.Controls.Add(this.txtDBName);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnChangeConnectionString);
            this.groupBox1.Location = new System.Drawing.Point(64, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(962, 121);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MetadataDB";
            // 
            // btnChangeConnectionString
            // 
            this.btnChangeConnectionString.Location = new System.Drawing.Point(747, 33);
            this.btnChangeConnectionString.Name = "btnChangeConnectionString";
            this.btnChangeConnectionString.Size = new System.Drawing.Size(97, 34);
            this.btnChangeConnectionString.TabIndex = 0;
            this.btnChangeConnectionString.Text = "更改连接";
            this.btnChangeConnectionString.UseVisualStyleBackColor = true;
            this.btnChangeConnectionString.Click += new System.EventHandler(this.btnChangeConnectionString_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(414, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "密码";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(149, 78);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(159, 22);
            this.txtUserName.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(472, 78);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(167, 22);
            this.txtPassword.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lsvSPList);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.button9);
            this.groupBox2.Controls.Add(this.checkBox6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.button8);
            this.groupBox2.Controls.Add(this.checkBox5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.checkBox4);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.checkBox3);
            this.groupBox2.Controls.Add(this.btnDropDB);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.chbStep1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.btnCreateDB);
            this.groupBox2.Controls.Add(this.btnSearchSPCount);
            this.groupBox2.Controls.Add(this.lblSPCount);
            this.groupBox2.Location = new System.Drawing.Point(64, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(962, 447);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作流程";
            // 
            // lblSPCount
            // 
            this.lblSPCount.AutoSize = true;
            this.lblSPCount.Location = new System.Drawing.Point(577, 59);
            this.lblSPCount.Name = "lblSPCount";
            this.lblSPCount.Size = new System.Drawing.Size(82, 17);
            this.lblSPCount.TabIndex = 0;
            this.lblSPCount.Text = "发现SP数量";
            // 
            // btnSearchSPCount
            // 
            this.btnSearchSPCount.Location = new System.Drawing.Point(244, 47);
            this.btnSearchSPCount.Name = "btnSearchSPCount";
            this.btnSearchSPCount.Size = new System.Drawing.Size(278, 35);
            this.btnSearchSPCount.TabIndex = 1;
            this.btnSearchSPCount.Text = "开始探测";
            this.btnSearchSPCount.UseVisualStyleBackColor = true;
            this.btnSearchSPCount.Click += new System.EventHandler(this.btnSearchSPCount_Click);
            // 
            // btnCreateDB
            // 
            this.btnCreateDB.Location = new System.Drawing.Point(582, 109);
            this.btnCreateDB.Name = "btnCreateDB";
            this.btnCreateDB.Size = new System.Drawing.Size(109, 35);
            this.btnCreateDB.TabIndex = 2;
            this.btnCreateDB.Text = "创建";
            this.btnCreateDB.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(317, 118);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(205, 22);
            this.textBox3.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(241, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "库名";
            // 
            // chbStep1
            // 
            this.chbStep1.AutoSize = true;
            this.chbStep1.Enabled = false;
            this.chbStep1.Location = new System.Drawing.Point(30, 55);
            this.chbStep1.Name = "chbStep1";
            this.chbStep1.Size = new System.Drawing.Size(120, 21);
            this.chbStep1.TabIndex = 6;
            this.chbStep1.Text = "1. 探测SP数量";
            this.chbStep1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(30, 117);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(98, 21);
            this.checkBox2.TabIndex = 7;
            this.checkBox2.Text = "2.创建新库";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // btnDropDB
            // 
            this.btnDropDB.Location = new System.Drawing.Point(725, 109);
            this.btnDropDB.Name = "btnDropDB";
            this.btnDropDB.Size = new System.Drawing.Size(109, 35);
            this.btnDropDB.TabIndex = 8;
            this.btnDropDB.Text = "销毁";
            this.btnDropDB.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Enabled = false;
            this.checkBox3.Location = new System.Drawing.Point(30, 239);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(172, 21);
            this.checkBox3.TabIndex = 9;
            this.checkBox3.Text = "4.根据SP生产SQL文件";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(244, 231);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(278, 35);
            this.button5.TabIndex = 10;
            this.button5.Text = "开始生成";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Enabled = false;
            this.checkBox4.Location = new System.Drawing.Point(30, 315);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(140, 21);
            this.checkBox4.TabIndex = 11;
            this.checkBox4.Text = "5.向新库导入数据";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(244, 307);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(278, 35);
            this.button6.TabIndex = 12;
            this.button6.Text = "开始导入";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(578, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "SPDBName";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(579, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "TableName";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(244, 160);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(278, 35);
            this.button8.TabIndex = 16;
            this.button8.Text = "去除";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Enabled = false;
            this.checkBox5.Location = new System.Drawing.Point(30, 168);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(140, 21);
            this.checkBox5.TabIndex = 15;
            this.checkBox5.Text = "3.去除数据库约束";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(579, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "已去除表数目";
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Enabled = false;
            this.checkBox6.Location = new System.Drawing.Point(30, 398);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(140, 21);
            this.checkBox6.TabIndex = 18;
            this.checkBox6.Text = "6.恢复数据库限制";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(244, 390);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(278, 35);
            this.button9.TabIndex = 19;
            this.button9.Text = "恢复";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(579, 402);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 17);
            this.label8.TabIndex = 20;
            this.label8.Text = "已恢复表数目";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(347, 279);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 17);
            this.label9.TabIndex = 21;
            this.label9.Text = "总生成表数量";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(578, 338);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 17);
            this.label10.TabIndex = 23;
            this.label10.Text = "TableName";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(578, 303);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 17);
            this.label11.TabIndex = 22;
            this.label11.Text = "SPDBName";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(347, 357);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 17);
            this.label12.TabIndex = 24;
            this.label12.Text = "总导入表数量";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(27, 38);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(114, 17);
            this.label13.TabIndex = 6;
            this.label13.Text = "MetadataDB名称";
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(149, 33);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(490, 22);
            this.txtDBName.TabIndex = 7;
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.AutoEllipsis = true;
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.Location = new System.Drawing.Point(659, 81);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(64, 17);
            this.lblConnectionStatus.TabIndex = 8;
            this.lblConnectionStatus.Text = "连接状态";
            // 
            // lsvSPList
            // 
            this.lsvSPList.Location = new System.Drawing.Point(725, 35);
            this.lsvSPList.Name = "lsvSPList";
            this.lsvSPList.Size = new System.Drawing.Size(178, 56);
            this.lsvSPList.TabIndex = 25;
            this.lsvSPList.UseCompatibleStateImageBehavior = false;
            this.lsvSPList.View = System.Windows.Forms.View.Tile;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 676);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChangeConnectionString;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chbStep1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button btnCreateDB;
        private System.Windows.Forms.Button btnSearchSPCount;
        private System.Windows.Forms.Label lblSPCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Button btnDropDB;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDBName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblConnectionStatus;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ListView lsvSPList;
    }
}

