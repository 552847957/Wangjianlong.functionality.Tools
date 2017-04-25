using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Wangjianlong.Commons
{
    public  class XMLHelper
    {
        /// <summary>
        /// 作用：获取Xml文件中指定路径中的指定属性值
        /// 作者：汪建龙
        /// 编写时间：2016年12月30日10:44:28
        /// </summary>
        /// <param name="xmlDoc"></param>
        /// <param name="path"></param>
        /// <param name="attributeName"></param>
        /// <returns></returns>
        public static string GetAttribute(XmlDocument xmlDoc,string path,string attributeName)
        {
            try
            {
                XmlNode node = xmlDoc.SelectSingleNode(path);
                return GetAttribute(node, attributeName);

            }catch(Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex);
            }

            return string.Empty;
        }
        /// <summary>
        /// 作用：获取指定某一节点的属性值
        /// 作者：汪建龙
        /// 编写时间：2016年12月30日11:18:06
        /// </summary>
        /// <param name="node"></param>
        /// <param name="attributeName"></param>
        /// <returns></returns>
        public static string GetAttribute(XmlNode node,string attributeName)
        {
            try
            {
                if (node != null 
                    && node.Attributes != null 
                    && node.Attributes.Count > 0 
                    && node.Attributes[attributeName] != null)
                {
                    return node.Attributes[attributeName].Value;
                }

            }catch(Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex);
            }
            return string.Empty;
        }
    }
}
