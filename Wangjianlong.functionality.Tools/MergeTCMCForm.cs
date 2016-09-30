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
    public partial class MergeTCMCForm : Form
    {
        public MergeTCMCForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = FileManager.SelectFolder(this.textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = FileManager.SaveFile("shapefile文件|*.shp", "请保存shapefile文件",this.textBox2.Text);
        }

        private void Analyzebutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox1.Text))
            {
                MessageBox.Show("请选择需要合并的文件目录");
                return;
            }

            if (string.IsNullOrEmpty(this.textBox2.Text))
            {
                MessageBox.Show("请选择合并的文件保存路径");
                return;
            }

            this.Analyzebutton.Enabled = false;
            var tool = new MergeTCMCClass() { Folder = this.textBox1.Text, SavaFilePath = this.textBox2.Text };
            if (!tool.Work())
            {
                MessageBox.Show(tool.Error);

            }
            else
            {
                MessageBox.Show("finish");
            }
            this.Analyzebutton.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox1.Text))
            {
                MessageBox.Show("请选择需要合并的文件目录");
                return;
            }

            if (string.IsNullOrEmpty(this.textBox2.Text))
            {
                MessageBox.Show("请选择合并的文件保存路径");
                return;
            }

            this.Analyzebutton.Enabled = false;
            var tool = new MergeTCMCTool() { Folder = this.textBox1.Text, SaveFilePath = this.textBox2.Text };
            if (!tool.Work())
            {
                MessageBox.Show(tool.Error);

            }
            else
            {
                MessageBox.Show("finish");
            }
            this.Analyzebutton.Enabled = true;
        }
    }
}
