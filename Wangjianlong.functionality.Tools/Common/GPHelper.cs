using ESRI.ArcGIS.Geoprocessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wangjianlong.functionality.Tools.Common
{
    public static class GPHelper
    {
        public static bool Excute(IGPProcess tool)
        {
            Geoprocessor gp = new Geoprocessor();
            gp.OverwriteOutput = true;
            try
            {
                gp.Execute(tool, null);
            }
            catch
            {
                object sev1 = 2;
                gp.AddError(gp.GetMessages(ref sev1));
                return false;
            }
            return true;
        }
    }
}
