using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Wangjianlong.functionality.Tools.Common;
using Wangjianlong.functionality.Tools.Tools;

namespace Wangjianlong.functionality.Tools.Forms
{
    public partial class ExtractCADForm : Form
    {
        private IFeatureClass _featureClass { get; set; }
        private const string LayerName = "Layer";
        private const string ColorName = "Color";

        public ExtractCADForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.CADtextBox.Text = FileManager.SelectFile("CAD-DXF文件|*.dxf|CAD-DWG文件|*.dwg", "请选择CAD文件", this.CADtextBox.Text);
            AnalyzeLayer();
        }

        private void AnalyzeLayer()
        {
            this.LayerscheckedListBox.Items.Clear();
            this.ColorscheckedListBox.Items.Clear();
            if (!string.IsNullOrEmpty(this.CADtextBox.Text))
            {
                IFeatureClass featureClass = CADManager.GetFeatureClass(this.CADtextBox.Text);
                if (featureClass == null)
                {
                    MessageBox.Show(string.Format("无法打开文件{0}", System.IO.Path.GetFileName(this.CADtextBox.Text)));
                    return;
                }
                _featureClass = featureClass;
                var layers = _featureClass.GetUniqueValue(LayerName);
                foreach(var item in layers)
                {
                    this.LayerscheckedListBox.Items.Add(item, true);
                }
                var colors = _featureClass.GetUniqueValue(ColorName);
                foreach(var item in colors)
                {
                    this.ColorscheckedListBox.Items.Add(item, true);
                }

            }
        }

   

  

        private void button2_Click(object sender, EventArgs e)
        {
            this.SaveFiletextBox.Text = FileManager.SaveFile("ShapeFile文件|*.shp", "请选择输出文件路径", this.SaveFiletextBox.Text);
        }

        private void ExtractButton_Click(object sender, EventArgs e)
        {
            if (_featureClass == null)
            {
                MessageBox.Show("未获取CAD文件相关信息，请重新选择CAD文件");
                return;
            }
            if (string.IsNullOrEmpty(this.SaveFiletextBox.Text))
            {
                MessageBox.Show("请选择输出文件路径！");
                return;
            }

            this.ExtractButton.Text = "正在提取";
            this.ExtractButton.Enabled = false;
            var layerswhereClause = CheckedListBoxManager.GetWhereClause(LayerscheckedListBox, LayerName,true);
            var colorswhereClause = CheckedListBoxManager.GetWhereClause(ColorscheckedListBox, ColorName,false);
            var whereClause = string.Format("({0}) AND ({1})", layerswhereClause, colorswhereClause);

            var tool = new FeatureClassExtractTool { FeatureClass = _featureClass, WhereClause = whereClause, SaveFilePath = this.SaveFiletextBox.Text };
            if (tool.Analyze())
            {
                MessageBox.Show("完成提取");
            }
            else
            {
                MessageBox.Show(string.Format("提取错误：{0}", tool.Error));
            }
            this.ExtractButton.Text = "提取";
            this.ExtractButton.Enabled = true;

        }

        private void ExtractTYbutton_Click(object sender, EventArgs e)
        {
            if (_featureClass == null)
            {
                MessageBox.Show("未获取CAD文件相关信息，请重新选择CAD文件");
                return;
            }
            if (string.IsNullOrEmpty(this.SaveFiletextBox.Text))
            {
                MessageBox.Show("请选择输出文件路径！");
                return;
            }
            var colorswhereClause = CheckedListBoxManager.GetWhereClause(ColorscheckedListBox, ColorName, false);
            var layersWhereClause = CheckedListBoxManager.GetWhereClause(LayerscheckedListBox, LayerName, true);
            this.ExtractTYbutton.Text = "正在提取...";
            this.ExtractTYbutton.Enabled = false;
            var whereClause = string.Format("({0}) AND ({1})", layersWhereClause, colorswhereClause);

            var savefile = this.SaveFiletextBox.Text;
            var polylinefile = string.Format("{0}\\{1}_polyline.shp", System.IO.Path.GetDirectoryName(savefile), System.IO.Path.GetFileNameWithoutExtension(savefile));
            var tool = new FeatureClassExtractTool { FeatureClass = _featureClass, WhereClause = whereClause, SaveFilePath = polylinefile };
            if (tool.Analyze())
            {
                var tool2 = new PolylineToPolygonTool { PolylineFile = polylinefile, PolygonFile = savefile };
                if (tool2.Work())
                {
                    MessageBox.Show("完成");
                }
                else
                {
                    MessageBox.Show("线转面初始化失败！");
                }
            }
            else
            {
                MessageBox.Show(string.Format("提取Polyline错误：{0}", tool.Error));
            }


            this.ExtractTYbutton.Enabled = true;
            this.ExtractTYbutton.Text = "提取（唐尧）";
        }

        private void MutExtractbutton_Click(object sender, EventArgs e)
        {
            var form = new MutlExtractCADForm();
            form.ShowDialog(this);
        }
    }
}
