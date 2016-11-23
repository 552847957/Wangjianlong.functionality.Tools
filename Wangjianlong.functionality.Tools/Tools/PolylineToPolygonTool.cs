using ESRI.ArcGIS.Geodatabase;
using Wangjianlong.functionality.Tools.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geometry;

namespace Wangjianlong.functionality.Tools.Tools
{
    public class PolylineToPolygonTool
    {
        private static readonly double Threshold = 3;

        public string PolylineFile { get; set; }

        public string PolygonFile { get; set; }

        private string _error { get; set; }

        public string Error { get { return _error; } }

        private IFeatureClass _polylineFeatureClass { get; set; }

        private IFeatureClass _polygonFeatureClass { get; set; }
        private int _index { get; set; }

        public bool Init()
        {
            if (!System.IO.File.Exists(PolylineFile))
            {
                return false;
            }
            _polylineFeatureClass = PolylineFile.GetShpFeatureClass();
            if (_polylineFeatureClass == null)
            {
                return false;
            }
            ISpatialReference spatialReference = SpatialReferenceManager.GetSpatialReference(_polylineFeatureClass);
            _polygonFeatureClass = FeatureClassManager.CreateFeatrueClass(PolygonFile, spatialReference, esriGeometryType.esriGeometryPolygon);
            if (_polygonFeatureClass == null)
            {
                return false;
            }
            _index = _polygonFeatureClass.Fields.FindField("TCMC");
            if (_index > -1)
            {
                return true;
            }
            return false;
        }
        private bool IsPolygon(IFeature feature)
        {
            var geo = feature.Shape;
            if (geo is IPolyline && geo.IsEmpty == false)
            {
                var polyline = geo as IPolyline4;
                var pointCollection = polyline as IPointCollection;
                var startPoint = pointCollection.get_Point(0);
                var endPoint = pointCollection.get_Point(pointCollection.PointCount - 1);
                var x = endPoint.X - startPoint.X;
                var y = endPoint.Y - startPoint.Y;
                var distance = x * x + y * y;
                return distance < Threshold * Threshold;
            }
            return false;
        }
        private IPolygon GeneratePolygon(IGeometry pl)
        {
            if (pl.IsEmpty || (pl is IPolyline) == false) return null;
            var pc1 = (IPointCollection)pl;
            var pg = new PolygonClass();
            var pc2 = (IPointCollection)pg;
            for (var i = 0; i < pc1.PointCount; i++)
            {
                var pt = pc1.get_Point(i);
                var pt2 = new PointClass { X = pt.X, Y = pt.Y };
                pc2.AddPoint(pt2);
            }

            var pt3 = pc1.get_Point(0);
            var pt4 = new PointClass { X = pt3.X, Y = pt3.Y };
            pc2.AddPoint(pt4);
            pg.Simplify();
            return pg;
        }

        public bool Work()
        {
            if (Init())
            {
                var cursor = _polygonFeatureClass.Insert(true);
                IFeatureCursor featureCursor = _polylineFeatureClass.Search(null, false);
                IFeature feature = featureCursor.NextFeature();
                while (feature != null)
                {
                    if (IsPolygon(feature))
                    {
                        var pg = GeneratePolygon(feature.ShapeCopy);
                        if (pg != null)
                        {
                            var buffer = _polygonFeatureClass.CreateFeatureBuffer();
                            buffer.Shape = pg;
                            cursor.InsertFeature(buffer);
                        }
                    }
                    feature = featureCursor.NextFeature();
                }
                cursor.Flush();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(cursor);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(featureCursor);
                return true;
            }
            return false;
        }
    }
}
