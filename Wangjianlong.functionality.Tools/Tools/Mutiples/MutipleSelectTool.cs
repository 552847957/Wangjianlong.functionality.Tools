using ESRI.ArcGIS.AnalysisTools;
using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wangjianlong.functionality.Tools.Common;

namespace Wangjianlong.functionality.Tools.Tools
{
    public class MutipleSelectTool:ITang
    {
        public string Description { get; }
        public string Error { get; set; }
        public int Count { get; set; }
        public IFeatureClass FeatureClass { get; set; }
        private string LayerName { get { return FeatureClass.AliasName; } }
        public string FieldName { get; set; }
        public string SaveFilePath { get; set; }
        private List<string> _messages { get; set; }
        public bool Init()
        {
            _messages = new List<string>();
            if (System.IO.File.Exists(SaveFilePath))
            {
                System.IO.File.Delete(SaveFilePath);
            }
            if (!ArcGISFileHelper.CreatePersonalDataBase(SaveFilePath))//创建数据库文件失败
            {
                return false;
            }
            if (FeatureClass != null)
            {
                var values = FeatureClass.GetUniqueValue(FieldName);
                var tool = new Select();
                foreach(var item in values)
                {
                    tool.in_features = FeatureClass;
                    tool.out_feature_class = string.Format("{0}\\{1}_{2}", SaveFilePath, LayerName, item);
                    tool.where_clause = string.Format("[{0}] = '{1}'", FieldName, item);
                    if (!GPHelper.Excute(tool))
                    {
                        _messages.Add(string.Format("执行{0}发生错误", tool.where_clause));
                    }

                }

                return true;
            }
            return false;
        }
    }
}
