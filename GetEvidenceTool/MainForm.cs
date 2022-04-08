using Npgsql;
using System.Configuration;
using System.Diagnostics;
using System.Text;

namespace GetEvidenceTool
{
    public partial class MainForm : Form
    {
        private string datetimeFormat = "yyyy/MM/dd HH:mm:ss";
        private string loggEncoding = string.Empty;
        // db connection setting
        private bool isExportTable = false;
        private string connString = string.Empty;
        private string nullString = string.Empty;
        private string winmergePath = string.Empty;

        private string startTime = string.Empty;
        private List<string> logs = new List<string>();
        private string location = string.Empty;
        private string folderName = string.Empty;
        private string rootDir = string.Empty;
        private string beforeDir = string.Empty;
        private string afterDir = string.Empty;

        public MainForm()
        {
            InitializeComponent();

            this.LoadConfig();

            if (this.logs.Count == 0)
            {
                this.chkLog.Checked = false;
                this.chkLog.Enabled = false;
            }
            else
            {
                this.chkLog.Checked = true;
            }
            if (!this.isExportTable)
            {
                this.chkTable.Checked = false;
                this.chkTable.Enabled = false;
            }
            else
            {
                this.chkTable.Checked = true;
            }
            if (string.IsNullOrEmpty(this.winmergePath))
            {
                this.chkDiff.Checked = false;
                this.chkDiff.Enabled = false;
            }
            else
            {
                this.chkDiff.Checked = true;
            }
        }

        private void LoadConfig()
        {
            this.datetimeFormat = ConfigurationManager.AppSettings["datetimeformat"] ?? "";
            if (string.IsNullOrEmpty(datetimeFormat))
            {
                MessageBox.Show("datetimeFormat is not set on config file");
                return;
            }
            string log1 = ConfigurationManager.AppSettings["log1"] ?? "";
            if (!String.IsNullOrEmpty(log1) && File.Exists(log1))
            {
                this.logs.Add(log1);
            }
            string log2 = ConfigurationManager.AppSettings["log2"] ?? "";
            if (!String.IsNullOrEmpty(log2) && File.Exists(log2))
            {
                this.logs.Add(log2);
            }
            string log3 = ConfigurationManager.AppSettings["log3"] ?? "";
            if (!String.IsNullOrEmpty(log3) && File.Exists(log3))
            {
                this.logs.Add(log3);
            }
            this.loggEncoding = ConfigurationManager.AppSettings["logEncoding"] ?? "UTF-8";
            string host = ConfigurationManager.AppSettings["host"] ?? "";
            string port = ConfigurationManager.AppSettings["port"] ?? "";
            string user = ConfigurationManager.AppSettings["user"] ?? "";
            string passwd = ConfigurationManager.AppSettings["password"] ?? "";
            string dbname = ConfigurationManager.AppSettings["dbname"] ?? "";
            if (string.IsNullOrEmpty(host) ||
                string.IsNullOrEmpty(port) ||
                string.IsNullOrEmpty(user) ||
                string.IsNullOrEmpty(passwd) ||
                string.IsNullOrEmpty(dbname))
            {
                this.isExportTable = false;
            } 
            else
            {
                this.isExportTable = true;
                this.connString = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4}", host, port, user, passwd, dbname);
                this.nullString = ConfigurationManager.AppSettings["nullString"] ?? String.Empty;
            }

            this.winmergePath = ConfigurationManager.AppSettings["WinMerge"] ?? "";
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

            this.beforeDir = Path.Combine(rootDir, DateTime.Now.ToString("yyyyMMddHHmmss") + "_before");
            Directory.CreateDirectory(beforeDir);
            this.startTime = DateTime.Now.ToString(this.datetimeFormat);

            this.console.Clear();
            this.OutputToConsole("collect evidence on start");
            this.ExportTables(this.beforeDir);

            this.btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.btnStop.Enabled = false;

            this.afterDir = Path.Combine(rootDir, DateTime.Now.ToString("yyyyMMddHHmmss") + "_after");
            Directory.CreateDirectory(this.afterDir);

            this.OutputToConsole("collect evidence on end");
            this.CollectLog(this.afterDir);
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

        private void CollectLog(string path)
        {
            if (!this.chkLog.Checked)
            {
                return;
            }

            foreach (string logPath in this.logs)
            {
                OutputToConsole(String.Format("collect log from: {0}", logPath));

                string filename = Path.GetFileName(logPath);
                string outputLogPath = Path.Combine(path, filename);
                string line = string.Empty;
                bool find = false;
                using (FileStream fs = new FileStream(logPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader sr = new StreamReader(fs, Encoding.GetEncoding(this.loggEncoding)))
                using (StreamWriter sw = new StreamWriter(outputLogPath, true, Encoding.GetEncoding(this.loggEncoding)))
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
            if (!this.chkTable.Checked || !this.isExportTable)
            {
                return;
            }

            string exportTablesFilePath = Path.Combine(Directory.GetCurrentDirectory(), "export_tables.txt");
            if (!File.Exists(exportTablesFilePath))
            {
                MessageBox.Show("export_tables.txt is not exist on app location.");
                return;
            }

            string line = string.Empty;

            using (FileStream fs = new FileStream(exportTablesFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("UTF-8")))
            {
                while (-1 < sr.Peek())
                {
                    line = sr.ReadLine() ?? "";
                    if (!string.IsNullOrEmpty(line))
                    {
                        string[] data = line.Split(":");
                        if (data.Length == 2)
                        {
                            string csvPath = Path.Combine(path, data[0] + ".csv");
                            this.OutputToConsole(String.Format("export data from table: {0} to {1}.", data[0], csvPath));
                            this.ExportDataToCSV(csvPath, data[1]);
                        }
                    }
                }
            }
        }

        private void ExportDataToCSV(string filePath, string sql)
        {
            using (var con = new NpgsqlConnection(this.connString))
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
                                builder.Append(this.nullString);
                            }
                            else
                            {
                                builder.Append(dr[i]);
                            }
                            builder.Append(dr[i] ?? this.nullString);
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
                string.IsNullOrEmpty(this.winmergePath) ||
                !File.Exists(this.winmergePath))
            {
                return;
            }

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.FileName = this.winmergePath;
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.Arguments = this.beforeDir + " " + this.afterDir;

            Process.Start(startInfo);
        }
    }
}