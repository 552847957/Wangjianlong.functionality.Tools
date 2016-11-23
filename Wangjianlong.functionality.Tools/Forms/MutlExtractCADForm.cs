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
    public partial class MutlExtractCADForm : Form
    {
        private const string ColorName = "Color";
        public MutlExtractCADForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.FlodertextBox.Text = FileManager.SelectFolder(this.FlodertextBox.Text);
            AnalyzeFile();
        }

        private void AnalyzeFile()
        {
            this.FilescheckedListBox.Items.Clear();
            this.ColorscheckedListBox.Items.Clear();
            if (!string.IsNullOrEmpty(this.FlodertextBox.Text))
            {
                var files = FileManager.GetSpecialFiles(this.FlodertextBox.Text, "*.dwg");
                var dxffiles = FileManager.GetSpecialFiles(this.FlodertextBox.Text, "*.dxf");
                if (files != null && files.Count > 0)
                {
                    foreach (var item in files)
                    {
                        this.FilescheckedListBox.Items.Add(System.IO.Path.GetFileName(item), true);
                    }
                }
                if (dxffiles != null && dxffiles.Count > 0)
                {
                    foreach(var item in dxffiles)
                    {
                        this.FilescheckedListBox.Items.Add(System.IO.Path.GetFileName(item), true);
                    }
                }
            }
            
        }

        private void AnalyzeColorbutton_Click(object sender, EventArgs e)
        {
            this.AnalyzeColorbutton.Text = "正在分析...";
            this.AnalyzeColorbutton.Enabled = false;
            this.ColorscheckedListBox.Items.Clear();
            var files = CheckedListBoxManager.GetChecked(this.FilescheckedListBox);
            if (files.Count == 0)
            {
                MessageBox.Show("当前未选择文件");
                this.AnalyzeColorbutton.Text = "分析颜色";
                this.AnalyzeColorbutton.Enabled = true;
                return;
            }
            var allColors = new List<string>();
            foreach(var fileName in files)
            {
                var fullName = System.IO.Path.Combine(this.FlodertextBox.Text, fileName);
                if (System.IO.File.Exists(fullName))
                {
                    var featureClass = CADManager.GetFeatureClass(fullName);
                    if (featureClass != null)
                    {
                        var colors = featureClass.GetUniqueValue(ColorName);
                        foreach(var item in colors)
                        {
                            if (!allColors.Contains(item))
                            {
                                allColors.Add(item);
                            }
                        }
                    }
                }
            }
            foreach(var item in allColors)
            {
                this.ColorscheckedListBox.Items.Add(item, true);
            }
            this.AnalyzeColorbutton.Text = "分析颜色";
            this.AnalyzeColorbutton.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.SavetextBox.Text))
            {
                MessageBox.Show("请选择输出文件路径");
                return;
            }
            var files = CheckedListBoxManager.GetChecked(this.FilescheckedListBox);
            if (files.Count == 0)
            {
                MessageBox.Show("请选择需要转换的CAD文件");
                return;
            }
            var fullFileNames = files.Select(k => System.IO.Path.Combine(this.FlodertextBox.Text, k)).ToList();
            var whereClause = CheckedListBoxManager.GetWhereClause(this.ColorscheckedListBox, ColorName, false);
            this.button3.Text = "正在提取...";
            this.button3.Enabled = false;
            var tool = new ExtractCADsToOnePolylineTool
            {
                CADFiles = fullFileNames,
                PolylineFile = this.SavetextBox.Text,
                WhereClause=whereClause
            };
            if (tool.Work())
            {
                MessageBox.Show("完成");
            }
            else
            {
                MessageBox.Show(string.Format("发生错误：{0}", tool.Error));
            }

            this.button3.Text = "批量提取Polyline";
            this.button3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.SavetextBox.Text = FileManager.SaveFile("Shapefile文件|*.shp", "请选择输出文件路径", this.SavetextBox.Text);
        }

        private void MutilToPolylinebutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.SavetextBox.Text))
            {
                MessageBox.Show("请选择输出文件路径");
                return;
            }
            var files = CheckedListBoxManager.GetChecked(this.FilescheckedListBox);
            if (files.Count == 0)
            {
                MessageBox.Show("请选择需要转换的CAD文件");
                return;
            }
            var fullFileNames = files.Select(k => System.IO.Path.Combine(this.FlodertextBox.Text, k)).ToList();
            var whereClause = CheckedListBoxManager.GetWhereClause(this.ColorscheckedListBox, ColorName, false);
            this.MutilToPolylinebutton.Text = "正在提取...";
            this.MutilToPolylinebutton.Enabled = false;

            var tool = new ExtractCADsToOnePolygonTool
            {
                CADFiles = fullFileNames,
                PolygonFile = this.SavetextBox.Text,
                WhereClause=whereClause
            };
            if (tool.Work())
            {
                MessageBox.Show("完成");
            }
            else
            {
                MessageBox.Show(string.Format("存在如下错误：{0}", tool.Error));
            }
            this.MutilToPolylinebutton.Text = "批量提取Polygon";
            this.MutilToPolylinebutton.Enabled = true;
        }
    }
}
