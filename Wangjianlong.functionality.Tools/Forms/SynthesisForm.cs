using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Wangjianlong.functionality.Tools.Common;

namespace Wangjianlong.functionality.Tools.Forms
{
    public partial class SynthesisForm : Form
    {
        public SynthesisForm()
        {
            InitializeComponent();
        }

        private void Closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.SavetextBox.Text = FileManager.SelectFile("Shapefile文件|*.shp", "请选择文件", this.SavetextBox.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.InputtextBox.Text = FileManager.SaveFile("ShapeFile文件|*.shp", "输出文件", this.InputtextBox.Text);
        }

        private void Synthesisbutton_Click(object sender, EventArgs e)
        {

        }
    }
}
