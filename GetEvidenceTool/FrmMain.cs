using Npgsql;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace GetEvidenceTool
{
    public partial class FrmMain : Form
    {
        private string startTime = string.Empty;
        private string location = string.Empty;
        private string folderName = string.Empty;
        private string rootDir = string.Empty;
        private string beforeDir = string.Empty;
        private string afterDir = string.Empty;
        private List<Bitmap> captures = new List<Bitmap>();
        private int width = 100;
        private int height = 80;
        private KeyboardHook keyboardHook = new KeyboardHook();
        private bool isCaptreFromButton = false;


        public FrmMain()
        {
            InitializeComponent();

            Config.Current.Load();

            this.imageListCaptures.ImageSize = new Size(width, height);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.SetControlState();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            keyboardHook.KeyDownEvent += KeyboardHook_KeyDownEvent;
            keyboardHook.Hook();

            this.comboWindowTitle.DisplayMember = "Title";
            this.comboWindowTitle.ValueMember = "Process";
            this.comboWindowTitle.Items.Clear();
            foreach (Process p in System.Diagnostics.Process.GetProcesses())
            {
                //メインウィンドウのタイトルがある時だけ列挙する
                if (p.MainWindowTitle.Length != 0)
                {
                    this.comboWindowTitle.Items.Add(new WindowInfo(p.MainWindowTitle, p));
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            keyboardHook.UnHook();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            FrmSetting settingForm = new FrmSetting();
            settingForm.ShowDialog();
            this.SetControlState();
        }

        private void btnLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "select folder to output evidences";
            fbd.ShowNewFolderButton = true;
            DialogResult dr = fbd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                location = fbd.SelectedPath;
                this.txtLocation.Text = location;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!this.IsReady())
            {
                return;
            }
            
            this.rootDir = Path.Combine(location, folderName);
            if (Directory.Exists(rootDir))
            {
                DialogResult result = MessageBox.Show("指定試験番号のフォルダが既に存在しています。上書きしますか？",
                    "確認",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);
                if (DialogResult.OK == result)
                {
                    Directory.Delete(rootDir, true);
                } else
                {
                    return;
                }                
            }

            this.btnStart.Enabled = false;
            this.btnLocation.Enabled = false;
            this.txtFolderName.ReadOnly = true;

            Directory.CreateDirectory(rootDir);
            this.startTime = DateTime.Now.ToString(Config.Current.LogDatetimeFormat);

            this.console.Clear();

            if (this.chkCollectBefore.Checked)
            {
                this.beforeDir = Path.Combine(rootDir, DateTime.Now.ToString("yyyyMMddHHmmss") + "_before");
                Directory.CreateDirectory(beforeDir);
                this.OutputToConsole("collect evidence on start");
                this.ExportTables(this.beforeDir);
                this.SaveCaptures(this.beforeDir);
               
            }
            this.btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.btnStop.Enabled = false;

            if (this.chkCollectBefore.Checked)
            {
                this.afterDir = Path.Combine(rootDir, DateTime.Now.ToString("yyyyMMddHHmmss") + "_after");
                Directory.CreateDirectory(this.afterDir);
            }
            else
            {
                this.afterDir = this.rootDir;
            }

            this.OutputToConsole("collect evidence on end");
            this.ExtractLog(this.afterDir);
            this.ExportTables(this.afterDir);
            this.SaveCaptures(this.afterDir);
            this.RunWinMerge();           

            this.btnLocation.Enabled = true;
            this.txtFolderName.ReadOnly = false;
            this.btnStart.Enabled = true;
        }

        private void chkCollectBefore_Click(object sender, EventArgs e)
        {
            this.btnCaptureSceen.Enabled = true;
            this.btnCaptureWindow_Click(this.btnCaptureWindow, new EventArgs());
            if (!this.chkCollectBefore.Checked)
            {
                if (this.btnStart.Enabled)
                {
                    this.btnCaptureSceen.Enabled = false;
                    this.btnCaptureWindow.Enabled = false;
                }

            }
            if (this.chkCollectBefore.Checked)
            {
                this.chkDiff.Enabled = true;            }else
            {
                this.chkDiff.Enabled = false;
                this.chkDiff.Checked = false;

            }
        }

        #region capture
        private void btnCaptureSceen_Click(object sender, EventArgs e)
        {
            this.isCaptreFromButton = true;
            Clipboard.Clear();
            this.Hide();
            SendKeys.SendWait("{PRTSC}");
            if(this.GetCapturemage())
            {
                this.OutputToConsole("スクリーンショットを取りました.");
            }
            
            Win32.SetForegroundWindow(this.Handle);
            this.Show();
            this.isCaptreFromButton = false;
        }

        private void btnCaptureWindow_Click(object sender, EventArgs e)
        {
            this.isCaptreFromButton = true;
            Clipboard.Clear();
            WindowInfo? info = this.comboWindowTitle.SelectedItem as WindowInfo;
            if (null == info)
            {
                return;
            }            
            Win32.SetForegroundWindow(info.Process.MainWindowHandle);
            Application.DoEvents();
            // ALT + PrintScreen
            SendKeys.SendWait("%{PRTSC}");
            if (this.GetCapturemage())
            {
                this.OutputToConsole(info.Title + "の画面ショットを取りました。");
            }

            Win32.SetForegroundWindow(this.Handle);
            this.isCaptreFromButton = false;
        }

        private void btnActiveWindowCapture_Click(object sender, EventArgs e)
        {            
            this.isCaptreFromButton = true;
            Clipboard.Clear();
            this.Hide();
            // ALT + PrintScreen
            SendKeys.SendWait("%{PRTSC}");
            string title = Win32.GetActiveWindowTitle();
            if (this.GetCapturemage())
            {
                this.OutputToConsole(title + "の画面ショットを取りました。");
            }
            this.Show();
            Win32.SetForegroundWindow(this.Handle);
            this.isCaptreFromButton = false;
        }

        private void btnAreaCapture_Click(object sender, EventArgs e)
        {
            FrmCapture frm = new FrmCapture();
            frm.Owner = this;
            frm.ShowDialog();
            if (this.GetCapturemage())
            {
                this.OutputToConsole("指定領域のキャプチャを取りました。");
            }

        }

        private void KeyboardHook_KeyDownEvent(object sender, LowLevelKeyEventArgs e)
        {
            if (e.Code == (int)Keys.PrintScreen)
            {
                if (!this.btnStart.Enabled || this.isCaptreFromButton)
                {
                    return;
                }
                if (Control.ModifierKeys == Keys.Alt)
                {
                    string title = Win32.GetActiveWindowTitle();
                    if (this.GetCapturemage())
                    {
                        this.OutputToConsole(title + "の画面ショットを取りました。");
                    }
                }
                else
                {
                    if (this.GetCapturemage())
                    {
                        this.OutputToConsole("スクリーンショットを取りました.");
                    }                    
                }
            }
        }

        private bool GetCapturemage()
        {
            IDataObject data = Clipboard.GetDataObject();
            Bitmap? bmp = null;
            if (data.GetDataPresent(DataFormats.Bitmap))
            {
                bmp = (Bitmap)data.GetData(DataFormats.Bitmap);
            }
            if (bmp != null)
            {
                this.captures.Add(bmp);
                Image thumbnail = this.CreateThumbnail(bmp, width, height);
                this.imageListCaptures.Images.Add(thumbnail);
                int index = this.captures.Count - 1;
                this.listViewCaptures.Items.Add((index + 1).ToString("D3"), index);
                if (0 == this.splitContainer1.SplitterDistance)
                {
                    this.splitContainer1.SplitterDistance = 110;
                }
                return true;
            } else
            {
                this.OutputToConsole("画面ショットの取得に失敗しました。");
                return false;
            }
        }

        private void comboWindowTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (-1 < this.comboWindowTitle.SelectedIndex)
            {
                this.btnCaptureWindow.Enabled = true;
            }
            else
            {
                this.btnCaptureWindow.Enabled = false;
            }
        }

        private void listViewCaptures_DoubleClick(object sender, EventArgs e)
        {
            int index = this.listViewCaptures.SelectedIndices[0];
            Image image = this.captures[index];
            FrmImageViewer frm = new FrmImageViewer(image);
            frm.ShowDialog();
        }
        #endregion capture

        private bool IsReady()
        {
            if (string.IsNullOrEmpty(location))
            {
                MessageBox.Show("エビデンスの格納先を指定してください。");
                return false;
            }
            string folderName = this.txtFolderName.Text;
            if (string.IsNullOrEmpty(folderName))
            {
                MessageBox.Show("試験番号／エビデンスフォルダ名を指定してください。");
                return false;
            }
            if (0 <= folderName.IndexOfAny(Path.GetInvalidPathChars()))
            {
                return false;
            }
            this.folderName = folderName;
            return true;
        }

        private void OutputToConsole(string message)
        {
            this.console.AppendText(DateTime.Now.ToString("yyyyMMddHHmmss")  + "\t" + message);
            this.console.AppendText(Environment.NewLine);
        }

        private void ExtractLog(string path)
        {
            if (!this.chkLog.Checked)
            {
                return;
            }

            foreach (string logPath in Config.Current.Logs)
            {
                OutputToConsole(String.Format("extract log from: {0}", logPath));

                string filename = Path.GetFileName(logPath);
                string outputLogPath = Path.Combine(path, filename);
                string line = string.Empty;
                bool find = false;
                using (FileStream fs = new FileStream(logPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader sr = new StreamReader(fs, Encoding.GetEncoding(Config.Current.LogEncoding)))
                using (StreamWriter sw = new StreamWriter(outputLogPath, true, Encoding.GetEncoding(Config.Current.LogEncoding)))
                {
                    while (-1 < sr.Peek())
                    {
                        line = sr.ReadLine() ?? "";
                        if (find)
                        {
                            sw.WriteLine(line);
                        }
                        else if (this.startTime.Length < line.Length)
                        {
                            string timeStr = line.Substring(0, this.startTime.Length);
                            if (this.startTime.CompareTo(timeStr) <= 0)
                            {
                                find = true;
                                sw.WriteLine(line);
                            }
                        }
                    }
                }

            }
        }

        private void ExportTables(string path)
        {
            if (!this.chkTable.Checked || true != Config.Current.CanExportData)
            {
                return;
            }

            foreach (ExportItem item in Config.Current.exportDatas)
            {
                string fileName = item.Name;
                if (!fileName.Contains(".csv"))
                {
                    fileName += ".csv";
                }
                string csvPath = Path.Combine(path, fileName);
                this.OutputToConsole(String.Format("export data to {0}.", csvPath));
                this.ExportDataToCSV(csvPath, item.Query);
            } 
        }

        private void SaveCaptures(string path)
        {
            for (int i = 0; i < this.captures.Count; i++)
            {
                Bitmap bmp = this.captures[i];
                bmp.Save(Path.Combine(path, (i + 1).ToString("D3") + ".bmp"));
            }
            this.captures.Clear();
            this.listViewCaptures.Items.Clear();
            this.imageListCaptures.Images.Clear();
        }

        private void ExportDataToCSV(string filePath, string sql)
        {
            using (var con = new NpgsqlConnection(Config.Current.ConnectionString))
            {
                con.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                // header
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    builder.Append(dr.GetName(i));
                    if (i != dr.FieldCount - 1)
                    {
                        builder.Append(",");
                    }
                }
                using (StreamWriter sw = new StreamWriter(filePath, true, Encoding.GetEncoding("UTF-8")))
                {
                    sw.WriteLine(builder.ToString());
                    // data
                    long count = 0;
                    while (dr.Read())
                    {
                        count++;
                        builder = new StringBuilder();
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            if (dr[i] == DBNull.Value)
                            {
                                builder.Append(Config.Current.NullString);
                            }
                            else
                            {
                                builder.Append(dr[i]);
                            }
                            builder.Append(dr[i] ?? Config.Current.NullString);
                            if (i != dr.FieldCount - 1)
                            {
                                builder.Append(",");
                            }
                        }
                        sw.WriteLine(builder.ToString());
                    }
                    this.OutputToConsole(string.Format("exported {0} rows", count));
                }

            }
        }

        private void RunWinMerge()
        {
            if (!this.chkDiff.Checked ||
                !this.chkCollectBefore.Checked ||
                true != Config.Current.CanDiff)
            {
                return;
            }

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.FileName = Config.Current.WinMergeUPath;
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.Arguments = this.beforeDir + " " + this.afterDir;

            Process.Start(startInfo);
        }

        private void SetControlState()
        {
            if (!Config.Current.CanExtractLog)
            {
                this.chkLog.Checked = false;
                this.chkLog.Enabled = false;
            }
            else
            {
                this.chkLog.Checked = true;
            }
            if (!Config.Current.CanExportData)
            {
                this.chkTable.Checked = false;
                this.chkTable.Enabled = false;
            }
            else
            {
                this.chkTable.Checked = true;
            }

            if (!Config.Current.CanDiff)
            {
                this.chkDiff.Checked = false;
                this.chkDiff.Enabled = false;
            }
            else
            {
                this.chkDiff.Checked = true;
            }
            this.btnCaptureWindow.Enabled = false;
            this.splitContainer1.SplitterDistance = 0;

        }

        Image CreateThumbnail(Image image, int w, int h)
        {
            Bitmap canvas = new Bitmap(w, h);

            Graphics g = Graphics.FromImage(canvas);
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, w, h);

            float fw = (float)w / (float)image.Width;
            float fh = (float)h / (float)image.Height;

            float scale = Math.Min(fw, fh);
            fw = image.Width * scale;
            fh = image.Height * scale;

            g.DrawImage(image, (w - fw) / 2, (h - fh) / 2, fw, fh);
            g.Dispose();

            return canvas;
        }
    }

    public class WindowInfo
    {
        public string Title { get; private set; } = string.Empty;
        public Process Process { get; private set; }

        public WindowInfo(string title, Process process)
        {
            this.Title = title;
            this.Process = process;

        }
    }
}