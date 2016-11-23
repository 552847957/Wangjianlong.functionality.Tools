using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wangjianlong.functionality.Tools.Tools
{
    /// <summary>
    /// 作用：提取CAD文件列表 合成一个文件
    /// 作者：汪建龙
    /// 编写时间：2016年11月22日20:24:52
    /// </summary>
    public class ExtractCADsToOnePolygonTool
    {
        public List<string> CADFiles { get; set; }

        public string PolygonFile { get; set; }

        public string WhereClause { get; set; }

        private string _polylineFile { get; set; }
        private string _error { get; set; }
        public string Error { get { return _error; } }
        private bool Init()
        {
            if (CADFiles == null || CADFiles.Count == 0)
            {
                _error += "CAD文件列表为空";
                return false;
            }
            if (System.IO.File.Exists(PolygonFile))
            {
                System.IO.File.Delete(PolygonFile);
            }
            _polylineFile = string.Format("{0}\\{1}_Polyline.shp", System.IO.Path.GetDirectoryName(PolygonFile), System.IO.Path.GetFileNameWithoutExtension(PolygonFile));


            return true;
        }

        public bool Work()
        {
            if (Init())
            {
                var tool = new ExtractCADsToOnePolylineTool
                {
                    CADFiles = CADFiles,
                    PolylineFile = _polylineFile,
                    WhereClause=WhereClause
                };
                if (tool.Work())
                {
                    var polylintopolgyon = new ExtractCADPolylineToPolygonTool
                    {
                        PolylineFile = _polylineFile,
                        PolygonFile = PolygonFile
                    };
                    if (polylintopolgyon.Work())
                    {
                        return true;
                    }
                    else
                    {
                        _error += string.Format("线转面发生错误，错误信息：{0}", polylintopolgyon.Error);
                        return false;
                    }
                }
                else
                {
                    _error += string.Format("在提取线的时候，发生错误：", tool.Error);
                    return false;
                }
            }
            return false;
        }
    }
}
