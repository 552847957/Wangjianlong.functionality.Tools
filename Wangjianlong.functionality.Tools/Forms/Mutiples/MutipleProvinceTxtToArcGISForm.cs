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
    public partial class MutipleProvinceTxtToArcGISForm : Form
    {
        public MutipleProvinceTxtToArcGISForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.FoldertextBox.Text = FileManager.SelectFolder(this.FoldertextBox.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.OutputtextBox.Text = FileManager.SaveFile("ArcGIS文件|*.shp", "ArcGIS 文件", this.OutputtextBox.Text);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.buttonOK.Text = "正在转换......";
            this.buttonOK.Enabled = false;


            var tool = new MutipleProvinceTxtToArcGISTool { Folder = this.FoldertextBox.Text, SaveFilePath = this.OutputtextBox.Text };
            if (!tool.Work())
            {
                MessageBox.Show(string.Join(";", tool.Errors.ToArray()));
            }
            else
            {
                MessageBox.Show("转换成功");
            }

            this.buttonOK.Enabled = true;
            this.buttonOK.Text = "转换";
        }
    }
}
