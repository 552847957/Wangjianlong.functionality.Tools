using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wangjianlong.functionality.Tools.Common
{
    public static class WorkspaceManager
    {
        public static IFeatureClass GetFeatureClass(this IWorkspace workspcae, string featureClassName)
        {
            if (workspcae == null)
            {
                Console.WriteLine("workspace为null,无法获取要素类.........");
                return null;
            }
            IFeatureWorkspace featureWorkspace = workspcae as IFeatureWorkspace;
            IFeatureClass featureClass = null;
            try
            {
                featureClass = featureWorkspace.OpenFeatureClass(featureClassName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("获取要素类：{0}发成错误，错误信息:{1}", featureClassName, ex.Message));
                return null;
            }
            return featureClass;
        }
    }
}
