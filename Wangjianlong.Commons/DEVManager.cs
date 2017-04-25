using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Wangjianlong.Commons.Interfaces;

namespace Wangjianlong.Commons
{
    public static class DEVManager
    {
        private const string AssemblyNameOfDevExpress = "DevExpress.XtraBars";

        /// <summary>
        /// 作用：创建RibbonControl控件
        /// 作者：汪建龙
        /// 编写时间：2016年12月30日13:24:45
        /// </summary>
        /// <returns></returns>
        public static RibbonControl CreateRibbonControl()
        {
            RibbonControl ribbonControl = new RibbonControl();
            ribbonControl.Name = "Ribbon";
            ribbonControl.ContextMenu = null;
            ribbonControl.ContextMenuStrip = null;
            ribbonControl.Minimized = false;
            ribbonControl.ShowToolbarCustomizeItem = false;
            ribbonControl.ShowCategoryInCaption = false;
            ribbonControl.ShowPageHeadersMode = ShowPageHeadersMode.ShowOnMultiplePages;
            ribbonControl.ShowToolbarCustomizeItem = false;

            string imageFile = System.IO.Path.Combine(Application.StartupPath, "Images", "AppIcon.png");
            if (System.IO.File.Exists(imageFile))
            {
                ribbonControl.ApplicationIcon = new System.Drawing.Bitmap(imageFile);
            }
            return ribbonControl;
        }

        /// <summary>
        /// 作用：创建RibbonPage
        /// 作者：汪建龙
        /// 编写时间：2016年12月30日13:57:41
        /// </summary>
        /// <param name="ribbonControl"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        private static object CreateItemRibbonPage(RibbonControl ribbonControl,XmlNode node)
        {
            if (node == null || node.NodeType == XmlNodeType.Comment || node.Attributes == null)
                return null;
            object obj = InstanceHelper.CreateInstance(AssemblyNameOfDevExpress, "Ribbon.RibbonPage") as RibbonPage;
            if (obj == null)
                return null;
            RibbonPage ribbonPage = obj as RibbonPage;
            ribbonPage.Name = XMLHelper.GetAttribute(node, "Name");
            ribbonPage.Text = XMLHelper.GetAttribute(node, "Text");
            ribbonPage.Visible = XMLHelper.GetAttribute(node, "Visible").ToUpper().IndexOf("F") > -1 ? false : true;

            XmlNodeList nodeListSubPageItem = node.ChildNodes;
            foreach(XmlNode nodeSubPageItem in nodeListSubPageItem)
            {
                RibbonPageGroup group = CreateItem(ribbonControl, nodeSubPageItem) as RibbonPageGroup;
                if (group != null)
                {
                    ribbonPage.Groups.Add(group);
                }
            }
            return obj;
        }

        /// <summary>
        /// 作用：创建RibbonControl中的Group
        /// 作者：汪建龙
        /// 编写时间：2016年12月30日14:11:06
        /// </summary>
        /// <param name="ribbonControl"></param>
        /// <param name="nodePageGroup"></param>
        /// <returns></returns>
        private static object CreateItemRibbonPageGroup(RibbonControl ribbonControl,XmlNode nodePageGroup)
        {
            if (nodePageGroup == null || nodePageGroup.NodeType == XmlNodeType.Comment || nodePageGroup.Attributes == null)
                return null;
            object obj = InstanceHelper.CreateInstance(AssemblyNameOfDevExpress, "Ribbon.RibbonPageGroup") as RibbonPageGroup;
            if (obj == null)
                return null;
            RibbonPageGroup ribbonPageGroup = obj as RibbonPageGroup;
            ribbonPageGroup.Name = XMLHelper.GetAttribute(nodePageGroup, "Name");
            ribbonPageGroup.Text = XMLHelper.GetAttribute(nodePageGroup, "Text");
            ribbonPageGroup.Visible = XMLHelper.GetAttribute(nodePageGroup, "Visible").ToUpper().IndexOf("F") > -1 ? false : true;

            XmlNodeList nodeListSubPageItems = nodePageGroup.ChildNodes;
            foreach(XmlNode nodeSubPageItem in nodeListSubPageItems)
            {
                object obj_node = CreateItem(ribbonControl, nodeSubPageItem);
                BarButtonItem item = obj_node as BarButtonItem;
                if(item!=null&&item.Tag is IUICommand)
                {
                    IUICommand uicmd = item.Tag as IUICommand;
                    ribbonPageGroup.ItemLinks.Add(item, uicmd.Group);
                    ribbonControl.Items.Add(item);
                }
                else
                {
                    BarSubItem subItem = obj_node as BarSubItem;
                    if (subItem != null)
                    {
                        ribbonPageGroup.ItemLinks.Add(subItem);
                        ribbonControl.Items.Add(subItem);
                    }
                    XmlNodeList subListItems = nodeSubPageItem.ChildNodes;
                    foreach(XmlNode subNodeSubItem in subListItems)
                    {
                        BarButtonItem item2 = CreateItem(ribbonControl, subNodeSubItem) as BarButtonItem;
                        if(item2!=null&&item2.Tag is IUICommand)
                        {
                            IUICommand uiCmd2 = item2.Tag as IUICommand;
                            subItem.ItemLinks.Add(item2, uiCmd2.Group);
                            ribbonControl.Items.Add(item2);
                        }
                    }
                }
            }
            return obj;
        }
        private static object CreateItemBarButtonItem(XmlNode node)
        {
            if (node == null || node.NodeType == XmlNodeType.Comment)
                return null;
            object obj = InstanceHelper.CreateInstance(AssemblyNameOfDevExpress, "BarButtonItem") as BarButtonItem;
            if (obj == null)
                return null;
            BarButtonItem barButtonItem = obj as BarButtonItem;
            barButtonItem.Name = XMLHelper.GetAttribute(node, "Name");
            barButtonItem.Caption = XMLHelper.GetAttribute(node, "Text");
            var strVisible = XMLHelper.GetAttribute(node, "Visible");
            barButtonItem.Visibility = !string.IsNullOrEmpty(strVisible) && strVisible.ToUpper().IndexOf("F") > -1 ? BarItemVisibility.Never : BarItemVisibility.Always;
            bool largeGlyph = false;
            bool.TryParse(XMLHelper.GetAttribute(node, "LargeGlyph"), out largeGlyph);

            Image image = LoadImageFromResource(XMLHelper.GetAttribute(node, "ImageFile") ?? barButtonItem.Name);
            if (largeGlyph)
            {
                barButtonItem.RibbonStyle = RibbonItemStyles.Large;
                barButtonItem.LargeGlyph = image;
            }
            else
            {
                barButtonItem.RibbonStyle = RibbonItemStyles.SmallWithText;
                barButtonItem.Glyph = image;
            }

            var strBeginGroup = XMLHelper.GetAttribute(node, "Group");
            bool beginGroup = false;
            if (!string.IsNullOrEmpty(strBeginGroup) && strBeginGroup.ToUpper().IndexOf("T") > -1)
            {
                beginGroup = true;
            }
            XmlNode nodeCmdCls = node.SelectSingleNode("CommandClass");
            


        }
        private static object CreateItem(RibbonControl ribbonControl,XmlNode node)
        {
            if (node == null||node.NodeType==XmlNodeType.Comment)
                return null;
            string type = XMLHelper.GetAttribute(node, "Type");
            if (string.IsNullOrEmpty(type))
                return null;
            object obj = null;
            switch (type)
            {
                case "Ribbon.RibbonPage":
                    obj = CreateItemRibbonPage(ribbonControl, node);
                    break;
                case "Ribbon.RibbonPageGroup":
                    obj = CreateItemRibbonPageGroup(ribbonControl, node);
                    break;
                case "BarButtonItem":
                    obj = CreateItemBarButtonItem(node);
                    break;
                case "BarStaticItem":
                    break;
                case "ApplicationMenu":
                    break;
                case "BarSubItem":
                    break;
            }
            return obj;
        }

        public static void CreatePage(RibbonControl ribbonControl,XmlDocument xmlDoc)
        {
            XmlNode node = xmlDoc.SelectSingleNode("/Workbench/RibbonControl/Pages");
            if (node == null)
            {
                return;
            }

            string load = XMLHelper.GetAttribute(node, "Load");
            if (!string.IsNullOrEmpty(load) && load.ToUpper().IndexOf("F") > -1)
            {
                return;
            }

            XmlNodeList xmlNodeListPageItem = node.SelectNodes("PageItem");
            if (xmlNodeListPageItem == null)
                return;
            for(var i = 0; i < xmlNodeListPageItem.Count; i++)
            {
                XmlNode xmlNodePageItem = xmlNodeListPageItem.Item(i);

            }
        }

        private static  System.Drawing.Image LoadImageFromResource(string resourceName)
        {
            try
            {
                //首先从文件系统中搜索资源文件
                string filePath = resourceName;
                if (System.IO.File.Exists(filePath))
                    return System.Drawing.Image.FromFile(filePath);

                filePath = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, resourceName);
                if (File.Exists(filePath))
                    return System.Drawing.Image.FromFile(filePath);

                filePath = Path.Combine(System.Windows.Forms.Application.StartupPath, "Images");
                filePath = Path.Combine(filePath, resourceName);
                if (File.Exists(filePath))
                    return System.Drawing.Image.FromFile(filePath);

                string filePath2 = filePath + ".jpg";
                if (File.Exists(filePath2))
                    return System.Drawing.Image.FromFile(filePath2);

                filePath2 = filePath + ".bmp";
                if (File.Exists(filePath2))
                    return System.Drawing.Image.FromFile(filePath2);

                filePath2 = filePath + ".png";
                if (File.Exists(filePath2))
                    return System.Drawing.Image.FromFile(filePath2);

                filePath2 = filePath + ".gif";
                if (File.Exists(filePath2))
                    return System.Drawing.Image.FromFile(filePath2);


                //如果指定了类型名，则从类型名所在的命名空间中查找
                int index = resourceName.LastIndexOf(",");
                if (index != -1)
                {
                    string strType = resourceName.Substring(0, index).Trim();
                    string resource = resourceName.Substring(index + 1, resourceName.Length - index - 1).Trim();
                    Type type = Type.GetType(strType);
                    if (type != null)
                    {
                        Stream stream = type.Assembly.GetManifestResourceStream(type, resource);
                        if (stream != null)
                        {
                            return System.Drawing.Image.FromStream(stream);
                        }
                    }
                }

                //从已经载入的程序集中搜索资源
                Assembly[] allAssemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (Assembly assembly in allAssemblies)
                {
                    Stream stream = assembly.GetManifestResourceStream(resourceName);
                    if (stream != null)
                    {
                        return System.Drawing.Image.FromStream(stream);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.Write(ex);
            }
            return null;
        }

    }
}
