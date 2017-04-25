using DevExpress.XtraBars.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Wangjianlong.Commons;

namespace Wangjianlong.WorkBench.UIs
{
    internal class UIIniter
    {
        private string _XMLConfigFilePath { get; set; }
        /// <summary>
        /// 配置文件
        /// </summary>
        public string XMLConfigFilePath { get { return _XMLConfigFilePath; }set { _XMLConfigFilePath = value; } }

        public MainForm CreateUI()
        {
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.Skins.SkinManager.EnableMdiFormSkins();

            MainForm frm = new MainForm();
            try
            {
                frm.SuspendLayout();
                frm.ResumeLayout(true);

                frm.IsMdiContainer = true;

                if (System.IO.File.Exists(_XMLConfigFilePath))
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(_XMLConfigFilePath);


                    frm.Name = "MainForm";
                    frm.Text = XMLHelper.GetAttribute(xmlDoc, "/Workbench/RibbonControl", "Text");

                    var ribbonControl= DEVManager.CreateRibbonControl();
                    WorkBench.RibbonControl = ribbonControl;
                    frm.Controls.Add(ribbonControl);


                    

                }

                frm.ResumeLayout(false);

            }catch(Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex);
            }

            return frm;
        }
      

        private void CreatePage(RibbonControl ribbonControl,XmlDocument xmlDocument)
        {
            XmlNode node = xmlDocument.SelectSingleNode("/Workbench/RibbonControl/Pages");
            if (node == null)
            {
                return;
            }
            string load = XMLHelper.GetAttribute(node, "Load");
            if (string.IsNullOrEmpty(load) == false && load.ToUpper().IndexOf("F") > -1)
            {
                return;
            }

            XmlNodeList xmlNodeListPageItem = node.SelectNodes("PageItem");
            if (xmlNodeListPageItem == null)
            {
                return;
            }

            for(var i = 0; i < xmlNodeListPageItem.Count; i++)
            {
                XmlNode xmlNodePageItem = xmlNodeListPageItem.Item(i);

            }

        }

        /// <summary>
        /// 作用：根据配置文件的不同类型，创建不同类型的RibbonControl中的对象
        /// 作者：汪建龙
        /// 编写时间：2016年12月19日15:30:24
        /// </summary>
        /// <param name="ribbonControl"></param>
        /// <param name="xmlNode"></param>
        /// <returns></returns>
        private object CreateItem(RibbonControl ribbonControl, XmlNode xmlNode)
        {
            if (xmlNode == null || xmlNode.NodeType == XmlNodeType.Comment)
            {
                return null;
            }

            string type = XMLHelper.GetAttribute(xmlNode, "Type");
            if (string.IsNullOrEmpty(type))
            {
                return null;
            }

            object obj = null;
            switch (type)
            {
                case "Ribbon.RibbonPage":
                    obj = CreateItemRibbonPage(ribbonControl, xmlNode);
                    break;
                case "Ribbon.RibbonPageGroup":
                    obj = CreateItemRibbonPageGroup(ribbonControl, xmlNode);
                    break;
                case "BarButtonItem":
                    obj = CreateItemBarButtonItem(xmlNode);
                    break;
                case "BarStaticItem":
                    obj = CreateItemBarStaticItem(xmlNode);
                    break;
                case "ApplicationMenu":
                    obj = CreateItemApplicationMenu(xmlNode);
                    break;
                case "BarSubItem":
                    obj = CreateItemBarSubItem(xmlNode);
                    break;
            }
            return obj;
        }
    }
}
