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
    public partial class TxtToArcGISForm : Form
    {
        public TxtToArcGISForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.FoldertextBox.Text = FileManager.SelectFolder(this.FoldertextBox.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.OutputtextBox.Text = FileManager.SaveFile("ArcGIS文件|*.shp", "选择输出ArcGIS文件", this.OutputtextBox.Text);
           // this.OutputtextBox.Text = FileManager.SelectFile("ArcGIS文件|*.shp", "选择输出ArcGIS文件", this.OutputtextBox.Text);
        }

        private void Tranlatebutton_Click(object sender, EventArgs e)
        {
            this.Tranlatebutton.Text = "正在转换......";
            this.Tranlatebutton.Enabled = false;

            var tool = new MutipleTxtToArcGISTool { Folder = this.FoldertextBox.Text, SaveFilePath = this.OutputtextBox.Text };
            if (!tool.Work())
            {
                MessageBox.Show("转换失败！");
            }
            else
            {
                MessageBox.Show("成功转换生成!");
            }

            this.Tranlatebutton.Enabled = true;
            this.Tranlatebutton.Text = "转换";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
