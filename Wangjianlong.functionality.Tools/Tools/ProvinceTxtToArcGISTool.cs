using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Wangjianlong.functionality.Tools.Common;

namespace Wangjianlong.functionality.Tools.Tools
{
    public class ProvinceTxtToArcGISTool:DialogClass
    {
        private static object missing = Type.Missing;
        private string _txtFilePath { get; set; }
        public string TxtFilePath { get { return _txtFilePath; }set { _txtFilePath = value; } }
        private string _saveFilePath { get; set; }
        public string SaveFilePath { get { return _saveFilePath; }set { _saveFilePath = value; } }
        private List<string> _errors { get; set; }
        public List<string> Errors { get { return _errors; } }
        private IFeatureClass _featureClass { get; set; }
        private IFeatureCursor _featureCursor { get; set; }
        public ProvinceTxtToArcGISTool()
        {
            _errors = new List<string>();
        }

        private bool Init()
        {
            if (!System.IO.File.Exists(_txtFilePath))
            {
                _errors.Add(string.Format("路径：\"{0}\"文件不存在，请核对！", _txtFilePath));
                return false;
            }

            if (System.IO.File.Exists(_saveFilePath))
            {
                System.IO.File.Delete(_saveFilePath);
            }
            _featureClass = FeatureClassManager.CreateFeatrueClass(_saveFilePath, SpatialReferenceManager.Get40SpatialReference(), ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon);
            if (_featureClass == null)
            {
                _errors.Add("创建要素类失败");
                return false;
            }
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
                Finish();
                return false;
            }

            using(var reader =new StreamReader(_txtFilePath, Encoding.GetEncoding("GB2312")))
            {
                var line = reader.ReadLine();
                var tokens = new string[] { "", "", "", "", "", "" };
                var row = 1;
                var polygon = new PolygonClass();
                var ring = new RingClass();
                var pc = ring as IPointCollection;
                var first = string.Empty;
                IGeometryCollection resultPolygon = new PolygonClass();
                while (line != null && !string.IsNullOrEmpty(line))
                {
                    line = line.Trim();

                    tokens = line.Split(',');
                    if (tokens.Length != 6)
                    {
                        _errors.Add(string.Format("文件第{0}行格式不正确", row));
                        line = reader.ReadLine();
                        row++;
                        continue;
                    }

                    IPoint pt = new PointClass();
                    double x, y;
                    if((!double.TryParse(tokens[4],out y)||!double.TryParse(tokens[5],out x)) || x < 40000000 || x > 41000000 || y < 2000000 || y > 4000000)
                    {
                        _errors.Add(string.Format("文件第{0}行的格式有误，坐标应为数字类型", row));
                        polygon = new PolygonClass();
                        pc = polygon as IPointCollection;
                        break;
                    }
                    pt.X = x;
                    pt.Y = y;
                    pc.AddPoint(pt, ref missing, ref missing);

                    var temp = string.Format("{0},{1}", tokens[4], tokens[5]);
                    if (string.IsNullOrEmpty(first))
                    {
                        first = temp;
                    }
                    else
                    {
                        if (first == temp)
                        {
                            if (pc.PointCount > 0)
                            {
                                if (pc.PointCount < 4)
                                {
                                    _errors.Add(string.Format("文件第{0}行之前的坐标串有误，多边形顶点数不应少于4个", row));
                                    ring = new RingClass();
                                    pc = ring as IPointCollection;
                                    break;
                                }
                                else
                                {
                                    polygon.AddGeometry(ring, ref missing, ref missing);
                                }
                            }
                            if (polygon.GeometryCount > 0)
                            {
                                polygon.ITopologicalOperator2_IsKnownSimple_2 = false;
                                (polygon as ITopologicalOperator2).Simplify();
                                polygon.GeometriesChanged();
                                resultPolygon.AddGeometryCollection(polygon as IGeometryCollection);
                            }
                            polygon = new PolygonClass();
                            ring = new RingClass();
                            pc = polygon as IPointCollection;
                            first = string.Empty;
                        }
                    }
                    line = reader.ReadLine();
                    row++;
                }

                if (pc.PointCount > 0)
                {
                    if (pc.PointCount < 4)
                    {
                        _errors.Add(string.Format("文件第{0}行之前的坐标串有误，多边形顶点不应少于4个", row));
                    }
                    else
                    {
                        polygon.AddGeometry(ring, ref missing, ref missing);
                    }

                    if (polygon.GeometryCount > 0)
                    {
                        polygon.ITopologicalOperator2_IsKnownSimple_2 = false;
                        (polygon as ITopologicalOperator2).Simplify();
                        polygon.GeometriesChanged();
                        resultPolygon.AddGeometryCollection(polygon as IGeometryCollection);
                    }
                }

                if (resultPolygon.GeometryCount > 0)
                {
                    try
                    {
                        var buffer = _featureClass.CreateFeatureBuffer();
                        ITopologicalOperator top = resultPolygon as ITopologicalOperator;
                        top.Simplify();
                        buffer.Shape = resultPolygon as IPolygon;
                        _featureCursor.InsertFeature(buffer);

                    }catch(Exception ex)
                    {
                        System.Diagnostics.Trace.WriteLine(ex);
                    }
                }
            }
            Finish();
            return true;
        }
    }
}
