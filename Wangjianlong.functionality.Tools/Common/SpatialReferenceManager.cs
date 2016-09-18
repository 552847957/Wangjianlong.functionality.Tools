using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wangjianlong.functionality.Tools.Common
{
    public static class SpatialReferenceManager
    {
        public static ISpatialReference CreateSpatialReference(this string strProFile)
        {
            ISpatialReferenceFactory pSpatialReferenceFactory = new SpatialReferenceEnvironmentClass();
            ISpatialReference pSpatialReference = pSpatialReferenceFactory.CreateESRISpatialReferenceFromPRJFile(strProFile);
            return pSpatialReference;
        }

        public static ISpatialReference CreateGeographicCoordinate(esriSRProjCS4Type gcsType)
        {
            ISpatialReferenceFactory pSpatialReferenceFactory = new SpatialReferenceEnvironmentClass();
            ISpatialReference pSpatialReference = pSpatialReferenceFactory.CreateGeographicCoordinateSystem((int)gcsType);
            return pSpatialReference;
        }

        public static ISpatialReference CreateProjectedCoordinate(esriSRProjCS4Type pcsType)
        {
            ISpatialReferenceFactory2 pSpatialReferenceFactory = new SpatialReferenceEnvironmentClass();
            ISpatialReference pSpatialReference = pSpatialReferenceFactory.CreateProjectedCoordinateSystem((int)pcsType);
            return pSpatialReference;
        }

        public static ISpatialReference CreateUnKnownSpatialReference()
        {
            ISpatialReference pSpatialReference = new UnknownCoordinateSystemClass();
            pSpatialReference.SetDomain(0, 99999999, 0, 99999999);//设置空间范围  
            return pSpatialReference;
        }

        public static ISpatialReference GetSpatialReference(IFeatureDataset pFeatureDataset)
        {
            IGeoDataset pGeoDataset = pFeatureDataset as IGeoDataset;
            ISpatialReference pSpatialReference = pGeoDataset.SpatialReference;
            return pSpatialReference;
        }

        public static ISpatialReference GetSpatialReferenc(IFeatureLayer pFeatureLayer)
        {
            IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
            IGeoDataset pGeoDataset = pFeatureClass as IGeoDataset;
            ISpatialReference pSpatialReference = pGeoDataset.SpatialReference;
            return pSpatialReference;
        }

        public static ISpatialReference GetSpatialReference(IFeatureClass pFeatureClass)
        {
            IGeoDataset pGeoDataset = pFeatureClass as IGeoDataset;
            ISpatialReference pSpatialReference = pGeoDataset.SpatialReference;
            return pSpatialReference;
        }

        public static void AlterSpatialReference(IFeatureDataset pFeatureDataset, ISpatialReference pSpatialReference)
        {
            IGeoDataset pGeoDataset = pFeatureDataset as IGeoDataset;
            IGeoDatasetSchemaEdit pGeoDatasetSchemaEdit = pGeoDataset as IGeoDatasetSchemaEdit;
            if (pGeoDatasetSchemaEdit.CanAlterSpatialReference == true)
                pGeoDatasetSchemaEdit.AlterSpatialReference(pSpatialReference);
        }

        public static void AlterSpatialReference(IFeatureClass pFeatureClass, ISpatialReference pSpatialReference)
        {
            IGeoDataset pGeoDataset = pFeatureClass as IGeoDataset;
            IGeoDatasetSchemaEdit pGeoDatasetSchemaEdit = pGeoDataset as IGeoDatasetSchemaEdit;
            if (pGeoDatasetSchemaEdit.CanAlterSpatialReference == true)
                pGeoDatasetSchemaEdit.AlterSpatialReference(pSpatialReference);
        }
    }
}
