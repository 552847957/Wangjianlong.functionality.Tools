using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wangjianlong.functionality.Tools.Common;
using Wangjianlong.functionality.Tools.Models;

namespace Wangjianlong.functionality.Tools.Tools
{
    public class MergeTCMCClass : DialogClass, ITang
    {
        public override string Description
        {
            get
            {
                return "合并多个文件并关联图层名称";
            }
        }
        public string Folder { get; set; }
        public string SavaFilePath { get; set; }
        public string Error { get; set; }
        public int Count { get; set; }
        private IFeatureClass FeatureClass { get; set; }
        //private IFeatureCursor InsertFeatureCursor { get; set; }
        private List<string> Files { get; set; }
        private List<TangField> Fields { get; set; }
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
            var file = Files[0];
            var basefeatureClass = ArcGISFileHelper.GetShpFeatureClass(file);
            if (basefeatureClass == null)
            {
                Error += string.Format("无法获取文件：{0}；", System.IO.Path.GetFileNameWithoutExtension(file));
                return false;
            }
            IGeoDataset geoDataset = basefeatureClass as IGeoDataset;
            FeatureClass = FeatureClassManager.CreateFeatrueClass(this.SavaFilePath, geoDataset.SpatialReference, basefeatureClass.ShapeType);
            if (FeatureClass == null)
            {
                Error += string.Format("无法生成shapefile文件，请确保程序以管理员运行；");
                return false;
            }
            // InsertFeatureCursor = FeatureClass.Insert(true);
            Fields = new List<TangField>() { new TangField() { Name = "TCMC", Alias = "图层名称", Type = esriFieldType.esriFieldTypeString, Index = FeatureClass.Fields.FindField("TCMC") } };
            return true;
        }

        public override bool Work()
        {
            base.Work();
            if (!Init())
            {
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(InsertFeatureCursor);
                ProgressDialog.HideDialog();
                return false;
            }
            foreach (var file in Files)
            {
                Count++;
                var tcmc = System.IO.Path.GetFileNameWithoutExtension(file);
                StepProgressor.Message = string.Format("正在分析{0}，进度{1}/{2}", tcmc, Count, MaxValue);
                CanContinue = TrackCancel.Continue();
                if (!CanContinue)
                {
                    break;
                }
                var inputfeatureClass = file.GetShpFeatureClass();
                if (inputfeatureClass != null)
                {
                    if (FeatureClass == null)
                    {
                        IGeoDataset geodataset = inputfeatureClass as IGeoDataset;
                        FeatureClass = FeatureClassManager.CreateFeatrueClass(this.SavaFilePath, geodataset.SpatialReference, inputfeatureClass.ShapeType);
                    }
                    if (FeatureClass != null)
                    {
                        CheckField(FeatureClass, inputfeatureClass);
                        var insertfeaturecursor = FeatureClass.Insert(true);
                        IFeatureBuffer featureBuffer = null;
                        IFeatureCursor featureCursor = inputfeatureClass.Search(null, false);
                        IFeature feature = featureCursor.NextFeature();
                        while (feature != null)
                        {
                            #region

                            featureBuffer = FeatureClass.CreateFeatureBuffer();
                            var copy = feature.ShapeCopy;
                            var aw = copy as IZAware;
                            if (aw.ZAware == true)
                            {
                                aw.ZAware = false;
                            }
                            featureBuffer.Shape = copy;
                            foreach (var field in Fields)
                            {
                                if (field.Name == "TCMC")
                                {
                                    featureBuffer.set_Value(field.Index, tcmc);
                                    continue;
                                }
                                var a = feature.Fields.FindField(field.Name);
                                if (a != -1)
                                {
                                    featureBuffer.set_Value(field.Index, feature.get_Value(a));
                                }

                            }
                            try
                            {
                                object featureOID = insertfeaturecursor.InsertFeature(featureBuffer);
                                insertfeaturecursor.Flush();

                            }
                            catch (Exception ex)
                            {
                                Error += string.Format("在读取{0}时，合并错误，错误信息：{1}；", tcmc, ex.Message);
                                break;
                            }
                            #endregion
                            feature = featureCursor.NextFeature();
                        }
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(insertfeaturecursor);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(featureCursor);
                    }
                }
                else
                {
                    Error += string.Format("无法打开文件：{0}；", tcmc);
                }
                StepProgressor.Step();
            }
            // System.Runtime.InteropServices.Marshal.ReleaseComObject(InsertFeatureCursor);
            ProgressDialog.HideDialog();
            return true;
        }

        private void CheckField(IFeatureClass currentFeatureClass, IFeatureClass AnalyzeFeatureClass)
        {
            var fields = AnalyzeFeatureClass.Fields;
            for (var i = 0; i < fields.FieldCount; i++)
            {
                var field = fields.get_Field(i);
                if (field.Name.ToUpper().Contains("SHAPE") || field.Name.ToUpper().Contains("FID"))
                {
                    continue;
                }
                var index = currentFeatureClass.Fields.FindField(field.Name);
                if (index == -1)//未找到
                {
                    currentFeatureClass.AddField(field);
                    Fields.Add(new TangField() { Name = field.Name, Alias = field.AliasName, Type = field.Type, Index = currentFeatureClass.Fields.FindField(field.Name) });
                }
            }
        }

    }
}