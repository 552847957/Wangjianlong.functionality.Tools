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
    /// 作用：提取多个CAD文件的Polyline图层合成一个Polyline的shapeFile文件
    /// 作者：汪建龙
    /// 编写时间：2016年11月22日19:30:44
    /// </summary>
    public class ExtractCADsToOnePolylineTool
    {
        /// <summary>
        /// CAD文件列表
        /// </summary>
        public List<string> CADFiles { get; set; }
        /// <summary>
        /// 合成的Polyline的SHP文件路径
        /// </summary>
        public string PolylineFile { get; set; }

        private IFeatureClass _polylineFeatureClass { get; set; }
        /// <summary>
        /// 提取条件
        /// </summary>
        public string WhereClause { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        private string _error { get; set; }
        private List<string> _errorList { get; set; }
        public string Error { get { return  _error+string.Join(";",_errorList.ToArray()); } }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        private bool Init()
        {
            if (CADFiles == null || CADFiles.Count == 0)
            {
                _error += "CAD文件列表为空;";
                return false;
            }
            if (System.IO.File.Exists(PolylineFile))
            {
                System.IO.File.Delete(PolylineFile);
            }
            var first = CADFiles[0];
            var featureClass = CADManager.GetFeatureClass(first);
            if (featureClass == null)
            {
                _error += string.Format("读取到的文件：{0}  无法读取信息;", System.IO.Path.GetFileNameWithoutExtension(first));
                return false;
            }
            ISpatialReference spatialReference = SpatialReferenceManager.GetSpatialReference(featureClass);

            _polylineFeatureClass = FeatureClassManager.CreateFeatrueClass(PolylineFile, spatialReference, esriGeometryType.esriGeometryPolyline);
            if (_polylineFeatureClass == null)
            {
                _error += string.Format("创建shapefile文件：{0}  失败!", PolylineFile);
                return false;
            }
            _errorList = new List<string>();
            return true;
        }
        public bool Work()
        {
            if (Init())
            {
                foreach(var item in CADFiles)
                {
                    var tool = new ExtractCADToPolylineTool()
                    {
                        CADFile = item,
                        PolylineFeatureClass = _polylineFeatureClass,
                        WhereCluase = WhereClause
                    };
                    if (!tool.Work())
                    {
                        _errorList.Add(string.Format("在分析：{0} 发生错误：{1}", System.IO.Path.GetFileNameWithoutExtension(item), tool.Error));
                    }
                }
                return _errorList.Count == 0;
            }
            return false;
        }
    }
}
