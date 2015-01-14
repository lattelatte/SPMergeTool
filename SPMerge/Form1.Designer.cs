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
            this.btnTestProxy = new System.Windows.Forms.Button();
            this.txtProxy = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAccessKey = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAccessId = new System.Windows.Forms.TextBox();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChangeConnectionString = new System.Windows.Forms.Button();
            this.grbProcess = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.chbStep7 = new System.Windows.Forms.CheckBox();
            this.btnOthers = new System.Windows.Forms.Button();
            this.chbStep8 = new System.Windows.Forms.CheckBox();
            this.chbStep3 = new System.Windows.Forms.CheckBox();
            this.lblCreateNewDBStatus = new System.Windows.Forms.Label();
            this.lsvSPList = new System.Windows.Forms.ListView();
            this.label12 = new System.Windows.Forms.Label();
            this.lblGenerateTotal = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnRestore = new System.Windows.Forms.Button();
            this.chbStep6 = new System.Windows.Forms.CheckBox();
            this.lblRemoveConstraintCount = new System.Windows.Forms.Label();
            this.btnRemoveConstraint = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.chbStep5 = new System.Windows.Forms.CheckBox();
            this.btnGenerateSQLFile = new System.Windows.Forms.Button();
            this.chbStep4 = new System.Windows.Forms.CheckBox();
            this.btnDropDB = new System.Windows.Forms.Button();
            this.chbStep2 = new System.Windows.Forms.CheckBox();
            this.chbStep1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNewDBName = new System.Windows.Forms.TextBox();
            this.btnCreateDB = new System.Windows.Forms.Button();
            this.btnSearchSPCount = new System.Windows.Forms.Button();
            this.lblSPCount = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.prgbar = new System.Windows.Forms.ToolStripProgressBar();
            this.groupBox1.SuspendLayout();
            this.grbProcess.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTestProxy);
            this.groupBox1.Controls.Add(this.txtProxy);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtAccessKey);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtAccessId);
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
            this.groupBox1.Size = new System.Drawing.Size(962, 177);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MetadataDB";
            // 
            // btnTestProxy
            // 
            this.btnTestProxy.Location = new System.Drawing.Point(847, 114);
            this.btnTestProxy.Name = "btnTestProxy";
            this.btnTestProxy.Size = new System.Drawing.Size(96, 36);
            this.btnTestProxy.TabIndex = 15;
            this.btnTestProxy.Text = "测试代理";
            this.btnTestProxy.UseVisualStyleBackColor = true;
            this.btnTestProxy.Click += new System.EventHandler(this.btnTestProxy_Click);
            // 
            // txtProxy
            // 
            this.txtProxy.Location = new System.Drawing.Point(662, 121);
            this.txtProxy.Name = "txtProxy";
            this.txtProxy.Size = new System.Drawing.Size(162, 22);
            this.txtProxy.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(550, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "代理（IP:Port）";
            // 
            // txtAccessKey
            // 
            this.txtAccessKey.Location = new System.Drawing.Point(350, 121);
            this.txtAccessKey.Name = "txtAccessKey";
            this.txtAccessKey.Size = new System.Drawing.Size(155, 22);
            this.txtAccessKey.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(264, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "OSS的Key";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "OSS的Id";
            // 
            // txtAccessId
            // 
            this.txtAccessId.Location = new System.Drawing.Point(106, 121);
            this.txtAccessId.Name = "txtAccessId";
            this.txtAccessId.Size = new System.Drawing.Size(143, 22);
            this.txtAccessId.TabIndex = 9;
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
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(149, 33);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(490, 22);
            this.txtDBName.TabIndex = 7;
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
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(472, 78);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(167, 22);
            this.txtPassword.TabIndex = 4;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(149, 78);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(159, 22);
            this.txtUserName.TabIndex = 3;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户名";
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
            // grbProcess
            // 
            this.grbProcess.Controls.Add(this.btnExport);
            this.grbProcess.Controls.Add(this.chbStep7);
            this.grbProcess.Controls.Add(this.btnOthers);
            this.grbProcess.Controls.Add(this.chbStep8);
            this.grbProcess.Controls.Add(this.chbStep3);
            this.grbProcess.Controls.Add(this.lblCreateNewDBStatus);
            this.grbProcess.Controls.Add(this.lsvSPList);
            this.grbProcess.Controls.Add(this.label12);
            this.grbProcess.Controls.Add(this.lblGenerateTotal);
            this.grbProcess.Controls.Add(this.label8);
            this.grbProcess.Controls.Add(this.btnRestore);
            this.grbProcess.Controls.Add(this.chbStep6);
            this.grbProcess.Controls.Add(this.lblRemoveConstraintCount);
            this.grbProcess.Controls.Add(this.btnRemoveConstraint);
            this.grbProcess.Controls.Add(this.btnImport);
            this.grbProcess.Controls.Add(this.chbStep5);
            this.grbProcess.Controls.Add(this.btnGenerateSQLFile);
            this.grbProcess.Controls.Add(this.chbStep4);
            this.grbProcess.Controls.Add(this.btnDropDB);
            this.grbProcess.Controls.Add(this.chbStep2);
            this.grbProcess.Controls.Add(this.chbStep1);
            this.grbProcess.Controls.Add(this.label4);
            this.grbProcess.Controls.Add(this.txtNewDBName);
            this.grbProcess.Controls.Add(this.btnCreateDB);
            this.grbProcess.Controls.Add(this.btnSearchSPCount);
            this.grbProcess.Controls.Add(this.lblSPCount);
            this.grbProcess.Location = new System.Drawing.Point(64, 228);
            this.grbProcess.Name = "grbProcess";
            this.grbProcess.Size = new System.Drawing.Size(962, 501);
            this.grbProcess.TabIndex = 1;
            this.grbProcess.TabStop = false;
            this.grbProcess.Text = "操作流程";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(244, 384);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(278, 35);
            this.btnExport.TabIndex = 31;
            this.btnExport.Text = "导出静态数据";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // chbStep7
            // 
            this.chbStep7.AutoSize = true;
            this.chbStep7.Enabled = false;
            this.chbStep7.Location = new System.Drawing.Point(30, 392);
            this.chbStep7.Name = "chbStep7";
            this.chbStep7.Size = new System.Drawing.Size(126, 21);
            this.chbStep7.TabIndex = 30;
            this.chbStep7.Text = "7.导出静态数据";
            this.chbStep7.UseVisualStyleBackColor = true;
            // 
            // btnOthers
            // 
            this.btnOthers.Location = new System.Drawing.Point(244, 435);
            this.btnOthers.Name = "btnOthers";
            this.btnOthers.Size = new System.Drawing.Size(278, 35);
            this.btnOthers.TabIndex = 29;
            this.btnOthers.Text = "最后一公里！！";
            this.btnOthers.UseVisualStyleBackColor = true;
            this.btnOthers.Click += new System.EventHandler(this.btnOthers_Click);
            // 
            // chbStep8
            // 
            this.chbStep8.AutoSize = true;
            this.chbStep8.Enabled = false;
            this.chbStep8.Location = new System.Drawing.Point(30, 443);
            this.chbStep8.Name = "chbStep8";
            this.chbStep8.Size = new System.Drawing.Size(98, 21);
            this.chbStep8.TabIndex = 28;
            this.chbStep8.Text = "8.其他操作";
            this.chbStep8.UseVisualStyleBackColor = true;
            // 
            // chbStep3
            // 
            this.chbStep3.AutoSize = true;
            this.chbStep3.Enabled = false;
            this.chbStep3.Location = new System.Drawing.Point(30, 165);
            this.chbStep3.Name = "chbStep3";
            this.chbStep3.Size = new System.Drawing.Size(140, 21);
            this.chbStep3.TabIndex = 27;
            this.chbStep3.Text = "3.去除数据库约束";
            this.chbStep3.UseVisualStyleBackColor = true;
            // 
            // lblCreateNewDBStatus
            // 
            this.lblCreateNewDBStatus.AutoSize = true;
            this.lblCreateNewDBStatus.Location = new System.Drawing.Point(830, 123);
            this.lblCreateNewDBStatus.Name = "lblCreateNewDBStatus";
            this.lblCreateNewDBStatus.Size = new System.Drawing.Size(36, 17);
            this.lblCreateNewDBStatus.TabIndex = 26;
            this.lblCreateNewDBStatus.Text = "状态";
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
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(577, 286);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 17);
            this.label12.TabIndex = 24;
            this.label12.Text = "总导入表数量";
            // 
            // lblGenerateTotal
            // 
            this.lblGenerateTotal.AutoSize = true;
            this.lblGenerateTotal.Location = new System.Drawing.Point(577, 229);
            this.lblGenerateTotal.Name = "lblGenerateTotal";
            this.lblGenerateTotal.Size = new System.Drawing.Size(92, 17);
            this.lblGenerateTotal.TabIndex = 21;
            this.lblGenerateTotal.Text = "总生成表数量";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(579, 343);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 17);
            this.label8.TabIndex = 20;
            this.label8.Text = "已恢复表数目";
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(244, 331);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(278, 35);
            this.btnRestore.TabIndex = 19;
            this.btnRestore.Text = "恢复约束";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // chbStep6
            // 
            this.chbStep6.AutoSize = true;
            this.chbStep6.Enabled = false;
            this.chbStep6.Location = new System.Drawing.Point(30, 339);
            this.chbStep6.Name = "chbStep6";
            this.chbStep6.Size = new System.Drawing.Size(140, 21);
            this.chbStep6.TabIndex = 18;
            this.chbStep6.Text = "6.恢复数据库限制";
            this.chbStep6.UseVisualStyleBackColor = true;
            // 
            // lblRemoveConstraintCount
            // 
            this.lblRemoveConstraintCount.AutoSize = true;
            this.lblRemoveConstraintCount.Location = new System.Drawing.Point(579, 169);
            this.lblRemoveConstraintCount.Name = "lblRemoveConstraintCount";
            this.lblRemoveConstraintCount.Size = new System.Drawing.Size(92, 17);
            this.lblRemoveConstraintCount.TabIndex = 17;
            this.lblRemoveConstraintCount.Text = "已去除表数目";
            // 
            // btnRemoveConstraint
            // 
            this.btnRemoveConstraint.Location = new System.Drawing.Point(244, 160);
            this.btnRemoveConstraint.Name = "btnRemoveConstraint";
            this.btnRemoveConstraint.Size = new System.Drawing.Size(278, 35);
            this.btnRemoveConstraint.TabIndex = 16;
            this.btnRemoveConstraint.Text = "去除约束";
            this.btnRemoveConstraint.UseVisualStyleBackColor = true;
            this.btnRemoveConstraint.Click += new System.EventHandler(this.btnRemoveConstraint_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(244, 277);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(278, 35);
            this.btnImport.TabIndex = 12;
            this.btnImport.Text = "开始导入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // chbStep5
            // 
            this.chbStep5.AutoSize = true;
            this.chbStep5.Enabled = false;
            this.chbStep5.Location = new System.Drawing.Point(30, 285);
            this.chbStep5.Name = "chbStep5";
            this.chbStep5.Size = new System.Drawing.Size(140, 21);
            this.chbStep5.TabIndex = 11;
            this.chbStep5.Text = "5.向新库导入数据";
            this.chbStep5.UseVisualStyleBackColor = true;
            // 
            // btnGenerateSQLFile
            // 
            this.btnGenerateSQLFile.Location = new System.Drawing.Point(244, 220);
            this.btnGenerateSQLFile.Name = "btnGenerateSQLFile";
            this.btnGenerateSQLFile.Size = new System.Drawing.Size(278, 35);
            this.btnGenerateSQLFile.TabIndex = 10;
            this.btnGenerateSQLFile.Text = "开始生成";
            this.btnGenerateSQLFile.UseVisualStyleBackColor = true;
            this.btnGenerateSQLFile.Click += new System.EventHandler(this.btnGenerateSQLFile_Click);
            // 
            // chbStep4
            // 
            this.chbStep4.AutoSize = true;
            this.chbStep4.Enabled = false;
            this.chbStep4.Location = new System.Drawing.Point(30, 228);
            this.chbStep4.Name = "chbStep4";
            this.chbStep4.Size = new System.Drawing.Size(172, 21);
            this.chbStep4.TabIndex = 9;
            this.chbStep4.Text = "4.根据SP生产SQL文件";
            this.chbStep4.UseVisualStyleBackColor = true;
            // 
            // btnDropDB
            // 
            this.btnDropDB.Location = new System.Drawing.Point(715, 112);
            this.btnDropDB.Name = "btnDropDB";
            this.btnDropDB.Size = new System.Drawing.Size(109, 35);
            this.btnDropDB.TabIndex = 8;
            this.btnDropDB.Text = "销毁";
            this.btnDropDB.UseVisualStyleBackColor = true;
            this.btnDropDB.Click += new System.EventHandler(this.btnDropDB_Click);
            // 
            // chbStep2
            // 
            this.chbStep2.AutoSize = true;
            this.chbStep2.Enabled = false;
            this.chbStep2.Location = new System.Drawing.Point(30, 117);
            this.chbStep2.Name = "chbStep2";
            this.chbStep2.Size = new System.Drawing.Size(98, 21);
            this.chbStep2.TabIndex = 7;
            this.chbStep2.Text = "2.创建新库";
            this.chbStep2.UseVisualStyleBackColor = true;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(241, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "库名";
            // 
            // txtNewDBName
            // 
            this.txtNewDBName.Location = new System.Drawing.Point(317, 118);
            this.txtNewDBName.Name = "txtNewDBName";
            this.txtNewDBName.Size = new System.Drawing.Size(205, 22);
            this.txtNewDBName.TabIndex = 3;
            // 
            // btnCreateDB
            // 
            this.btnCreateDB.Location = new System.Drawing.Point(580, 112);
            this.btnCreateDB.Name = "btnCreateDB";
            this.btnCreateDB.Size = new System.Drawing.Size(109, 35);
            this.btnCreateDB.TabIndex = 2;
            this.btnCreateDB.Text = "创建";
            this.btnCreateDB.UseVisualStyleBackColor = true;
            this.btnCreateDB.Click += new System.EventHandler(this.btnCreateDB_Click);
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
            // lblSPCount
            // 
            this.lblSPCount.AutoSize = true;
            this.lblSPCount.Location = new System.Drawing.Point(577, 59);
            this.lblSPCount.Name = "lblSPCount";
            this.lblSPCount.Size = new System.Drawing.Size(82, 17);
            this.lblSPCount.TabIndex = 0;
            this.lblSPCount.Text = "发现SP数量";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prgbar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 740);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1050, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // prgbar
            // 
            this.prgbar.Name = "prgbar";
            this.prgbar.Size = new System.Drawing.Size(100, 16);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 762);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grbProcess);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbProcess.ResumeLayout(false);
            this.grbProcess.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChangeConnectionString;
        private System.Windows.Forms.GroupBox grbProcess;
        private System.Windows.Forms.CheckBox chbStep1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNewDBName;
        private System.Windows.Forms.Button btnCreateDB;
        private System.Windows.Forms.Button btnSearchSPCount;
        private System.Windows.Forms.Label lblSPCount;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.CheckBox chbStep5;
        private System.Windows.Forms.Button btnGenerateSQLFile;
        private System.Windows.Forms.CheckBox chbStep4;
        private System.Windows.Forms.Button btnDropDB;
        private System.Windows.Forms.CheckBox chbStep2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.CheckBox chbStep6;
        private System.Windows.Forms.Label lblRemoveConstraintCount;
        private System.Windows.Forms.Button btnRemoveConstraint;
        private System.Windows.Forms.Label lblGenerateTotal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDBName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblConnectionStatus;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ListView lsvSPList;
        private System.Windows.Forms.Label lblCreateNewDBStatus;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar prgbar;
        private System.Windows.Forms.CheckBox chbStep3;
        private System.Windows.Forms.Button btnOthers;
        private System.Windows.Forms.CheckBox chbStep8;
        private System.Windows.Forms.CheckBox chbStep7;
        private System.Windows.Forms.Button btnTestProxy;
        private System.Windows.Forms.TextBox txtProxy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAccessKey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAccessId;
        private System.Windows.Forms.Button btnExport;
    }
}

