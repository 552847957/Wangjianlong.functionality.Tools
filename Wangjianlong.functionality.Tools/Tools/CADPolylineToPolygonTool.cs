using ESRI.ArcGIS.AnalysisTools;
using ESRI.ArcGIS.DataManagementTools;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.Geoprocessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wangjianlong.functionality.Tools.Common;

namespace Wangjianlong.functionality.Tools.Tools
{
    public class CADPolylineToPolygonTool:DialogClass,ITang
    {
        private static string LayerField = "Layer";
        private static readonly double Threshold = 3;
        public override string Description
        {
            get
            {
                return "将CAD_Polyline文件转换成Polygon";
            }
        }
        private Geoprocessor gp { get; set; }
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
            MaxValue = Layers.Count;
            gp = new Geoprocessor();
            return true;
        }

        private void ExecuteProcess(IGPProcess gpProcess)
        {
            IGeoProcessorResult result = null;
            try
            {
                result = gp.Execute(gpProcess, null) as IGeoProcessorResult;

            }catch(Exception ex)
            {
                throw new ApplicationException("执行过程中出现错误：" + ex.Message, ex);
            }
            if (result == null || result.Status == ESRI.ArcGIS.esriSystem.esriJobStatus.esriJobFailed)
            {
                object srv = 2;
                throw new ApplicationException("执行过程中出现错误：" + gp.GetMessages(ref srv));
            }
        }

        private void Delete(string layerName)
        {
            var op = new Delete(layerName);
            try
            {
                ExecuteProcess(op);
            }
            catch
            {

            }
        }

        private void ConstructPolygon(string folder,string from,int index,string layerField,string layer)
        {
            var select = new Select
            {
                in_features = string.Format("{0}\\{1}.shp", folder, from),
                out_feature_class = string.Format("{0}\\{1}_{2}_1.shp", folder, from, index),
                where_clause = string.Format("{0} = '{1}'", layerField, layer)
            };
            ExecuteProcess(select);

            var array = new string[] { string.Format("{0}\\{1}_{2}_1.shp", folder, from, index) };
            var f2p = new FeatureToPolygon
            {
                in_features =string.Join(";",array),
                out_feature_class = string.Format("{0}\\{1}_{2}_2.shp", folder, from, index)
            };
           

            ExecuteProcess(f2p);

            var sj = new SpatialJoin
            {
                target_features = string.Format("{0}\\{1}_{2}_3.shp", folder, from, index),
                join_features = string.Format("{0}\\{1}_{2}_1.shp", folder, from, index),
                out_feature_class = string.Format("{0}\\{1}_{2}.shp", folder, from, index),
                join_operation = "JOIN_ONE_TO_ONE",
                join_type = "KEEP_ALL",
                match_option = "INTERSECTS",
                search_radius = "0 METERS"
            };
            ExecuteProcess(sj);

            Delete(string.Format("{0}\\{1}_{2}_1.shp", folder, from, index));
            Delete(string.Format("{0}\\{1}_{2}_2.shp", folder, from, index));
            Delete(string.Format("{0}\\{1}_{2}_3.shp", folder, from, index));

        }

        private string SelectPolyline(string folder,string from, int index,string layerField,string layer)
        {
            var output = string.Format("{0}\\{1}_{2}_1.shp", folder, from, index);
            var select = new Select
            {
                in_features = string.Format("{0}\\{1}.shp", folder, from),
                out_feature_class = output,
                where_clause = string.Format("{0} = '{1}'", layerField, layer)
            };
            ExecuteProcess(select);
            return output;
        }
        private void ContractPolygon(List<string> polylines,string outputFilePath)
        {
            var f2p = new FeatureToPolygon
            {
                in_features = string.Join(";", polylines.ToArray()),
                out_feature_class = outputFilePath
            };
            ExecuteProcess(f2p);
        }
        private void Merge(string folder,List<int> indices,string prefix)
        {
            var array = indices.Select(e => string.Format("{0}\\{1}_{2}.shp", folder, prefix, e)).ToArray();
            if (array.Length > 0)
            {
                var merge = new Merge
                {
                    inputs = string.Join(";", array),
                    output = SaveFilePath
                };
                ExecuteProcess(merge);
            }
        }
        private void Merge(List<string> files,string filePath)
        {
            

        }
        private bool IsPolygon(IFeature feature)
        {
            var geo = feature.Shape;
            if(geo is IPolyline && geo.IsEmpty == false)
            {
                var polyline = geo as IPolyline4;
                var pointCollection = polyline as IPointCollection;
                var startPoint = pointCollection.get_Point(0);
                var endPoint = pointCollection.get_Point(pointCollection.PointCount - 1);
                var x = endPoint.X - startPoint.X;
                var y = endPoint.Y - startPoint.Y;
                var distance = x * x + y * y;
                return distance < Threshold * Threshold;
            }
            return false;
        }
        private IPolygon GeneratePolygon(IGeometry pl)
        {
            if (pl.IsEmpty || (pl is IPolyline) == false) return null;
            var pc1 = (IPointCollection)pl;
            var pg = new PolygonClass();
            var pc2 = (IPointCollection)pg;
            for (var i = 0; i < pc1.PointCount; i++)
            {
                var pt = pc1.get_Point(i);
                var pt2 = new PointClass { X = pt.X, Y = pt.Y };
                pc2.AddPoint(pt2);
            }

            var pt3 = pc1.get_Point(0);
            var pt4 = new PointClass { X = pt3.X, Y = pt3.Y };
            pc2.AddPoint(pt4);
            pg.Simplify();
            return pg;
        }


        private bool TranslatePolylineToPolygon(string inputFilePath,string SaveFilePath,string layerName)
        {
            IFeatureClass featureClass = inputFilePath.GetShpFeatureClass();
            if (featureClass == null)
            {
                return false;
            }
            ISpatialReference spatialReference = SpatialReferenceManager.GetSpatialReference(featureClass);
            IFeatureClass createFeatureClass = FeatureClassManager.CreateFeatrueClass(SaveFilePath, spatialReference, esriGeometryType.esriGeometryPolygon);
            if (createFeatureClass == null)
            {
                return false;
            }
            var index = createFeatureClass.Fields.FindField("TCMC");
            if (index > -1)
            {
                var cursor2 = createFeatureClass.Insert(true);
                IFeatureCursor featureCursor = featureClass.Search(null, false);
                IFeature feature = featureCursor.NextFeature();
                while (feature != null)
                {
                    if (IsPolygon(feature))
                    {
                        var pg = GeneratePolygon(feature.ShapeCopy);
                        if (pg != null)
                        {
                            var buffer = createFeatureClass.CreateFeatureBuffer();
                            buffer.Shape = pg;
                            buffer.set_Value(index, layerName);
                            cursor2.InsertFeature(buffer);
                        }
                    }
                    feature = featureCursor.NextFeature();
                }
                cursor2.Flush();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(featureCursor);
            }
          
            return true;
        }


        public override bool Work()
        {
            base.Work();
            if (!Init())
            {
                ProgressDialog.HideDialog();
                Error = string.Format("初始化错误：{0}", Error);
                return false;
            }
            var list = new List<int>();
            var shps = new List<string>();
            for(var i = 0; i < Layers.Count; i++)
            {
                StepProgressor.Message = string.Format("正在对图层：{0}进行分析", Layers[i]);
                CanContinue = TrackCancel.Continue();
                if (!CanContinue)
                {
                    break;
                }
                try
                {
                    // ConstructPolygon(System.IO.Path.GetDirectoryName(CADFilePath), System.IO.Path.GetFileNameWithoutExtension(CADFilePath), i, LayerField, Layers[i]);
                    var result = SelectPolyline(System.IO.Path.GetDirectoryName(CADFilePath), System.IO.Path.GetFileNameWithoutExtension(CADFilePath), i, LayerField, Layers[i]);
                    var polygonfilepath = string.Format("{0}\\{1}_1.shp", System.IO.Path.GetDirectoryName(result), System.IO.Path.GetFileNameWithoutExtension(result));
                    if (TranslatePolylineToPolygon(result, polygonfilepath,Layers[i]))
                    {
                        shps.Add(polygonfilepath);
                    }
                    list.Add(i);
                } catch(Exception ex)
                {

                }
                StepProgressor.Step();
            }
            if (shps.Count > 0)
            {
                Merge(shps, SaveFilePath);
            }
         
           // ContractPolygon(shps, SaveFilePath);
           // Merge(System.IO.Path.GetDirectoryName(CADFilePath), list, System.IO.Path.GetFileNameWithoutExtension(CADFilePath));
            ProgressDialog.HideDialog();
            return true;
        }

    }
}
