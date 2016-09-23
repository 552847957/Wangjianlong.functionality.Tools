using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wangjianlong.functionality.Tools.Common;

namespace Wangjianlong.functionality.Tools.Tools
{
    public class CADPolylineToPolygonTool:DialogClass,ITang
    {
        public override string Description
        {
            get
            {
                return "将CAD_Polyline文件转换成Polygon";
            }
        }
        public string Error { get; set; }
        public int Count { get; set; }
        public string CADFilePath { get; set; }
        public string SaveFilePath { get; set; }
        public List<string> Layers { get; set; }
        private IFeatureClass FeatureClass { get; set; }
        public bool Init()
        {
            FeatureClass = CADFilePath.GetShpFeatureClass();
            if (FeatureClass == null)
            {
                Error += string.Format("无法打开shapefile文件:{0}",CADFilePath);
                return false;
            }

            return true;
        }
        public override bool Work()
        {
            base.Work();
            
            return true;
        }

    }
}
