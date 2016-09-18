using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wangjianlong.functionality.Tools.Common;

namespace Wangjianlong.functionality.Tools.Tools
{
    public class DefineTool
    {
        public string Folder { get; set; }
        public string CoordinateFile { get; set; }
        private ISpatialReference SpatialReference { get; set; }
        public void Work()
        {
            SpatialReference = CoordinateFile.CreateSpatialReference();
            var files = FileManager.GetSpecialFiles(Folder, "*.shp");
            ParallelLoopResult result = Parallel.ForEach<string>(files, s => { Work(s); });
        }
        private bool Work(string filePath)
        {
            IFeatureClass featureClass = ArcGISFileHelper.GetShpFeatureClass(System.IO.Path.GetDirectoryName(filePath), System.IO.Path.GetFileNameWithoutExtension(filePath));
            if (featureClass == null) return false;
            IGeoDataset geoDataset = featureClass as IGeoDataset;
            IGeoDatasetSchemaEdit geoDatasetSchemaEdit = geoDataset as IGeoDatasetSchemaEdit;
            if (geoDatasetSchemaEdit.CanAlterSpatialReference == true)
            {
                geoDatasetSchemaEdit.AlterSpatialReference(SpatialReference);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
