using ESRI.ArcGIS.Geometry;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wangjianlong.functionality.Tools.Common;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.Geoprocessing;

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
        public string OutFolder { get; set; }
        public string CoordinateFile { get; set; }
        private ISpatialReference SpatialReference { get; set; }
        private List<string> Files { get; set; }

        public bool Init()
        {
            if (!System.IO.Directory.Exists(Folder))
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
            ProgressDialog.HideDialog();
            return true;
        }

        private void Analyze(string filePath)
        {
            Geoprocessor gp = new Geoprocessor();
            ESRI.ArcGIS.DataManagementTools.Project tool = new ESRI.ArcGIS.DataManagementTools.Project();
            tool.in_dataset = filePath;
            tool.in_coor_system = filePath.GetShpSpatialReference();
            tool.out_dataset = System.IO.Path.Combine(OutFolder, System.IO.Path.GetFileNameWithoutExtension(filePath) + "-Project.shp");
            tool.out_coor_system = SpatialReference;
            try
            {
                var result = gp.Execute(tool, null) as IGeoProcessorResult;
                if (result == null)
                {
                    var error = string.Empty;
                    for(var i = 0; i < gp.MessageCount; i++)
                    {
                        error += gp.GetMessage(i);
                    }
                    Console.WriteLine("投影失败！错误信息：" + error);
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }
}
