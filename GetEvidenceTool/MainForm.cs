using Npgsql;
using System.Configuration;
using System.Diagnostics;
using System.Text;

namespace GetEvidenceTool
{
    public partial class MainForm : Form
    {
        private string startTime = string.Empty;
        private string location = string.Empty;
        private string folderName = string.Empty;
        private string rootDir = string.Empty;
        private string beforeDir = string.Empty;
        private string afterDir = string.Empty;

        public MainForm()
        {
            InitializeComponent();

            Config.Current.Load();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!this.IsReady())
            {
                return;
            }

            this.btnStart.Enabled = false;
            this.btnLocation.Enabled = false;
            this.txtFolderName.ReadOnly = true;

            this.rootDir = Path.Combine(location, folderName);
            if (Directory.Exists(rootDir))
            {
                Directory.Delete(rootDir, true);
            }
            Directory.CreateDirectory(rootDir);

            this.startTime = DateTime.Now.ToString(Config.Current.LogDatetimeFormat);

            this.console.Clear();

            if (this.chkCollectBefore.Checked)
            {
                this.beforeDir = Path.Combine(rootDir, DateTime.Now.ToString("yyyyMMddHHmmss") + "_before");
                Directory.CreateDirectory(beforeDir);
                this.OutputToConsole("collect evidence on start");
                this.ExportTables(this.beforeDir);
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
            
            this.RunWinMerge();           

            this.btnLocation.Enabled = true;
            this.txtFolderName.ReadOnly = false;
            this.btnStart.Enabled = true;
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

        private bool IsReady()
        {
            if (string.IsNullOrEmpty(location))
            {
                MessageBox.Show("evidence location is not set.");
                return false;
            }
            string folderName = this.txtFolderName.Text;
            if (string.IsNullOrEmpty(folderName))
            {
                MessageBox.Show("folder name is not set");
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
            this.console.AppendText(message);
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

        private void btnConfig_Click(object sender, EventArgs e)
        {
            SettingForm settingForm = new SettingForm();
            settingForm.ShowDialog();
            this.SetControlState();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.SetControlState();
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
        }

        private void chkCollectBefore_Click(object sender, EventArgs e)
        {
            if (!this.chkCollectBefore.Checked)
            {
                this.chkDiff.Checked = false;
            }
        }
    }
}