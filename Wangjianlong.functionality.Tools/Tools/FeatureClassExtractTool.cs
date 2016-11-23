using ESRI.ArcGIS.ConversionTools;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geoprocessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wangjianlong.functionality.Tools.Tools
{
    public class FeatureClassExtractTool
    {
        public IFeatureClass FeatureClass { get; set; }

        public string WhereClause { get; set; }

        public string SaveFilePath { get; set; }
        private string _error { get; set; }

        public string Error { get { return _error; } }

        public bool Analyze()
        {
            
            FeatureClassToFeatureClass tool = new FeatureClassToFeatureClass();
            tool.in_features = FeatureClass;
            tool.out_path = System.IO.Path.GetDirectoryName(SaveFilePath);
            tool.out_name = System.IO.Path.GetFileName(SaveFilePath);
            tool.where_clause = WhereClause;
            Geoprocessor gp = new Geoprocessor();
           
            try
            {
                gp.Execute(tool, null);
            }
            catch(Exception ex)
            {
                _error = string.Format("Message:{0};InnerException:{1}", ex.Message, ex.InnerException);
                return false;
            }
            return true;
        
        }
    }
}
