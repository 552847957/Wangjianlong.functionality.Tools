using ESRI.ArcGIS.Carto;
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

namespace Wangjianlong.functionality.Tools.Forms.Mutiples
{
    public partial class MutipleSelectForm : Form
    {
        private IWorkspace _workspace { get; set; }
        private List<ILayer> _layers { get; set; }
        private IFeatureClass _featureClass { get; set; }
        private ITang _tool { get; set; }

        public MutipleSelectForm()
        {
            InitializeComponent();
        }

        private void SelectMDBbutton_Click(object sender, EventArgs e)
        {
            this.MDBtextBox.Text = FileManager.SelectFile("数据库文件|*.mdb", "请选择数据库文件", this.MDBtextBox.Text);
            AnalyzeLayer();
        }
        private void AnalyzeLayer()
        {
            this.LayercomboBox.Items.Clear();
            this.FieldcomboBox.Items.Clear();
            if (!string.IsNullOrEmpty(this.MDBtextBox.Text))
            {
                var workspace = WorkspaceManager.OpenAccessWorkSpace(this.MDBtextBox.Text);
                if (workspace == null)
                {
                    MessageBox.Show("打开数据库失败");
                    return;
                }
                _workspace = workspace;
                var layers = WorkspaceManager.AnalyzeLayers(workspace);
                foreach(var layer in layers)
                {
                    this.LayercomboBox.Items.Add(layer.Name);
                }
                _layers = layers;
            }
        }

        private void LayercomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FieldcomboBox.Items.Clear();
            if (_workspace == null)
            {
                AnalyzeLayer();
            }
            var layerName = this.LayercomboBox.Text;
            var layer = _layers.FirstOrDefault(i => i.Name == layerName);
            if (layer == null)
            {
                MessageBox.Show("未分析到图层信息");
                return;
            }
            if(layer is IFeatureLayer)
            {
                var featureLayer = layer as IFeatureLayer;
                if (featureLayer != null)
                {
                    var featureClass = featureLayer.FeatureClass;
                    if (featureClass != null)
                    {
                        var fields = featureClass.GainFieldInformation();
                        foreach(var item in fields)
                        {
                            this.FieldcomboBox.Items.Add(item.Name);
                        }
                        _featureClass = featureClass;
                    }
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.SaveFiletextBox.Text = FileManager.SaveFile("数据库文件|*.mdb", "请选择保存文件路径", this.SaveFiletextBox.Text);
        }

        private void Selectbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.MDBtextBox.Text))
            {
                MessageBox.Show("请选择需要Select的数据库文件");
                return;
            }

            if (string.IsNullOrEmpty(this.SaveFiletextBox.Text))
            {
                MessageBox.Show("请选择保存的路径");
                return;
            }
            _tool = new MutipleSelectTool { FeatureClass = _featureClass, FieldName = this.FieldcomboBox.Text, SaveFilePath = this.SaveFiletextBox.Text };
            if (!_tool.Init())
            {
                MessageBox.Show("执行发生错误");
            }
            else
            {
                MessageBox.Show("执行完成");
            }
        }
    }
}
