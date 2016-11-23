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
    /// 作用：将Polyline转换成Polygon
    /// 作者：汪建龙
    /// 编写时间：2016年11月22日20:37:42
    /// </summary>
    public class ExtractCADPolylineToPolygonTool
    {
       

        public string PolylineFile { get; set; }

        public string PolygonFile { get; set; }

        private string _error { get; set; }

        public string Error { get { return _error; } }

        private IFeatureClass _polylineFeatureClass { get; set; }

        private IFeatureClass _polygonFeatureClass { get; set; }

        public bool Init()
        {
            if (!System.IO.File.Exists(PolylineFile))
            {
                _error += string.Format("文件：{0} 不存在", PolylineFile);
                return false;
            }
            _polylineFeatureClass = PolylineFile.GetShpFeatureClass();
            if (_polylineFeatureClass == null)
            {
                _error += string.Format("无法读取文件：{0}", PolylineFile);
                return false;
            }
            ISpatialReference spatialReference = SpatialReferenceManager.GetSpatialReference(_polylineFeatureClass);
            if (System.IO.File.Exists(PolygonFile))
            {
                System.IO.File.Delete(PolygonFile);
            }
            _polygonFeatureClass = FeatureClassManager.CreateFeatrueClass(PolygonFile, spatialReference, esriGeometryType.esriGeometryPolygon);
            if (_polygonFeatureClass == null)
            {
                _error += string.Format("创建文件：{0}  失败", PolygonFile);
                return false;
            }
            return true;
        }

        public bool Work()
        {
            if (!Init())
            {
                return false;
            }
            IFeatureCursor cursor = _polygonFeatureClass.Insert(true);

            IFeatureCursor featurecursor = _polylineFeatureClass.Search(null, false);
            IFeature feature = featurecursor.NextFeature();
            while (feature != null)
            {
                if (PolylineManager.IsPolygon(feature))
                {
                    var pg = PolylineManager.GeneratePolygon(feature.ShapeCopy);
                    if (pg != null)
                    {
                        var buffer = _polygonFeatureClass.CreateFeatureBuffer();
                        buffer.Shape = pg;
                        for(var i = 0; i < feature.Fields.FieldCount; i++)
                        {
                            IField field = feature.Fields.get_Field(i);
                            if (field != null)
                            {
                                if (field.Name == "OID" || field.Name == "FID" || field.Name.ToUpper() == "SHAPE" || field.Name.ToUpper().Contains("SHAPE"))
                                {
                                    continue;
                                }
                                var val = feature.get_Value(i);
                                var index = buffer.Fields.FindField(field.Name);
                                if (index > -1)
                                {
                                    buffer.set_Value(index, val);
                                }
                            }
                        }

                        try
                        {
                            object featureOID = cursor.InsertFeature(buffer);
                            cursor.Flush();
                        }catch(Exception ex)
                        {
                            _error += string.Format("存在保存到总FeatureCLass错误，错误信息：{0}", ex.ToString());
                        }
                    }
                }
                feature = featurecursor.NextFeature();
            }
            System.Runtime.InteropServices.Marshal.ReleaseComObject(cursor);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(featurecursor);
            return string.IsNullOrEmpty(_error);
        }

  
    }
}
