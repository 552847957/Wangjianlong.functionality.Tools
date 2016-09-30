using ESRI.ArcGIS.DataManagementTools;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.Geoprocessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wangjianlong.functionality.Tools.Common;

namespace Wangjianlong.functionality.Tools.Tools
{
    public class MergeTCMCTool:DialogClass,ITang
    {
        public override string Description
        {
            get
            {
                return "合并多个文件并关联图层名称";
            }
        }
        public string Folder { get; set; }
        public string SaveFilePath { get; set; }
        public string Error { get; set; }
        public int Count { get; set; }
        private List<string> Files { get; set; }
        private List<string> PointFiles { get; set; }
        private List<string> PolylineFiles { get; set; }
        private List<string> PolygonFiles { get; set; }
        private Geoprocessor gp { get; set; }
        public bool Init()
        {
            if (!System.IO.Directory.Exists(Folder))
            {
                Error += string.Format("文件路径：{0}不存在或不正确；", Folder);
                return false;
            }
            Files = FileManager.GetSpecialFiles(Folder, "*.shp");
            if (Files == null || Files.Count == 0)
            {
                Error += string.Format("未识别文件夹中的shapefile文件或者为空；");
                return false;
            }
            MaxValue = Files.Count;
            PointFiles = new List<string>();
            PolygonFiles = new List<string>();
            PolylineFiles = new List<string>();
            gp = new Geoprocessor();
            return true;
        }
        public override bool Work()
        {
            base.Work();
            if (!Init())
            {
                ProgressDialog.HideDialog();
                return false;
            }
            ParallelLoopResult result = Parallel.ForEach<string>(Files, s => { Analyze(s); });


            //foreach(var file in Files)
            //{
            //    Count++;
            //    StepProgressor.Message = string.Format("正在分析{0}，进度{1}/{2}", file, Count,MaxValue);
            //    CanContinue = TrackCancel.Continue();
            //    if (!CanContinue)
            //    {
            //        break;
            //    }
            //    Application.DoEvents();
            //    Analyze(file);
            //    StepProgressor.Step();
            //}

            foreach(var file in Files)
            {
                Count++;
                StepProgressor.Message = string.Format("正在分析{0}，进度{1}/{2}", file, Count, MaxValue);
                CanContinue = TrackCancel.Continue();
                if (!CanContinue)
                {
                    break;
                }
                Application.DoEvents();
                Judge(file);
                StepProgressor.Step();
            }
            StepProgressor.Message = string.Format("正在保存中");
            if (PointFiles.Count > 0)
            {
                
                var savePoint = string.Format("{0}\\{1}_点.shp", System.IO.Path.GetDirectoryName(this.SaveFilePath), System.IO.Path.GetFileNameWithoutExtension(this.SaveFilePath));
                StepProgressor.Message = string.Format("正在生成文件{0}", savePoint);
                Merge(string.Join(";", PointFiles.ToArray()), savePoint);
            }
            if (PolylineFiles.Count > 0)
            {
                var savePolyline = string.Format("{0}\\{1}_线.shp", System.IO.Path.GetDirectoryName(this.SaveFilePath), System.IO.Path.GetFileNameWithoutExtension(this.SaveFilePath));
                StepProgressor.Message = string.Format("正在生成文件{0}", savePolyline);
                Merge(string.Join(";", PolylineFiles.ToArray()), savePolyline);
            }

            if (PolygonFiles.Count > 0)
            {
                var savePolygon = string.Format("{0}\\{1}_点.shp", System.IO.Path.GetDirectoryName(this.SaveFilePath), System.IO.Path.GetFileNameWithoutExtension(this.SaveFilePath));
                StepProgressor.Message = string.Format("正在生成文件{0}", savePolygon);
                Merge(string.Join(";", PolygonFiles.ToArray()), savePolygon);
            }
            ProgressDialog.HideDialog();
            return true;
        }
        private void ExecuteProcess(IGPProcess gpProcess)
        {
            IGeoProcessorResult result = null;
            try
            {
                result = gp.Execute(gpProcess, null) as IGeoProcessorResult;

            }
            catch (Exception ex)
            {
                throw new ApplicationException("执行过程中出现错误：" + ex.Message, ex);
            }
            if (result == null || result.Status == ESRI.ArcGIS.esriSystem.esriJobStatus.esriJobFailed)
            {
                object srv = 2;
                throw new ApplicationException("执行过程中出现错误：" + gp.GetMessages(ref srv));
            }
        }

        private void Merge(string in_features,string output)
        {
            var merge = new Merge
            {
                inputs = in_features,
                output = output
            };
            ExecuteProcess(merge);
        }

        private bool Analyze(string filePath)
        {
            IFeatureClass featureClass = filePath.GetShpFeatureClass();
            if (featureClass == null)
            {
                return false;
            }
            var a = featureClass.Fields.FindField("TCMC");
            if (a ==-1)
            {
                try
                {
                    IField field = new FieldClass();
                    IFieldEdit2 fieldEdit = field as IFieldEdit2;
                    fieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                    fieldEdit.Name_2 = "TCMC";
                    fieldEdit.AliasName_2 = "图层名称";
                    featureClass.AddField(field);
                }
                catch
                {
                    return false;
                }
            }
          
            var index = featureClass.Fields.FindField("TCMC");
            if (index!= -1)
            {
                var tcmc = System.IO.Path.GetFileNameWithoutExtension(filePath);
                IFeatureCursor featureCursor = featureClass.Search(null, false);
                IFeature feature = featureCursor.NextFeature();
                while (feature != null)
                {
                    feature.set_Value(index, tcmc);
                    feature.Store();
                    feature = featureCursor.NextFeature();
                }
                System.Runtime.InteropServices.Marshal.ReleaseComObject(featureCursor);
                //switch (featureClass.ShapeType)
                //{
                //    case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPoint:
                //        PointFiles.Add(filePath);
                //        break;
                //    case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon:
                //        PolygonFiles.Add(filePath);
                //        break;
                //    case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolyline:
                //        PolylineFiles.Add(filePath);
                //        break;
                //}
            }
       
            
            return true;
        }

        private void Judge(string filePath)
        {
            var featureClass = filePath.GetShpFeatureClass();
            if (featureClass == null)
            {
                var index = featureClass.Fields.FindField("TCMC");
                if (index != -1)
                {
                    switch (featureClass.ShapeType)
                    {
                        case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPoint:
                            PointFiles.Add(filePath);
                            break;
                        case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon:
                            PolygonFiles.Add(filePath);
                            break;
                        case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolyline:
                            PolylineFiles.Add(filePath);
                            break;
                    }
                }
            }
        }
    }
}
