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
    public partial class MutipleClipForm : Form
    {
        private List<ILayer> _list { get; set; }
        private ITang _tool { get; set; }
        public MutipleClipForm()
        {
            InitializeComponent();
        }

        private void Accessbutton_Click(object sender, EventArgs e)
        {
            this.AccesstextBox.Text = FileManager.SelectFile("Access数据库文件|*.mdb", "请选择Person DataBase文件", this.AccesstextBox.Text);
            AnalyzeLayer(this.AccesstextBox.Text);
        }


        private List<ILayer> AnalyzeLayerBase(string filePath,CheckedListBox checkedlistBox)
        {
            IWorkspace workspace = WorkspaceManager.OpenAccessWorkSpace(filePath);
            if (workspace == null)
            {
                MessageBox.Show(string.Format("打开文件{0}失败，未获取Workspace变量", System.IO.Path.GetFileNameWithoutExtension(filePath)));
                return null;
            }
            List<ILayer> list = WorkspaceManager.AnalyzeLayers(workspace);
            checkedlistBox.Items.Clear();
            foreach(var item in list)
            {
                checkedlistBox.Items.Add(item.Name, true);
            }
            return list;
        }

        /// <summary>
        /// 作用：主要对需要切的数据文件分析图层
        /// </summary>
        /// <param name="filePath"></param>
        private void AnalyzeLayer(string filePath)
        {
            _list = AnalyzeLayerBase(filePath, this.LayerscheckedListBox);
        }

        private void AnalyzeClipLayer(string filePath)
        {
            AnalyzeLayerBase(filePath, this.ClipcheckedListBox);
        }


        private void FolderSavebutton_Click(object sender, EventArgs e)
        {
            this.SaveFoldertextBox.Text = FileManager.SelectFolder(this.SaveFoldertextBox.Text);
        }

        private void AnalyzeLayerbutton_Click(object sender, EventArgs e)
        {
            this.AnalyzeLayerbutton.Enabled = false;
            AnalyzeLayer(this.AccesstextBox.Text);
            this.AnalyzeLayerbutton.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.SaveFoldertextBox.Text))
            {
                MessageBox.Show("请选择输出目录");
                return;
            }
            if (_list == null)
            {
                AnalyzeLayer(this.AccesstextBox.Text);
            }

            _tool = new MutipleClipTool
            {
                DataBasePath = this.AccesstextBox.Text,
                Layers = CheckedListBoxManager.GetChecked(this.LayerscheckedListBox),
                ClipLayers=CheckedListBoxManager.GetChecked(this.ClipcheckedListBox),
                ClipDataBasePath = this.ClipDatabasetextBox.Text,
                SaveFolder = this.SaveFoldertextBox.Text
            };
            if (!_tool.Init())
            {
                MessageBox.Show("执行失败");
            }
            else
            {
                MessageBox.Show("成功执行");
            }
        }

        private void SelectClipDataBasebutton_Click(object sender, EventArgs e)
        {
            this.ClipDatabasetextBox.Text = FileManager.SelectFile("数据库文件|*.mdb", "切割图层数据库文件", this.ClipDatabasetextBox.Text);
            AnalyzeClipLayer(this.ClipDatabasetextBox.Text);
        }

        private void ReadClipbutton_Click(object sender, EventArgs e)
        {
            this.ReadClipbutton.Enabled = false;
            AnalyzeClipLayer(this.ClipcheckedListBox.Text);
            this.ReadClipbutton.Enabled = true;
        }

        private void AllChecked(CheckedListBox checkedlistBox)
        {
            foreach(var item in checkedlistBox.Items)
            {
                
            }
        }

        private void AllLayerbutton_Click(object sender, EventArgs e)
        {
            CheckedListBoxManager.Checked(this.LayerscheckedListBox, true);
        }

        private void NotLayerbutton_Click(object sender, EventArgs e)
        {
            CheckedListBoxManager.Checked(this.LayerscheckedListBox, false);
        }

        private void AntonymLayerButton_Click(object sender, EventArgs e)
        {
            CheckedListBoxManager.AntonymChecked(this.LayerscheckedListBox);
        }

        private void AllClipbutton_Click(object sender, EventArgs e)
        {
            CheckedListBoxManager.Checked(this.ClipcheckedListBox, true);
        }

        private void NotClipbutton_Click(object sender, EventArgs e)
        {
            CheckedListBoxManager.Checked(this.ClipcheckedListBox, false);
        }

        private void AntonymClipbutton_Click(object sender, EventArgs e)
        {
            CheckedListBoxManager.AntonymChecked(this.ClipcheckedListBox);
        }
    }
}
