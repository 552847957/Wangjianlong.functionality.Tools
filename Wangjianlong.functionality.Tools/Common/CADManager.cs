using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wangjianlong.functionality.Tools.Common
{
    public static class CADManager
    {
        /// <summary>
        /// 作用：获取CAD文件的线图层要素类
        /// 作者：汪建龙
        /// 编写时间：2016年11月22日13:00:58
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static IFeatureClass GetFeatureClass(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
            {
                return null;
            }
            var directory = System.IO.Path.GetDirectoryName(filePath);
            IWorkspace workspace = WorkspaceManager.OpenCADWorkSpace(directory);
            if (workspace == null)
            {
                return null;
            }
            var fileName = System.IO.Path.GetFileName(filePath);
            IFeatureClass featureClass = workspace.GetCADFeatureClass(fileName, "polyline");
            return featureClass;
        }
    }
}
