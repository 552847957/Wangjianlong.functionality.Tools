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

namespace Wangjianlong.functionality.Tools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ChooseCoordbutton_Click(object sender, EventArgs e)
        {
            this.CoordinateTextBox.Text = FileManager.SelectFile("坐标系文件|*.prj", "请选择坐标系文件", System.IO.Path.Combine(Application.StartupPath, System.Configuration.ConfigurationManager.AppSettings["Coordinate"]));
        }

        private void ChooseFolderbutton_Click(object sender, EventArgs e)
        {
            this.FolderTextBox.Text = FileManager.SelectFolder();
        }

        private void Analyzebutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.FolderTextBox.Text))
            {
                MessageBox.Show("请指定文件夹");
                return;
            }
            if (string.IsNullOrEmpty(this.CoordinateTextBox.Text))
            {
                MessageBox.Show("请指定坐标系文件");
                return;
            }

            this.Analyzebutton.Enabled = false;
            var tool = new DefineTool() { Folder = this.FolderTextBox.Text, CoordinateFile = this.CoordinateTextBox.Text };
            tool.Work();
            this.Analyzebutton.Enabled = true;
            MessageBox.Show("Finish");
        }
    }
}
