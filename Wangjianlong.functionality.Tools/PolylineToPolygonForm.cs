using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Wangjianlong.functionality.Tools.Common;

namespace Wangjianlong.functionality.Tools
{
    public partial class PolylineToPolygonForm : Form
    {
        public PolylineToPolygonForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = FileManager.SelectFile("shapefile文件|*.shp", "请选择CAD_Polyline文件", this.textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = FileManager.SaveFile("shapefile文件|*.shp", "保存文件", this.textBox2.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox1.Text))
            {
                MessageBox.Show("请选择CAD_Polyline文件");
                return;
            }
            if (!System.IO.File.Exists(this.textBox1.Text))
            {
                MessageBox.Show(string.Format("文件路径{0}不正确", this.textBox1.Text));
                return;
            }
            var featureClass = this.textBox1.Text.GetShpFeatureClass();
            if (featureClass == null)
            {
                MessageBox.Show("文件无法打开");
                return;
            }
            this.checkedListBox1.Items.Clear();
            this.ShowLayersbutton.Enabled = false;
            var list = featureClass.GetUniqueValue("Layer");
            foreach(var item in list)
            {
                checkedListBox1.Items.Add(item, true);
            }

            this.ShowLayersbutton.Enabled = true;
        }

        private void Analyzebutton_Click(object sender, EventArgs e)
        {
            this.Analyzebutton.Enabled = false;
            var list = new List<string>();
            foreach(var item in this.checkedListBox1.CheckedItems)
            {
                list.Add(item.ToString());
            }
            var tool = new Wangjianlong.functionality.Tools.Tools.CADPolylineToPolygonTool
            {
                CADFilePath = this.textBox1.Text,
                SaveFilePath = this.textBox2.Text,
                Layers = list
            };
            if (!tool.Work())
            {
                MessageBox.Show(string.Format("failed,{0}", tool.Error));
            }
            else
            {
                MessageBox.Show("finish");
            }
            this.Analyzebutton.Enabled = true;
        }
    }
}
