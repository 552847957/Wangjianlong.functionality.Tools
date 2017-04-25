using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wangjianlong.functionality.Tools.Common;
using Wangjianlong.functionality.Tools.Models;

namespace Wangjianlong.functionality.Tools.Tools
{
    public class TxtToArcGISTool:DialogClass
    {
        private string _txtFilePath { get; set; }
        public string TxtFilePath { get { return _txtFilePath; }set { _txtFilePath = value; } }
        private string _saveFilePath { get; set; }
        public string SaveFilePath { get { return _saveFilePath; }set { _saveFilePath = value; } }
        private List<string> _errors { get; set; }
        public List<string> Errors { get { return _errors; } }
        private IFeatureClass _featureClass { get; set; }
        private IFeatureCursor _featureCursor { get; set; }
        public TxtToArcGISTool()
        {
            _errors = new List<string>();
        }

        private bool Init()
        {
            if (!System.IO.File.Exists(_txtFilePath))
            {
                _errors.Add(string.Format("路径：\"{0}\"文件不存在，请核对文件！", _txtFilePath));
                return false;
            }
            if (System.IO.File.Exists(_saveFilePath))
            {
                System.IO.File.Delete(_saveFilePath);
            }
            _featureClass = FeatureClassManager.CreateFeatrueClass(_saveFilePath, SpatialReferenceManager.Get40SpatialReference(), ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon);
            if (_featureClass == null)
            {
                _errors.Add("创建要素类失败！");
                return false;
            }
            _featureClass.AddFields(new List<Models.TangField> {
                new TangField { Name = "XMLX", Alias = "项目类型", Type = esriFieldType.esriFieldTypeString },
                new TangField { Name = "BZ", Alias = "备注", Type = esriFieldType.esriFieldTypeString },
                new TangField { Name = "NF", Alias = "年份", Type = esriFieldType.esriFieldTypeString },
                new TangField { Name = "FILENAME", Alias = "文件名字", Type = esriFieldType.esriFieldTypeString },
                new TangField { Name = "DKBH", Alias = "地块编号", Type = esriFieldType.esriFieldTypeString },
                new TangField { Name = "DKMC", Alias = "地块名称", Type = esriFieldType.esriFieldTypeString },
                new TangField { Name = "JLTXSX", Alias = "JLTXSX", Type = esriFieldType.esriFieldTypeString },
                new TangField { Name = "TFH", Alias = "TFH", Type = esriFieldType.esriFieldTypeString },
                new TangField { Name = "DKYT", Alias = "地块用途", Type = esriFieldType.esriFieldTypeString },
                new TangField { Name = "DLBM", Alias = "地类编码", Type = esriFieldType.esriFieldTypeString }});
            _featureCursor = _featureClass.Insert(true);
            return true;
        }
        private void Finish()
        {
            ProgressDialog.HideDialog();
            if (_featureCursor != null)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(_featureCursor);
            }
        }

        public override bool Work()
        {
            base.Work();
            if (!Init())
            {

            }
            return true;
        }
    }
}
