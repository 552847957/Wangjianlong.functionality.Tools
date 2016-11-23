using ESRI.ArcGIS.ConversionTools;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wangjianlong.functionality.Tools.Common;

namespace Wangjianlong.functionality.Tools.Tools
{
    /// <summary>
    /// 作用：将一个CAD文件的Polyline单独提取到FeatureClass
    /// </summary>
    public class ExtractCADToPolylineTool
    {
        /// <summary>
        /// CAD文件路径
        /// </summary>
        public string CADFile { get; set; }
        /// <summary>
        /// 提取到的FeatureClass
        /// </summary>
        public IFeatureClass PolylineFeatureClass { get; set; }
        /// <summary>
        /// 提取条件
        /// </summary>
        public string WhereCluase { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        private string _error { get; set; }
        public string Error { get { return _error; } }
        private IFeatureClass _featureClass { get; set; }
        private readonly string TCMC = "TCMC";
        /// <summary>
        /// TCMC 序号
        /// </summary>
        private int _index { get; set; }
        public bool Init()
        {
            if (!System.IO.File.Exists(CADFile))
            {
                _error += string.Format("文件：{0}不存在", CADFile);
                return false;
            }
            _featureClass = CADManager.GetFeatureClass(CADFile);
            if (_featureClass == null)
            {
                _error += string.Format("无法读取文件：{0}", CADFile);
                return false;
            }
            _index = PolylineFeatureClass.Fields.FindField(TCMC);
            return true;
        }

        public bool Work()
        {
            if (!Init())
            {
                return false;
            }
            string fileName = System.IO.Path.GetFileNameWithoutExtension(CADFile);

            IFeatureCursor cursor = PolylineFeatureClass.Insert(true);

            IQueryFilter queryFilter = new QueryFilterClass();
            queryFilter.WhereClause = WhereCluase;
            IFeatureCursor featureCursor = _featureClass.Search(queryFilter, false);
            IFeature feature = featureCursor.NextFeature();
            while (feature != null)
            {
                var buffer = PolylineFeatureClass.CreateFeatureBuffer();
                var copy = feature.ShapeCopy;
                var aw = copy as IZAware;
                if (aw.ZAware == true)
                {
                    aw.ZAware = false;
                }
                buffer.Shape = copy;
                if (_index > -1)
                {
                    buffer.set_Value(_index, fileName);
                }
                try
                {
                    object featureOID = cursor.InsertFeature(buffer);
                    cursor.Flush();
                }catch(Exception ex)
                {
                    _error += string.Format("存在保存到总FeatureCLass错误，错误信息：{0}", ex.ToString());
                }
                feature = featureCursor.NextFeature();
            }

            System.Runtime.InteropServices.Marshal.ReleaseComObject(cursor);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(featureCursor);

            return string.IsNullOrEmpty(_error);
        }

    }
}
