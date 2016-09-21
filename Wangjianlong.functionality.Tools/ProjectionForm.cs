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
    public partial class ProjectionForm : Form
    {
        public ProjectionForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = FileManager.SelectFolder(this.textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = FileManager.SelectCoordinateFile();
        }

        private void Projectionbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox1.Text))
            {
                MessageBox.Show("请选择需要定义文件所在的目录");
                return;
            }

            if (string.IsNullOrEmpty(this.textBox2.Text))
            {
                MessageBox.Show("请选择坐标系文件");
                return;
            }
            this.Projectionbutton.Enabled = false;
            var tool = new ProjectionClass() { Folder = this.textBox1.Text, CoordinateFile = this.textBox2.Text, OutFolder = this.textBox3.Text };
            if (!tool.Work())
            {
                MessageBox.Show(string.Format("失败！{0}", tool.Error));
            }
            else
            {
                MessageBox.Show("Finish");
            }
            this.Projectionbutton.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox3.Text = FileManager.SelectFolder(this.textBox3.Text);
        }
    }
}
