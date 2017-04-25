using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Wangjianlong.functionality.Tools.Common;
using Wangjianlong.functionality.Tools.Forms.Mutiples;
using Wangjianlong.functionality.Tools.Tools;

namespace Wangjianlong.functionality.Tools.Forms
{
    public partial class ProvinceTxtToArcGISForm : Form
    {
        public ProvinceTxtToArcGISForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.TxttextBox.Text = FileManager.SelectFile("省格式文件|*.txt", "请选择省格式文件", this.TxttextBox.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.OutputtextBox.Text = FileManager.SaveFile("ArcGIS文件|*.shp", "ArcGIS 文件", this.OutputtextBox.Text);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.buttonOK.Text = "正在转换......";
            this.buttonOK.Enabled = false;

            var tool = new ProvinceTxtToArcGISTool { TxtFilePath = this.TxttextBox.Text, SaveFilePath = this.OutputtextBox.Text };
            if (!tool.Work())
            {
                MessageBox.Show("转换失败!");
            }
            else
            {
                MessageBox.Show("成功转换");
            }

            this.buttonOK.Enabled = true;
            this.buttonOK.Text = "转换";
        }

        private void FolderTranlatebutton_Click(object sender, EventArgs e)
        {
            var form = new MutipleProvinceTxtToArcGISForm();
            form.ShowDialog(this);
        }
    }
}
