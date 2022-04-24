namespace GetEvidenceTool
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.console = new System.Windows.Forms.RichTextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtFolderName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnLocation = new System.Windows.Forms.Button();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.chkLog = new System.Windows.Forms.CheckBox();
            this.chkTable = new System.Windows.Forms.CheckBox();
            this.chkDiff = new System.Windows.Forms.CheckBox();
            this.btnConfig = new System.Windows.Forms.Button();
            this.chkCollectBefore = new System.Windows.Forms.CheckBox();
            this.btnCaptureSceen = new System.Windows.Forms.Button();
            this.btnCaptureWindow = new System.Windows.Forms.Button();
            this.comboWindowTitle = new System.Windows.Forms.ComboBox();
            this.listViewCaptures = new System.Windows.Forms.ListView();
            this.imageListCaptures = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.btnActiveWindowCapture = new System.Windows.Forms.Button();
            this.btnAreaCapture = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(833, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(109, 55);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "試験開始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // console
            // 
            this.console.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.console.Dock = System.Windows.Forms.DockStyle.Fill;
            this.console.Location = new System.Drawing.Point(0, 0);
            this.console.Name = "console";
            this.console.ReadOnly = true;
            this.console.Size = new System.Drawing.Size(921, 184);
            this.console.TabIndex = 1;
            this.console.Text = "";
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Location = new System.Drawing.Point(833, 88);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(109, 52);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "試験完了";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtFolderName
            // 
            this.txtFolderName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolderName.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFolderName.Location = new System.Drawing.Point(524, 79);
            this.txtFolderName.Name = "txtFolderName";
            this.txtFolderName.Size = new System.Drawing.Size(191, 22);
            this.txtFolderName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(443, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "試験番号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(9, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "エビデンス格納先";
            // 
            // btnLocation
            // 
            this.btnLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLocation.Font = new System.Drawing.Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLocation.Location = new System.Drawing.Point(380, 83);
            this.btnLocation.Name = "btnLocation";
            this.btnLocation.Size = new System.Drawing.Size(49, 21);
            this.btnLocation.TabIndex = 5;
            this.btnLocation.Text = "・・・";
            this.btnLocation.UseCompatibleTextRendering = true;
            this.btnLocation.UseVisualStyleBackColor = true;
            this.btnLocation.Click += new System.EventHandler(this.btnLocation_Click);
            // 
            // txtLocation
            // 
            this.txtLocation.AcceptsTab = true;
            this.txtLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocation.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtLocation.Location = new System.Drawing.Point(111, 86);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.ReadOnly = true;
            this.txtLocation.Size = new System.Drawing.Size(263, 22);
            this.txtLocation.TabIndex = 6;
            // 
            // chkLog
            // 
            this.chkLog.AutoSize = true;
            this.chkLog.Font = new System.Drawing.Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkLog.Location = new System.Drawing.Point(283, 38);
            this.chkLog.Name = "chkLog";
            this.chkLog.Size = new System.Drawing.Size(81, 24);
            this.chkLog.TabIndex = 7;
            this.chkLog.Text = "ログ収集";
            this.chkLog.UseVisualStyleBackColor = true;
            // 
            // chkTable
            // 
            this.chkTable.AutoSize = true;
            this.chkTable.Font = new System.Drawing.Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkTable.Location = new System.Drawing.Point(409, 38);
            this.chkTable.Name = "chkTable";
            this.chkTable.Size = new System.Drawing.Size(135, 24);
            this.chkTable.TabIndex = 7;
            this.chkTable.Text = "テーブルデータ出力";
            this.chkTable.UseVisualStyleBackColor = true;
            // 
            // chkDiff
            // 
            this.chkDiff.AutoSize = true;
            this.chkDiff.Font = new System.Drawing.Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkDiff.Location = new System.Drawing.Point(565, 38);
            this.chkDiff.Name = "chkDiff";
            this.chkDiff.Size = new System.Drawing.Size(88, 24);
            this.chkDiff.TabIndex = 7;
            this.chkDiff.Text = "差分表示";
            this.chkDiff.UseVisualStyleBackColor = true;
            // 
            // btnConfig
            // 
            this.btnConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfig.AutoSize = true;
            this.btnConfig.Location = new System.Drawing.Point(51, 7);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(78, 25);
            this.btnConfig.TabIndex = 8;
            this.btnConfig.Text = "設定";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // chkCollectBefore
            // 
            this.chkCollectBefore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkCollectBefore.AutoSize = true;
            this.chkCollectBefore.Checked = true;
            this.chkCollectBefore.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCollectBefore.Font = new System.Drawing.Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkCollectBefore.Location = new System.Drawing.Point(51, 38);
            this.chkCollectBefore.Name = "chkCollectBefore";
            this.chkCollectBefore.Size = new System.Drawing.Size(200, 24);
            this.chkCollectBefore.TabIndex = 7;
            this.chkCollectBefore.Text = "試験開始時エビデンスを取得";
            this.chkCollectBefore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCollectBefore.UseVisualStyleBackColor = true;
            this.chkCollectBefore.Click += new System.EventHandler(this.chkCollectBefore_Click);
            // 
            // btnCaptureSceen
            // 
            this.btnCaptureSceen.Location = new System.Drawing.Point(578, 115);
            this.btnCaptureSceen.Name = "btnCaptureSceen";
            this.btnCaptureSceen.Size = new System.Drawing.Size(108, 54);
            this.btnCaptureSceen.TabIndex = 9;
            this.btnCaptureSceen.Text = "スクリーンショット(PrintScreen)";
            this.btnCaptureSceen.UseVisualStyleBackColor = true;
            this.btnCaptureSceen.Click += new System.EventHandler(this.btnCaptureSceen_Click);
            // 
            // btnCaptureWindow
            // 
            this.btnCaptureWindow.Location = new System.Drawing.Point(305, 114);
            this.btnCaptureWindow.Name = "btnCaptureWindow";
            this.btnCaptureWindow.Size = new System.Drawing.Size(108, 54);
            this.btnCaptureWindow.TabIndex = 9;
            this.btnCaptureWindow.Text = "画面ショット";
            this.btnCaptureWindow.UseVisualStyleBackColor = true;
            this.btnCaptureWindow.Click += new System.EventHandler(this.btnCaptureWindow_Click);
            // 
            // comboWindowTitle
            // 
            this.comboWindowTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboWindowTitle.Font = new System.Drawing.Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboWindowTitle.FormattingEnabled = true;
            this.comboWindowTitle.Location = new System.Drawing.Point(13, 128);
            this.comboWindowTitle.Name = "comboWindowTitle";
            this.comboWindowTitle.Size = new System.Drawing.Size(275, 28);
            this.comboWindowTitle.TabIndex = 10;
            this.comboWindowTitle.SelectedIndexChanged += new System.EventHandler(this.comboWindowTitle_SelectedIndexChanged);
            // 
            // listViewCaptures
            // 
            this.listViewCaptures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewCaptures.LargeImageList = this.imageListCaptures;
            this.listViewCaptures.Location = new System.Drawing.Point(0, 0);
            this.listViewCaptures.Name = "listViewCaptures";
            this.listViewCaptures.Size = new System.Drawing.Size(921, 111);
            this.listViewCaptures.TabIndex = 11;
            this.listViewCaptures.UseCompatibleStateImageBehavior = false;
            this.listViewCaptures.DoubleClick += new System.EventHandler(this.listViewCaptures_DoubleClick);
            // 
            // imageListCaptures
            // 
            this.imageListCaptures.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListCaptures.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListCaptures.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(13, 305);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 12;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(13, 185);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listViewCaptures);
            this.splitContainer1.Panel1MinSize = 0;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.console);
            this.splitContainer1.Size = new System.Drawing.Size(921, 296);
            this.splitContainer1.SplitterDistance = 111;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(690, 484);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "@Author by hanbing.cheng Version: v2.0";
            // 
            // btnActiveWindowCapture
            // 
            this.btnActiveWindowCapture.Location = new System.Drawing.Point(419, 114);
            this.btnActiveWindowCapture.Name = "btnActiveWindowCapture";
            this.btnActiveWindowCapture.Size = new System.Drawing.Size(153, 54);
            this.btnActiveWindowCapture.TabIndex = 9;
            this.btnActiveWindowCapture.Text = "アクティブウインドウショット(ALT+PrintScreen)";
            this.btnActiveWindowCapture.UseVisualStyleBackColor = true;
            this.btnActiveWindowCapture.Click += new System.EventHandler(this.btnActiveWindowCapture_Click);
            // 
            // btnAreaCapture
            // 
            this.btnAreaCapture.Location = new System.Drawing.Point(692, 115);
            this.btnAreaCapture.Name = "btnAreaCapture";
            this.btnAreaCapture.Size = new System.Drawing.Size(77, 54);
            this.btnAreaCapture.TabIndex = 9;
            this.btnAreaCapture.Text = "範囲指定";
            this.btnAreaCapture.UseVisualStyleBackColor = true;
            this.btnAreaCapture.Click += new System.EventHandler(this.btnAreaCapture_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 508);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.comboWindowTitle);
            this.Controls.Add(this.btnCaptureWindow);
            this.Controls.Add(this.btnAreaCapture);
            this.Controls.Add(this.btnActiveWindowCapture);
            this.Controls.Add(this.btnCaptureSceen);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.chkDiff);
            this.Controls.Add(this.chkTable);
            this.Controls.Add(this.chkCollectBefore);
            this.Controls.Add(this.chkLog);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.btnLocation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFolderName);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GetEvidenceTool";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnStart;
        private RichTextBox console;
        private Button btnStop;
        private TextBox txtFolderName;
        private Label label1;
        private Label label2;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button btnLocation;
        private TextBox txtLocation;
        private CheckBox chkLog;
        private CheckBox chkTable;
        private CheckBox chkDiff;
        private Button btnConfig;
        private CheckBox chkCollectBefore;
        private Button btnCaptureSceen;
        private Button btnCaptureWindow;
        private ComboBox comboWindowTitle;
        private ListView listViewCaptures;
        private ImageList imageListCaptures;
        private Panel panel1;
        private SplitContainer splitContainer1;
        private Label label3;
        private Button btnActiveWindowCapture;
        private Button btnAreaCapture;
    }
}