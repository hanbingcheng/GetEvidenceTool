namespace GetEvidenceTool
{
    partial class SettingForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtLogEncoding = new System.Windows.Forms.TextBox();
            this.txtLogDatetimeFormat = new System.Windows.Forms.TextBox();
            this.btnSelectLog = new System.Windows.Forms.Button();
            this.txtLogPath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogAdd = new System.Windows.Forms.Button();
            this.btnLogUpdate = new System.Windows.Forms.Button();
            this.btnLogDelete = new System.Windows.Forms.Button();
            this.btnLogClear = new System.Windows.Forms.Button();
            this.dgvLog = new System.Windows.Forms.DataGridView();
            this.logPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDBPassword = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDBUser = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDBPort = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDBHost = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvExportData = new System.Windows.Forms.DataGridView();
            this.txtQuery = new System.Windows.Forms.RichTextBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnExportClear = new System.Windows.Forms.Button();
            this.btnExportDelete = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnExportAdd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExportUpdate = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnSelectWinMerge = new System.Windows.Forms.Button();
            this.txtWinMergePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.fileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.query = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExportData)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(-1, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1218, 556);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtLogEncoding);
            this.tabPage1.Controls.Add(this.txtLogDatetimeFormat);
            this.tabPage1.Controls.Add(this.btnSelectLog);
            this.tabPage1.Controls.Add(this.txtLogPath);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnLogAdd);
            this.tabPage1.Controls.Add(this.btnLogUpdate);
            this.tabPage1.Controls.Add(this.btnLogDelete);
            this.tabPage1.Controls.Add(this.btnLogClear);
            this.tabPage1.Controls.Add(this.dgvLog);
            this.tabPage1.Font = new System.Drawing.Font("Yu Gothic UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1210, 528);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ログ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtLogEncoding
            // 
            this.txtLogEncoding.Location = new System.Drawing.Point(653, 44);
            this.txtLogEncoding.Name = "txtLogEncoding";
            this.txtLogEncoding.Size = new System.Drawing.Size(129, 31);
            this.txtLogEncoding.TabIndex = 10;
            // 
            // txtLogDatetimeFormat
            // 
            this.txtLogDatetimeFormat.Location = new System.Drawing.Point(244, 49);
            this.txtLogDatetimeFormat.Name = "txtLogDatetimeFormat";
            this.txtLogDatetimeFormat.Size = new System.Drawing.Size(208, 31);
            this.txtLogDatetimeFormat.TabIndex = 10;
            // 
            // btnSelectLog
            // 
            this.btnSelectLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectLog.Location = new System.Drawing.Point(1012, 340);
            this.btnSelectLog.Name = "btnSelectLog";
            this.btnSelectLog.Size = new System.Drawing.Size(53, 31);
            this.btnSelectLog.TabIndex = 8;
            this.btnSelectLog.Text = "・・・";
            this.btnSelectLog.UseVisualStyleBackColor = true;
            this.btnSelectLog.Click += new System.EventHandler(this.btnSelectLog_Click);
            // 
            // txtLogPath
            // 
            this.txtLogPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogPath.Location = new System.Drawing.Point(6, 340);
            this.txtLogPath.Name = "txtLogPath";
            this.txtLogPath.ReadOnly = true;
            this.txtLogPath.Size = new System.Drawing.Size(1000, 31);
            this.txtLogPath.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(477, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(170, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "ログファイルのエンコード";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(535, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "指定されているログファイルから試験開始と試験終了の間のログを収集する";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(233, 25);
            this.label6.TabIndex = 6;
            this.label6.Text = "ログファイル内の日時フォーマット";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 293);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "ログファイルを指定する";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnLogAdd
            // 
            this.btnLogAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogAdd.Location = new System.Drawing.Point(1113, 355);
            this.btnLogAdd.Name = "btnLogAdd";
            this.btnLogAdd.Size = new System.Drawing.Size(91, 33);
            this.btnLogAdd.TabIndex = 3;
            this.btnLogAdd.Text = "追加";
            this.btnLogAdd.UseVisualStyleBackColor = true;
            this.btnLogAdd.Click += new System.EventHandler(this.btnLogAdd_Click);
            // 
            // btnLogUpdate
            // 
            this.btnLogUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogUpdate.Location = new System.Drawing.Point(1113, 306);
            this.btnLogUpdate.Name = "btnLogUpdate";
            this.btnLogUpdate.Size = new System.Drawing.Size(91, 33);
            this.btnLogUpdate.TabIndex = 4;
            this.btnLogUpdate.Text = "更新";
            this.btnLogUpdate.UseVisualStyleBackColor = true;
            this.btnLogUpdate.Click += new System.EventHandler(this.btnLogUpdate_Click);
            // 
            // btnLogDelete
            // 
            this.btnLogDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogDelete.Location = new System.Drawing.Point(1113, 129);
            this.btnLogDelete.Name = "btnLogDelete";
            this.btnLogDelete.Size = new System.Drawing.Size(91, 33);
            this.btnLogDelete.TabIndex = 5;
            this.btnLogDelete.Text = "削除";
            this.btnLogDelete.UseVisualStyleBackColor = true;
            this.btnLogDelete.Click += new System.EventHandler(this.btnLogDelete_Click);
            // 
            // btnLogClear
            // 
            this.btnLogClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogClear.Location = new System.Drawing.Point(1116, 179);
            this.btnLogClear.Name = "btnLogClear";
            this.btnLogClear.Size = new System.Drawing.Size(91, 33);
            this.btnLogClear.TabIndex = 5;
            this.btnLogClear.Text = "クリア";
            this.btnLogClear.UseVisualStyleBackColor = true;
            this.btnLogClear.Click += new System.EventHandler(this.btnLogClear_Click);
            // 
            // dgvLog
            // 
            this.dgvLog.AllowUserToAddRows = false;
            this.dgvLog.AllowUserToDeleteRows = false;
            this.dgvLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.logPath});
            this.dgvLog.Location = new System.Drawing.Point(12, 111);
            this.dgvLog.MultiSelect = false;
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.RowTemplate.Height = 25;
            this.dgvLog.Size = new System.Drawing.Size(1095, 150);
            this.dgvLog.TabIndex = 2;
            this.dgvLog.SelectionChanged += new System.EventHandler(this.dgvLog_SelectionChanged);
            // 
            // logPath
            // 
            this.logPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.logPath.HeaderText = "";
            this.logPath.Name = "logPath";
            this.logPath.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Font = new System.Drawing.Font("Yu Gothic UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1210, 528);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "テーブルデータエクスポート";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDBName);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtDBPassword);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtDBUser);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtDBPort);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtDBHost);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(12, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(923, 117);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "データベース接続設定（Postgres)";
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(693, 20);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(208, 31);
            this.txtDBName.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(601, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 25);
            this.label12.TabIndex = 11;
            this.label12.Text = "Database";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDBPassword
            // 
            this.txtDBPassword.Location = new System.Drawing.Point(378, 65);
            this.txtDBPassword.Name = "txtDBPassword";
            this.txtDBPassword.Size = new System.Drawing.Size(208, 31);
            this.txtDBPassword.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(311, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 25);
            this.label11.TabIndex = 11;
            this.label11.Text = "Password";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDBUser
            // 
            this.txtDBUser.Location = new System.Drawing.Point(73, 65);
            this.txtDBUser.Name = "txtDBUser";
            this.txtDBUser.Size = new System.Drawing.Size(208, 31);
            this.txtDBUser.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 25);
            this.label10.TabIndex = 11;
            this.label10.Text = "User";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDBPort
            // 
            this.txtDBPort.Location = new System.Drawing.Point(378, 24);
            this.txtDBPort.Name = "txtDBPort";
            this.txtDBPort.Size = new System.Drawing.Size(208, 31);
            this.txtDBPort.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(311, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 25);
            this.label9.TabIndex = 11;
            this.label9.Text = "Port";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDBHost
            // 
            this.txtDBHost.Location = new System.Drawing.Point(73, 28);
            this.txtDBHost.Name = "txtDBHost";
            this.txtDBHost.Size = new System.Drawing.Size(208, 31);
            this.txtDBHost.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 25);
            this.label8.TabIndex = 11;
            this.label8.Text = "Server";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvExportData);
            this.groupBox1.Controls.Add(this.txtQuery);
            this.groupBox1.Controls.Add(this.txtFileName);
            this.groupBox1.Controls.Add(this.btnExportClear);
            this.groupBox1.Controls.Add(this.btnExportDelete);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnExportAdd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnExportUpdate);
            this.groupBox1.Location = new System.Drawing.Point(12, 148);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1158, 337);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "エクスポート対象データ取得SQLとCSVファイル名の指定";
            // 
            // dgvExportData
            // 
            this.dgvExportData.AllowUserToAddRows = false;
            this.dgvExportData.AllowUserToDeleteRows = false;
            this.dgvExportData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvExportData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExportData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fileName,
            this.query});
            this.dgvExportData.Location = new System.Drawing.Point(15, 30);
            this.dgvExportData.MultiSelect = false;
            this.dgvExportData.Name = "dgvExportData";
            this.dgvExportData.RowTemplate.Height = 25;
            this.dgvExportData.Size = new System.Drawing.Size(1031, 151);
            this.dgvExportData.TabIndex = 0;
            this.dgvExportData.SelectionChanged += new System.EventHandler(this.dgvExportData_SelectionChanged);
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(183, 233);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(863, 96);
            this.txtQuery.TabIndex = 10;
            this.txtQuery.Text = "";
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Location = new System.Drawing.Point(183, 185);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(417, 31);
            this.txtFileName.TabIndex = 9;
            // 
            // btnExportClear
            // 
            this.btnExportClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportClear.Location = new System.Drawing.Point(1061, 69);
            this.btnExportClear.Name = "btnExportClear";
            this.btnExportClear.Size = new System.Drawing.Size(91, 33);
            this.btnExportClear.TabIndex = 1;
            this.btnExportClear.Text = "クリア";
            this.btnExportClear.UseVisualStyleBackColor = true;
            this.btnExportClear.Click += new System.EventHandler(this.btnExportDataClear_Click);
            // 
            // btnExportDelete
            // 
            this.btnExportDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportDelete.Location = new System.Drawing.Point(1061, 30);
            this.btnExportDelete.Name = "btnExportDelete";
            this.btnExportDelete.Size = new System.Drawing.Size(91, 33);
            this.btnExportDelete.TabIndex = 1;
            this.btnExportDelete.Text = "削除";
            this.btnExportDelete.UseVisualStyleBackColor = true;
            this.btnExportDelete.Click += new System.EventHandler(this.btnExportDelete_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "データ取得SQL";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnExportAdd
            // 
            this.btnExportAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportAdd.Location = new System.Drawing.Point(1052, 236);
            this.btnExportAdd.Name = "btnExportAdd";
            this.btnExportAdd.Size = new System.Drawing.Size(91, 33);
            this.btnExportAdd.TabIndex = 1;
            this.btnExportAdd.Text = "追加";
            this.btnExportAdd.UseVisualStyleBackColor = true;
            this.btnExportAdd.Click += new System.EventHandler(this.btnExportAdd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "出力CSVファイル名";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnExportUpdate
            // 
            this.btnExportUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportUpdate.Location = new System.Drawing.Point(1052, 185);
            this.btnExportUpdate.Name = "btnExportUpdate";
            this.btnExportUpdate.Size = new System.Drawing.Size(91, 33);
            this.btnExportUpdate.TabIndex = 1;
            this.btnExportUpdate.Text = "更新";
            this.btnExportUpdate.UseVisualStyleBackColor = true;
            this.btnExportUpdate.Click += new System.EventHandler(this.btnExportUpdate_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnSelectWinMerge);
            this.tabPage3.Controls.Add(this.txtWinMergePath);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1210, 528);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "差分";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnSelectWinMerge
            // 
            this.btnSelectWinMerge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectWinMerge.Location = new System.Drawing.Point(893, 74);
            this.btnSelectWinMerge.Name = "btnSelectWinMerge";
            this.btnSelectWinMerge.Size = new System.Drawing.Size(75, 31);
            this.btnSelectWinMerge.TabIndex = 2;
            this.btnSelectWinMerge.Text = "・・・";
            this.btnSelectWinMerge.UseVisualStyleBackColor = true;
            this.btnSelectWinMerge.Click += new System.EventHandler(this.btnSelectWinMerge_Click);
            // 
            // txtWinMergePath
            // 
            this.txtWinMergePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWinMergePath.Location = new System.Drawing.Point(23, 76);
            this.txtWinMergePath.Name = "txtWinMergePath";
            this.txtWinMergePath.ReadOnly = true;
            this.txtWinMergePath.Size = new System.Drawing.Size(864, 29);
            this.txtWinMergePath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "WinMergeU.exeのパスを指定する";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.AutoSize = true;
            this.btnSave.Font = new System.Drawing.Font("Yu Gothic UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Location = new System.Drawing.Point(1142, 569);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 35);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoSize = true;
            this.btnCancel.Font = new System.Drawing.Font("Yu Gothic UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Location = new System.Drawing.Point(1044, 569);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 35);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "kyンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // fileName
            // 
            this.fileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fileName.HeaderText = "CSVファイル名";
            this.fileName.Name = "fileName";
            this.fileName.Width = 136;
            // 
            // query
            // 
            this.query.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.query.HeaderText = "SQL";
            this.query.Name = "query";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 605);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting";
            this.Shown += new System.EventHandler(this.SettingForm_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExportData)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dgvExportData;
        private TabPage tabPage3;
        private Button btnSelectWinMerge;
        private TextBox txtWinMergePath;
        private Label label1;
        private Button btnSave;
        private Button btnSelectLog;
        private TextBox txtLogPath;
        private Label label2;
        private Button btnLogAdd;
        private Button btnLogUpdate;
        private Button btnLogClear;
        private DataGridView dgvLog;
        private RichTextBox txtQuery;
        private TextBox txtFileName;
        private Label label4;
        private Label label3;
        private Button btnExportAdd;
        private Button btnExportUpdate;
        private Button btnExportDelete;
        private Label label5;
        private TextBox txtLogEncoding;
        private TextBox txtLogDatetimeFormat;
        private Label label7;
        private Label label6;
        private Button btnCancel;
        private GroupBox groupBox2;
        private TextBox txtDBName;
        private Label label12;
        private TextBox txtDBPassword;
        private Label label11;
        private TextBox txtDBUser;
        private Label label10;
        private TextBox txtDBPort;
        private Label label9;
        private TextBox txtDBHost;
        private Label label8;
        private GroupBox groupBox1;
        private DataGridViewTextBoxColumn logPath;
        private Button btnLogDelete;
        private Button btnExportClear;
        private DataGridViewTextBoxColumn fileName;
        private DataGridViewTextBoxColumn query;
    }
}