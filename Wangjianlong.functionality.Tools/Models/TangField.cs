using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wangjianlong.functionality.Tools.Models
{
    public class TangField
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public esriFieldType Type { get; set; }
        public int Index { get; set; }
    }
}
