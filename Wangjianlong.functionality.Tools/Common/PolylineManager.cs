using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wangjianlong.functionality.Tools.Common
{
    public static class PolylineManager
    {
        private static readonly double Threshold = 3;
        public static  bool IsPolygon(IFeature feature)
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
        public  static IPolygon GeneratePolygon(IGeometry pl)
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
    }
}
