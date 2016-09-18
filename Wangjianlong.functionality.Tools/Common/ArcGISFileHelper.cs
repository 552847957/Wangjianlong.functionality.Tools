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
        public static IFeatureClass GetShpFeatureClass(string filePath, string fileName)
        {
            IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactory();
            IWorkspace workspace = workspaceFactory.OpenFromFile(filePath, 0);
            IFeatureClass featureClass = workspace.GetFeatureClass(fileName);
            return featureClass;
        }
    }
}
