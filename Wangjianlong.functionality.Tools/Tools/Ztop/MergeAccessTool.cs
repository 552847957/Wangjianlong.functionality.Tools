using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using Wangjianlong.functionality.Tools.Common;
using Wangjianlong.functionality.Tools.Models;

namespace Wangjianlong.functionality.Tools.Tools.Ztop
{
    public class MergeAccessTool:DialogClass,ITang
    {
        public override string Description
        {
            get
            {
                return "多个Access合成一个Access";
            }
        }
        public string Error { get; set; }
        public int Count { get; set; }
        

        private string _folder { get; set; }
        public string Folder { get { return _folder; }set { _folder = value; } }
        private string _saveFilePath { get; set; }
        public string SaveFilePath { get { return _saveFilePath; }set { _saveFilePath = value; } }
        private List<string> _files { get; set; }
        private const string _connectionStringBase = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
        private string[] _fields { get; set; }

        public bool Init()
        {
            if (!System.IO.Directory.Exists(_folder))
            {
                Error = "Access目录路径不存在，请核对!";
            }
            if (!System.IO.File.Exists(_saveFilePath))
            {
                Error += "保存文件路径不存在，请核对！";
            }
            _files = FileManager.GetSpecialFiles(_folder, "*.mdb");
            if (_files.Count == 0)
            {
                Error += "未获取文件及下面的mdb文件";
            }
            _fields = GainField(_saveFilePath,System.IO.Path.GetFileNameWithoutExtension(_saveFilePath)).ToArray();
            if (_fields.Length == 0)
            {
                Error += "未获取合成的access字段信息";
            }
            return string.IsNullOrEmpty(Error);
        }

        public override bool Work()
        {
            base.Work();
            if (!Init())
            {
                ProgressDialog.HideDialog();
                return false;
            }
            foreach(var item in _files)
            {
                Count++;
                StepProgressor.Message = string.Format("正在分析{0}，进度{1}/{2}", System.IO.Path.GetFileNameWithoutExtension(item), Count, _files.Count);
                CanContinue = TrackCancel.Continue();
                if (!CanContinue)
                {
                    break;
                }

               
                try
                {
                    var tables = GetTableNames(item);
                    if (tables.Count > 0)
                    {
                        foreach (var tableName in tables)
                        {
                            var fields = GainField(item, tableName);
                            var fieldList = new List<string>();
                            foreach (var a in _fields)
                            {
                                if (fields.Contains(a))
                                {
                                    fieldList.Add(a);
                                }
                            }
                            var temp = Prgram(item, tableName, fieldList.ToArray());
                            if (temp.Count > 0)
                            {
                                Save(temp, tableName, _saveFilePath);
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    Copy(item, _folder);
                }
               
                StepProgressor.Step();
               

            }
            ProgressDialog.HideDialog();
            return true;
        }

        private List<List<Field>> Prgram(string filePath,string tableName,string[] fields)
        {
            var connectionString = _connectionStringBase + filePath;
            var list = new List<List<Field>>();
            using (var connection=new OleDbConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = string.Format("Select {0} from [{1}]", string.Join(",", fields), tableName);
                    using (var reader = command.ExecuteReader())
                    {
                       
                        while (reader.Read())
                        {
                            var temp = new List<Field>();
                            for(var i = 0; i < fields.Length; i++)
                            {
                                var value = reader[i].ToString().Trim().Replace("\0","");
                                if (!string.IsNullOrEmpty(value))
                                {
                                    temp.Add(new Field
                                    {
                                        Name = fields[i],
                                        Value = string.Format("'{0}'",value)
                                    });
                                }
                            
                            }
                            list.Add(temp);
                        }
                       
                    }
                }
            }
            return list;
        }

        private void Save(List<List<Field>> list,string  sourceName,string saveFilePath)
        {
            var connectionString = _connectionStringBase + saveFilePath;
            var tableName = System.IO.Path.GetFileNameWithoutExtension(saveFilePath);
            using (var connection=new OleDbConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    foreach(var item in list)
                    {
                        if (item.Count > 0)
                        {
                            var fields = item.Select(e => e.Name).ToArray();
                            var values = item.Select(e => e.Value).ToArray();
                            command.CommandText = string.Format("insert into {0}({1},数据来源) values ({2},'{3}')", tableName, string.Join(",", fields), string.Join(",", values), sourceName);
                            var i = command.ExecuteNonQuery();
                            if (i != 1)
                            {
                                Error += string.Format("{0}插入数据失败");
                            }
                        }
                       
                    }
                   
                }
            }
        }

        private List<string> GetTableNames(string filePath)
        {
            var list = new List<string>();
            var connectionString = _connectionStringBase + filePath;
            using (var connection=new OleDbConnection(connectionString))
            {
                connection.Open();
                var dt = connection.GetSchema("Tables");
                foreach(DataRow row in dt.Rows)
                {
                    if (row[3].ToString() == "TABLE")
                    {
                        list.Add(row[2].ToString());
                    }
                }
            }

            return list;
        }

        private void Copy(string filePath,string folder)
        {
            var baseFolder = System.IO.Path.Combine(folder, "Error");
            if (!System.IO.Directory.Exists(baseFolder))
            {
                System.IO.Directory.CreateDirectory(baseFolder);
            }
            var destinationFile = System.IO.Path.Combine(baseFolder, System.IO.Path.GetFileName(filePath));
            System.IO.File.Copy(filePath, destinationFile, true);
        }


















        public List<string> GainField(string filePath,string tableName)
        {
            var connectionString = string.Format("{0}{1}", _connectionStringBase, filePath);
           // var tableName = System.IO.Path.GetFileNameWithoutExtension(filePath);
            var list = new List<string>();
            using (var connection=new OleDbConnection(connectionString))
            {
                connection.Open();
                var dt = new DataTable();
                dt = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, tableName, null });
                int n = dt.Rows.Count;
                string[] strTable = new string[n];
                int m = dt.Columns.IndexOf("COLUMN_NAME");
                for(var i = 0; i < n; i++)
                {
                    DataRow dr = dt.Rows[i];
                    var name = dr.ItemArray.GetValue(m).ToString();
                    if (name != "数据来源")
                    {
                        list.Add(name);
                    }
                   
                }
                connection.Close();
            }
            return list;
        }
    }
}
