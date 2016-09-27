using ESRI.ArcGIS.AnalysisTools;
using ESRI.ArcGIS.DataManagementTools;
using ESRI.ArcGIS.Geodatabase;
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
                //throw new ApplicationException("执行过程中出现错误：" + ex.Message, ex);
            }
            if (result == null || result.Status == ESRI.ArcGIS.esriSystem.esriJobStatus.esriJobFailed)
            {
                object srv = 2;
                //throw new ApplicationException("执行过程中出现错误：" + gp.GetMessages(ref srv));
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

            var f2p = new FeatureToPolygon
            {
                in_features = string.Format("{0}\\{1}_{2}_1.shp", folder, from, index),
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

        private void Merge(string folder,List<int> indices,string prefix)
        {
            var array = indices.Select(e => string.Format("{0}\\{1}_{2}.shp", folder, prefix, e)).ToArray();
            var merge = new Merge
            {
                inputs = string.Join(";", array),
                output = SaveFilePath
            };
            ExecuteProcess(merge);
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
                    ConstructPolygon(System.IO.Path.GetDirectoryName(CADFilePath), System.IO.Path.GetFileNameWithoutExtension(CADFilePath), i, LayerField, Layers[i]);
                    list.Add(i);
                } catch(Exception ex)
                {

                }
                StepProgressor.Step();
            }
            Merge(System.IO.Path.GetDirectoryName(CADFilePath), list, System.IO.Path.GetFileNameWithoutExtension(CADFilePath));
            ProgressDialog.HideDialog();
            return true;
        }

    }
}
