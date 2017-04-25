using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Wangjianlong.functionality.Tools.Common;
using Wangjianlong.functionality.Tools.Models;

namespace Wangjianlong.functionality.Tools.Tools
{
    public class MutipleTxtToArcGISTool:DialogClass
    {
        private static object missing = System.Type.Missing;
        private string _txtFilePath { get; set; }
        public string TxtFilePath { get { return _txtFilePath; }set { _txtFilePath = value; } }
        private string _folder { get; set; }
        /// <summary>
        /// 目录
        /// </summary>
        public string Folder { get { return _folder; }set { _folder = value; } }
        private string _message { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string Message { get { return _message; }set { _message = value; } }
        private string _saveFilePath { get; set; }
        /// <summary>
        /// 输出保存文件路径
        /// </summary>
        public string SaveFilePath { get { return _saveFilePath; }set { _saveFilePath = value; } }
        private List<string> _txtFiles { get; set; }
        private List<string> _errors { get; set; }

        private IFeatureClass _featureClass { get; set; }
        public IFeatureClass FeatureClass { get { return _featureClass; }set { _featureClass = value; } }
        private IFeatureCursor _featureCursor { get; set; }

        public MutipleTxtToArcGISTool()
        {
            _txtFiles = new List<string>();
            _errors = new List<string>();
        }
        private bool Init()
        {
            if (!Directory.Exists(_folder))
            {
                _message += string.Format("目录：\"{0}\"不存在，请核对目录！", _folder);
                return false;
            }
            _txtFiles = FileManager.GetSpecialFiles(_folder, "*.txt");
            if (string.IsNullOrEmpty(_saveFilePath) || System.IO.File.Exists(_saveFilePath))
            {
                _message += string.Format("保存路径：\"{0}\"不正确或者已存在文件,请核对保存路径！", _saveFilePath);
                return false;
            }
            _featureClass = FeatureClassManager.CreateFeatrueClass(_saveFilePath, SpatialReferenceManager.Get40SpatialReference(), ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon);
            if (_featureClass == null)
            {
                _message += string.Format("创建要素类失败！");
                return false;
            }
            _featureClass.AddFields(new List<TangField> {
                new TangField { Name = "XMLX", Alias = "项目类型", Type = esriFieldType.esriFieldTypeString },
                new TangField { Name = "BZ", Alias = "备注", Type = esriFieldType.esriFieldTypeString },
                new TangField { Name = "NF", Alias = "年份", Type = esriFieldType.esriFieldTypeString },
                new TangField { Name = "FILENAME", Alias = "文件名字", Type = esriFieldType.esriFieldTypeString },
                new TangField { Name = "DKBH", Alias = "地块编号", Type = esriFieldType.esriFieldTypeString },
                new TangField { Name = "DKMC", Alias = "地块名称", Type = esriFieldType.esriFieldTypeString },
                new TangField { Name = "JLTXSX", Alias = "JLTXSX", Type = esriFieldType.esriFieldTypeString },
                new TangField { Name = "TFH", Alias = "TFH", Type = esriFieldType.esriFieldTypeString },
                new TangField { Name = "DKYT", Alias = "地块用途", Type = esriFieldType.esriFieldTypeString },
                new TangField { Name = "DLBM", Alias = "地类编码", Type = esriFieldType.esriFieldTypeString } });
            _featureCursor = FeatureClass.Insert(true);
            return true; 
        }
        public void Finish()
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

            var current = 1;
            foreach(var item in _txtFiles)
            {
                StepProgressor.Message = string.Format("{0}/{1}——正在分析读取文件：{2}", current++, _txtFiles.Count, System.IO.Path.GetFileNameWithoutExtension(item));
                CanContinue = TrackCancel.Continue();
                if (!CanContinue)
                {
                    break;
                }
                //#region  方法二
                //using (var reader = new StreamReader(item, Encoding.GetEncoding("GB2312")))
                //{
                //    var line = reader.ReadLine();
                //    var begin = false;
                //    var polygon = new PolygonClass();
                //    var ring = new RingClass();
                //    var pc = ring as IPointCollection;
                //    var ringId = string.Empty;
                //    var lastTokens = new[] { "", "", "", "", "", "", "", "", "" };
                //    var row = 1;
                //    var pgCount = 0;
                //    var ext = false;
                //    var list = new List<IPoint>();
                //    while (line != null)
                //    {
                //        line = line.Trim();
                //        if (line == "[地块坐标]")
                //        {
                //            begin = true;
                //            line = reader.ReadLine();
                //            row++;
                //            ext = true;
                //            continue;
                //        }

                //        if (begin && !string.IsNullOrEmpty(line))
                //        {
                //            string[] tokens = line.Split(',');
                //            if (tokens[tokens.Length - 1] == "@")
                //            {
                //                #region
                //                if (tokens.Length != 9)
                //                {
                //                    _errors.Add(string.Format("文件第{0}行的格式有误，字段数量应为9", row));
                //                    break;
                //                }
                //                if (pc.PointCount > 0)
                //                {
                //                    if (pc.PointCount < 4)
                //                    {
                //                        _errors.Add(string.Format("文件第{0}行之前的坐标串有误，多边形顶点数不应少于4个", row));
                //                        ring = new RingClass();
                //                        pc = ring as IPointCollection;
                //                        break;
                //                    }
                //                    else
                //                    {
                //                        polygon.AddGeometry(ring, ref missing, ref missing);

                //                    }
                //                }

                //                //if (polygon.GeometryCount > 0)
                //                //{
                //                //    var buffer = FeatureClass.CreateFeatureBuffer();
                //                //    polygon.ITopologicalOperator2_IsKnownSimple_2 = false;
                //                //    (polygon as ITopologicalOperator2).Simplify();
                //                //    polygon.GeometriesChanged();
                //                //    buffer.Shape = polygon;
                //                //    buffer.set_Value(buffer.Fields.FindField("FILENAME"), System.IO.Path.GetFileName(item));
                //                //    buffer.set_Value(buffer.Fields.FindField("DKBH"), lastTokens[2]);
                //                //    buffer.set_Value(buffer.Fields.FindField("DKMC"), lastTokens[3]);
                //                //    buffer.set_Value(buffer.Fields.FindField("JLTXSX"), lastTokens[4]);
                //                //    buffer.set_Value(buffer.Fields.FindField("TFH"), lastTokens[5]);
                //                //    buffer.set_Value(buffer.Fields.FindField("DKYT"), lastTokens[6]);
                //                //    buffer.set_Value(buffer.Fields.FindField("DLBM"), lastTokens[7]);
                //                //    // FeatureCursor.InsertFeature(buffer);
                //                //    _featureCursor.InsertFeature(buffer);
                //                //    pgCount++;
                //                //}
                //                #endregion
                //                lastTokens = tokens;
                //            }
                //            else
                //            {
                //                #region
                //                if (tokens.Length == 4)
                //                {
                //                    IPoint pt = new PointClass();
                //                    double x, y;
                //                    if ((!double.TryParse(tokens[2], out y) || !double.TryParse(tokens[3], out x)) || x < 40000000 || x > 41000000 || y < 2000000 || y > 4000000)
                //                    {
                //                        _errors.Add(string.Format("文件第{0}行的格式有误，坐标应为数字类型", row));
                //                        polygon = new PolygonClass();
                //                        pc = polygon as IPointCollection;
                //                        break;
                //                    }
                //                    pt.X = x;
                //                    pt.Y = y;
                //                    pc.AddPoint(pt, ref missing, ref missing);
                //                    list.Add(pt);
                //                }
                //                else
                //                {
                //                    _errors.Add(string.Format("文件第{0}行的格式有误，字段数量应为4", row));
                //                    polygon = new PolygonClass();
                //                    ring = new RingClass();
                //                    pc = ring as IPointCollection;
                //                    break;
                //                }
                //                #endregion
                //            }
                //        }
                //        line = reader.ReadLine();
                //        row++;
                //    }

                //    try
                //    {
                //        IGeometryBridge2 geometryBridge2 = new GeometryEnvironmentClass();
                //        IPointCollection4 pcollection = new PolygonClass();
                //        WKSPoint[] wksPoint = new WKSPoint[list.Count];
                //        for (var i = 0; i < list.Count; i++)
                //        {
                //            var temp = list[i];
                //            wksPoint[i].X = temp.X;
                //            wksPoint[i].Y = temp.Y;
                //        }

                //        geometryBridge2.SetWKSPoints(pcollection, ref wksPoint);
                //        IPolygon poly = pcollection as IPolygon;
                //        poly.Close();

                //        var buffer = FeatureClass.CreateFeatureBuffer();
                //        buffer.Shape = poly;
                //        buffer.set_Value(buffer.Fields.FindField("FILENAME"), System.IO.Path.GetFileName(item));
                //        buffer.set_Value(buffer.Fields.FindField("DKBH"), lastTokens[2]);
                //        buffer.set_Value(buffer.Fields.FindField("DKMC"), lastTokens[3]);
                //        buffer.set_Value(buffer.Fields.FindField("JLTXSX"), lastTokens[4]);
                //        buffer.set_Value(buffer.Fields.FindField("TFH"), lastTokens[5]);
                //        buffer.set_Value(buffer.Fields.FindField("DKYT"), lastTokens[6]);
                //        buffer.set_Value(buffer.Fields.FindField("DLBM"), lastTokens[7]);
                //        _featureCursor.InsertFeature(buffer);

                //    }
                //    catch(Exception ex)
                //    {
                //        System.Diagnostics.Trace.WriteLine(ex);
                //    }




                //    //if (pc.PointCount > 0)
                //    //{
                //    //    if (pc.PointCount < 4)
                //    //    {
                //    //        _errors.Add(string.Format("文件第{0}行之前的坐标串有误，多边形顶点不应少于4个", row));
                //    //    }
                //    //    else
                //    //    {
                //    //        polygon.AddGeometry(ring, ref missing, ref missing);
                //    //    }
                //    //}
                //    //if (polygon.GeometryCount > 0)
                //    //{
                //    //    #region
                //    //    try
                //    //    {
                //    //        var buffer = FeatureClass.CreateFeatureBuffer();
                //    //        polygon.ITopologicalOperator2_IsKnownSimple_2 = false;
                //    //        (polygon as ITopologicalOperator2).Simplify();
                //    //        polygon.GeometriesChanged();
                //    //        buffer.Shape = polygon;
                //    //        buffer.set_Value(buffer.Fields.FindField("FILENAME"), System.IO.Path.GetFileName(item));
                //    //        buffer.set_Value(buffer.Fields.FindField("DKBH"), lastTokens[2]);
                //    //        buffer.set_Value(buffer.Fields.FindField("DKMC"), lastTokens[3]);
                //    //        buffer.set_Value(buffer.Fields.FindField("JLTXSX"), lastTokens[4]);
                //    //        buffer.set_Value(buffer.Fields.FindField("TFH"), lastTokens[5]);
                //    //        buffer.set_Value(buffer.Fields.FindField("DKYT"), lastTokens[6]);
                //    //        buffer.set_Value(buffer.Fields.FindField("DLBM"), lastTokens[7]);
                //    //        _featureCursor.InsertFeature(buffer);
                //    //        pgCount++;
                //    //    }
                //    //    catch (Exception ex)
                //    //    {
                //    //        _errors.Add(string.Format("导入第{0}个地块时发生错误：{1}", pgCount, ex.Message));
                //    //    }
                //    //    #endregion
                //    //}
                //}
                //#endregion

                #region  方法一
                

                using (var reader = new StreamReader(item, Encoding.GetEncoding("GB2312")))
                {
                    var line = reader.ReadLine();
                    var begin = false;
                    var polygon = new PolygonClass();
                    IGeometryCollection resultPolygon = new PolygonClass();
                    var ring = new RingClass();
                    var pc = ring as IPointCollection;
                    var ringId = string.Empty;
                    var lastTokens = new[] { "", "", "", "", "", "", "", "", "" };
                    var row = 1;
                    var pgCount = 0;
                    var ext = false;
                    while (line != null)
                    {
                        line = line.Trim();
                        if (line == "[地块坐标]")
                        {
                            begin = true;
                            line = reader.ReadLine();
                            row++;
                            ext = true;
                            continue;
                        }

                        if (begin && !string.IsNullOrEmpty(line))
                        {
                            string[] tokens = line.Split(',');
                            if (tokens[tokens.Length - 1] == "@")
                            {
                                #region
                                if (tokens.Length != 9)
                                {
                                    _errors.Add(string.Format("文件第{0}行的格式有误，字段数量应为9", row));
                                    break;
                                }
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
                                        ring = new RingClass();
                                        pc = ring as IPointCollection;
                                    }
                                }
                                if (polygon.GeometryCount > 0)
                                {
                                    polygon.ITopologicalOperator2_IsKnownSimple_2 = false;
                                    (polygon as ITopologicalOperator2).Simplify();
                                    polygon.GeometriesChanged();
                                    resultPolygon.AddGeometryCollection(polygon as IGeometryCollection);
                                }

                                //if (polygon.GeometryCount > 0)
                                //{
                                //    var buffer = FeatureClass.CreateFeatureBuffer();
                                //    polygon.ITopologicalOperator2_IsKnownSimple_2 = false;
                                //    (polygon as ITopologicalOperator2).Simplify();
                                //    polygon.GeometriesChanged();
                                //    buffer.Shape = polygon;
                                //    buffer.set_Value(buffer.Fields.FindField("FILENAME"), System.IO.Path.GetFileName(item));
                                //    buffer.set_Value(buffer.Fields.FindField("DKBH"), lastTokens[2]);
                                //    buffer.set_Value(buffer.Fields.FindField("DKMC"), lastTokens[3]);
                                //    buffer.set_Value(buffer.Fields.FindField("JLTXSX"), lastTokens[4]);
                                //    buffer.set_Value(buffer.Fields.FindField("TFH"), lastTokens[5]);
                                //    buffer.set_Value(buffer.Fields.FindField("DKYT"), lastTokens[6]);
                                //    buffer.set_Value(buffer.Fields.FindField("DLBM"), lastTokens[7]);
                                //    // FeatureCursor.InsertFeature(buffer);
                                //    _featureCursor.InsertFeature(buffer);
                                //    pgCount++;
                                //}
                                #endregion
                                lastTokens = tokens;
                            }
                            else
                            {
                                #region
                                if (tokens.Length == 4)
                                {
                                    IPoint pt = new PointClass();
                                    double x, y;
                                    if (tokens[1] != ringId)
                                    {
                                        if (pc.PointCount > 0)
                                        {
                                            polygon.AddGeometry(ring, ref missing, ref missing);
                                            //resultPolygon.AddGeometryCollection(ring as IGeometryCollection);
                                        }
                                        ring = new RingClass();
                                        pc = ring as IPointCollection;
                                        ringId = tokens[1];
                                    }

                                    if ((!double.TryParse(tokens[2], out y) || !double.TryParse(tokens[3], out x)) || x < 40000000 || x > 41000000 || y < 2000000 || y > 4000000)
                                    {
                                        _errors.Add(string.Format("文件第{0}行的格式有误，坐标应为数字类型", row));
                                        polygon = new PolygonClass();
                                        pc = polygon as IPointCollection;
                                        break;
                                    }
                                    pt.X = x;
                                    pt.Y = y;
                                    pc.AddPoint(pt, ref missing, ref missing);
                                }
                                else
                                {
                                    _errors.Add(string.Format("文件第{0}行的格式有误，字段数量应为4", row));
                                    polygon = new PolygonClass();
                                    ring = new RingClass();
                                    pc = ring as IPointCollection;
                                    break;
                                }
                                #endregion
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
                            ring = new RingClass();
                            pc = ring as IPointCollection;
                            //resultPolygon.AddGeometryCollection(ring as IGeometryCollection);
                        }
                    }
                    if (polygon.GeometryCount > 0)
                    {
                        #region
                        try
                        {
                            var buffer = FeatureClass.CreateFeatureBuffer();
                            polygon.ITopologicalOperator2_IsKnownSimple_2 = false;
                            (polygon as ITopologicalOperator2).Simplify();
                            polygon.GeometriesChanged();

                            resultPolygon.AddGeometryCollection(polygon as IGeometryCollection);
                            ITopologicalOperator top = resultPolygon as ITopologicalOperator;
                            top.Simplify();
                           // buffer.Shape = resultPolygon as IPolygon;
                            buffer.Shape = resultPolygon as IPolygon;
                            buffer.set_Value(buffer.Fields.FindField("FILENAME"), System.IO.Path.GetFileName(item));
                            buffer.set_Value(buffer.Fields.FindField("DKBH"), lastTokens[2]);
                            buffer.set_Value(buffer.Fields.FindField("DKMC"), lastTokens[3]);
                            buffer.set_Value(buffer.Fields.FindField("JLTXSX"), lastTokens[4]);
                            buffer.set_Value(buffer.Fields.FindField("TFH"), lastTokens[5]);
                            buffer.set_Value(buffer.Fields.FindField("DKYT"), lastTokens[6]);
                            buffer.set_Value(buffer.Fields.FindField("DLBM"), lastTokens[7]);
                            _featureCursor.InsertFeature(buffer);
                            pgCount++;
                        }
                        catch (Exception ex)
                        {
                            _errors.Add(string.Format("导入第{0}个地块时发生错误：{1}", pgCount, ex.Message));
                        }
                        #endregion
                    }
                }
                #endregion
            }

            Finish();
            return true;
        }
    }
}
