using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GetEvidenceTool
{
    [DataContract(Name = "Config")]
    public class Config
    {
        private static string CONFIG_FILE_NAME = "GetEvidenceTool.cnf";

        public static Config Current { get; private set; } = new Config();

        [DataMember()]
        public string LogDatetimeFormat { get; set; } = "yyyy/MM/dd HH:mm:ss";

        [DataMember()]
        public string LogEncoding { get; set; } = "UTF-8";

        [DataMember()]
        public List<string> Logs { get; set;} = new List<string>();

        public bool CanExtractLog
        {
            get
            {
                return 0 < this.Logs.Count;
            }
        }

        [DataMember()]
        public string Host { get; set; } = "localhost";

        [DataMember()]
        public string Port { get; set; } = "5432";

        [DataMember()]
        public string User { get; set; } = string.Empty;

        [DataMember()]
        public string Password { get; set; } = string.Empty;

        [DataMember()]
        public string Database { get; set; } = string.Empty;

        public string ConnectionString
        {
            get
            {
                return String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4}", this.Host, this.Port, this.User, this.Password, this.Database);
            }
        }

        [DataMember()]
        public List<ExportItem> exportDatas = new List<ExportItem>();

        public bool CanExportData
        {
            get
            {
                return !string.IsNullOrEmpty(this.Host) &&
                    !string.IsNullOrEmpty(this.Port) &&
                    !string.IsNullOrEmpty(this.User) &&
                    !string.IsNullOrEmpty(this.Password) &&
                    !string.IsNullOrEmpty(this.Database);
            }
        }

        [DataMember()]
        public string NullString { get; set; } = "[null]";

        [DataMember()]
        public string WinMergeUPath { get; set; } = string.Empty;

        public bool CanDiff
        {
            get
            {
                return !string.IsNullOrEmpty(this.WinMergeUPath) && File.Exists(this.WinMergeUPath);
            }
        }

        public void Load()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), CONFIG_FILE_NAME);
            if (!File.Exists(filePath))
            {
                return;
            }
            FileStream fs = new FileStream(filePath, FileMode.Open);
            XmlDictionaryReader reader =
                XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
            DataContractSerializer ser = new DataContractSerializer(typeof(Config));

            // Deserialize the data and read it from the instance.
            Current = (Config?)ser.ReadObject(reader, true) ?? new Config();
            reader.Close();
            fs.Close();
        }

        public void Save()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), CONFIG_FILE_NAME);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            FileStream fs = new FileStream(filePath, FileMode.Create);
            DataContractSerializer ser = new DataContractSerializer(typeof(Config));
            ser.WriteObject(fs, this);
            fs.Close();
        }
    }

    [DataContract(Name = "ExportItem")]
    public class ExportItem
    {
        [DataMember()]
        public String Name { get; private set; }
        
        [DataMember()]
        public String Query { get; private set; }

        public ExportItem(string name, string query)
        {
            this.Name = name;
            this.Query = query;

        }
    }
}
