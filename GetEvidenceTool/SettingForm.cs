using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetEvidenceTool
{
    public partial class SettingForm : Form
    {
        private bool loaded = false;

        public SettingForm()
        {
            InitializeComponent();

            this.InitDisplay();
        }

        private void InitDisplay()
        {
            // log tab
            this.txtLogEncoding.Text = Config.Current.LogEncoding;
            this.txtLogDatetimeFormat.Text = Config.Current.LogDatetimeFormat;
            foreach(string log in Config.Current.Logs)
            {
                this.dgvLog.Rows.Add(log);
            }

            // export data tab
            this.txtDBHost.Text = Config.Current.Host;
            this.txtDBPort.Text = Config.Current.Port;
            this.txtDBUser.Text = Config.Current.User;
            this.txtDBPassword.Text = Config.Current.Password;
            this.txtDBName.Text = Config.Current.Database;
            foreach(var item in Config.Current.exportDatas)
            {
                this.dgvExportData.Rows.Add(item.Name, item.Query);
            }
            // Diff tab
            this.txtWinMergePath.Text = Config.Current.WinMergeUPath;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Config.Current.LogDatetimeFormat = this.txtLogDatetimeFormat.Text;
            Config.Current.LogEncoding = this.txtLogEncoding.Text;
            Config.Current.Logs.Clear();
            foreach (DataGridViewRow row in this.dgvLog.Rows)
            {
                if (!string.IsNullOrEmpty(row.Cells[0].Value.ToString()))
                {
                    Config.Current.Logs.Add((string)row.Cells[0].Value);
                }                
            }

            Config.Current.Host = this.txtDBHost.Text;
            Config.Current.Port = this.txtDBPort.Text;
            Config.Current.User = this.txtDBUser.Text;
            Config.Current.Password = this.txtDBPassword.Text;
            Config.Current.Database = this.txtDBName.Text;
            foreach (DataGridViewRow row in this.dgvExportData.Rows)
            {
                Config.Current.exportDatas.Add(
                    new ExportItem((string)row.Cells[0].Value, 
                                   (string)row.Cells[1].Value));
            }

            Config.Current.WinMergeUPath = this.txtWinMergePath.Text;
            Config.Current.Save();
            this.Close();
        }

        private void btnSelectWinMerge_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "select WinMergeU.exe";
            ofd.InitialDirectory = @"C:\Program Files";
            ofd.FileName = "WinMergeU.exe";
            ofd.Filter = "WinMergeU|WinMergeU.exe;WinMergeU.exe";
            ofd.FilterIndex = 1;

            DialogResult result = ofd.ShowDialog();
            if (DialogResult.OK == result)
            {
                this.txtWinMergePath.Text = ofd.FileName;
            }
        }

        private void btnSelectLog_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "select log file";
            ofd.FileName = "WinMergeU.exe";
            ofd.Filter = "ログファイル(*.log;*.log)|*.log;*.log|すべてのファイル(*.*)|*.*";
            ofd.FilterIndex = 1;

            DialogResult result = ofd.ShowDialog();
            if (DialogResult.OK == result)
            {
                this.txtLogPath.Text = ofd.FileName;
                this.btnLogAdd.Enabled = true;
            }
        }

        private void btnLogAdd_Click(object sender, EventArgs e)
        {
            this.dgvLog.Rows.Add(this.txtLogPath.Text);
            this.btnLogAdd.Enabled = false;
            this.txtLogPath.Text = String.Empty;
            this.dgvLog.ClearSelection();
        }

        private void dgvLog_SelectionChanged(object sender, EventArgs e)
        {
            if (!this.loaded)
            {
                return;
            }
            var row = this.dgvLog.CurrentRow;
            if (row.Index != -1)
            {
                this.txtLogPath.Text = row.Cells[0].Value.ToString();
                this.btnLogUpdate.Enabled = true;
                this.btnLogDelete.Enabled = true;
            }
        }

        private void btnLogUpdate_Click(object sender, EventArgs e)
        {
            var row = this.dgvLog.CurrentRow;
            if (row.Index != -1)
            {
                row.Cells[0].Value = this.txtLogPath.Text;
            }

        }

        private void btnLogDelete_Click(object sender, EventArgs e)
        {
            var row = this.dgvLog.CurrentRow;
            if (row.Index != -1)
            {
                this.dgvLog.Rows.Remove(row);
                this.txtLogPath.Text = String.Empty;
            }
            this.dgvLog.CurrentCell = null;
            this.dgvLog.ClearSelection();
        }

        private void btnLogClear_Click(object sender, EventArgs e)
        {
            this.dgvLog.Rows.Clear();
            this.txtLogPath.Text = String.Empty;
        }

        private void SettingForm_Shown(object sender, EventArgs e)
        {
            this.dgvLog.CurrentCell = null;
            this.dgvLog.ClearSelection();
            this.btnLogAdd.Enabled = false;
            this.btnLogUpdate.Enabled = false;
            this.btnLogDelete.Enabled = false;

            this.dgvExportData.CurrentCell = null;
            this.dgvExportData.ClearSelection();
            this.btnExportUpdate.Enabled = false;
            this.btnExportDelete.Enabled = false;

            this.loaded = true;
        }

        private void btnExportDelete_Click(object sender, EventArgs e)
        {
            var row = this.dgvExportData.CurrentRow;
            if (row.Index != -1)
            {
                this.dgvExportData.Rows.Remove(row);
                this.txtFileName.Text = String.Empty;
                this.txtQuery.Text = String.Empty;

                this.dgvExportData.CurrentCell = null;
                this.dgvExportData.ClearSelection();
            }
        }

        private void btnExportDataClear_Click(object sender, EventArgs e)
        {
            this.dgvExportData.Rows.Clear();
            this.txtFileName.Text = String.Empty;
            this.txtQuery.Text = String.Empty;
        }

        private void btnExportUpdate_Click(object sender, EventArgs e)
        {
            if (!this.CheckExportData())
            {
                return;
            }
            var row = this.dgvExportData.CurrentRow;
            if (row.Index != -1)
            {
                row.Cells[0].Value = this.txtFileName.Text;
                row.Cells[1].Value = this.txtQuery.Text;
            }
        }

        private void btnExportAdd_Click(object sender, EventArgs e)
        {
            if (!this.CheckExportData())
            {
                return;
            }
            this.dgvExportData.Rows.Add(this.txtFileName.Text, this.txtQuery.Text);
            this.btnExportAdd.Enabled = false;
            this.txtFileName.Text = String.Empty;
            this.txtQuery.Text = String.Empty;
            this.dgvExportData.ClearSelection();
        }

        private bool CheckExportData()
        {
            if (string.IsNullOrEmpty(this.txtFileName.Text))
            {
                MessageBox.Show("output csv file name is not input.");
                return false;
            }
            if (string.IsNullOrEmpty(this.txtQuery.Text))
            {
                MessageBox.Show("output csv file name is not input.");
                return false;
            }
            return true;
        }

        private void dgvExportData_SelectionChanged(object sender, EventArgs e)
        {
            if (!this.loaded)
            {
                return;
            }
            var row = this.dgvExportData.CurrentRow;
            if (row.Index != -1)
            {
                this.txtLogPath.Text = row.Cells[0].Value.ToString();
                this.btnExportUpdate.Enabled = true;
                this.btnExportDelete.Enabled = true;
            }
        }
    }
}
