using ESRI.ArcGIS.DataManagementTools;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wangjianlong.functionality.Tools.Common
{
    public static class ArcGISFileHelper
    {
        public static IFeatureClass GetShpFeatureClass(string directory, string fileName)
        {
            IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactory();
            IWorkspace workspace = workspaceFactory.OpenFromFile(directory, 0);
            IFeatureClass featureClass = workspace.GetFeatureClass(fileName);
            IWorkspaceFactoryLockControl factorylock = workspaceFactory as IWorkspaceFactoryLockControl;
            if (factorylock.SchemaLockingEnabled)
            {
                factorylock.DisableSchemaLocking();
            }
            return featureClass;
        }
        public static IFeatureClass GetShpFeatureClass(this string filePath)
        {
            return GetShpFeatureClass(System.IO.Path.GetDirectoryName(filePath), System.IO.Path.GetFileNameWithoutExtension(filePath));
        }

        /// <summary>
        /// 作用：新建一个mdb文件
        /// </summary>
        /// <param name="folder">文件目录</param>
        /// <param name="fileName">文件名称</param>
        /// <returns></returns>
        public static string CreatePersonalDataBase(string folder,string fileName)
        {
            var tool = new CreatePersonalGDB();
            tool.out_name = fileName;
            tool.out_folder_path = folder;
            if (GPHelper.Excute(tool))
            {
                return System.IO.Path.Combine(folder, fileName + ".mdb");
            }
            return string.Empty;

        }

        public static bool CreatePersonalDataBase(string filePath)
        {
            var result = CreatePersonalDataBase(System.IO.Path.GetDirectoryName(filePath), System.IO.Path.GetFileNameWithoutExtension(filePath));
            return !string.IsNullOrEmpty(result);
        }
    }
}
