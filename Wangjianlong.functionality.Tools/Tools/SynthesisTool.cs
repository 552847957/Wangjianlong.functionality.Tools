using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wangjianlong.functionality.Tools.Tools
{
    /// <summary>
    /// 作用：将打断的多线段Polyline合成一个Polyline
    /// 作者：汪建龙
    /// 编写时间：2016年11月25日11:00:03
    /// </summary>
    public class SynthesisTool
    {
        public IFeatureClass InputFeatureClass { get; set; }

        public IFeatureClass OutputFeatureClass { get; set; }
        public bool Work()
        {
            IFeatureCursor featureCursor = InputFeatureClass.Search(null, false);
            IFeature feature = featureCursor.NextFeature();
            while (feature != null)
            {

                feature = featureCursor.NextFeature();
            }
            System.Runtime.InteropServices.Marshal.ReleaseComObject(featureCursor);
            return false;
        }
    }
}
