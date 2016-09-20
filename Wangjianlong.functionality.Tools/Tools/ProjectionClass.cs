using ESRI.ArcGIS.Geometry;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wangjianlong.functionality.Tools.Common;

namespace Wangjianlong.functionality.Tools.Tools
{
    public class ProjectionClass:DialogClass,ITang
    {
        public override string Description
        {
            get
            {
                return "批量Projection";
            }
        }
        public string Error { get; set; }
        public int Count { get; set; }
        public string Folder { get; set; }
        public string CoordinateFile { get; set; }
        private ISpatialReference SpatialReference { get; set; }
        private List<string> Files { get; set; }

        public bool Init()
        {
            if (System.IO.Directory.Exists(Folder))
            {
                Error += string.Format("指定的目录{0}不存在或者不正确", Folder);
                return false;
            }
            Files = FileManager.GetSpecialFiles(Folder, "*.shp");
            if (Files == null || Files.Count == 0)
            {
                Error += string.Format("指定目录中未找到可以分析的文件或者为空");
                return false;
            }
            MaxValue = Files.Count;
            SpatialReference = CoordinateFile.CreateSpatialReference();
            if (SpatialReference == null)
            {
                Error += string.Format("指定的坐标系文件{0}无法打开", System.IO.Path.GetFileNameWithoutExtension(CoordinateFile));
                return false;
            }

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
            StepProgressor.Message = "开始进行Projection";
            ParallelLoopResult result= Parallel.ForEach<string>(Files, s => { Analyze(s); });
            StepProgressor.Message = "完成";
            return true;
        }

        private void Analyze(string filePath)
        {
            var featureClass = filePath.GetShpFeatureClass();
            if (featureClass == null)
            {
                return;
            }
        }

    }
}
