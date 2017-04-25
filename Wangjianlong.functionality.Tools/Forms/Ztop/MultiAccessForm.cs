using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Wangjianlong.functionality.Tools.Common;
using Wangjianlong.functionality.Tools.Tools.Ztop;

namespace Wangjianlong.functionality.Tools.Forms.Ztop
{
    public partial class MultiAccessForm : Form
    {
        public MultiAccessForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.FloderBox.Text = FileManager.SelectFolder(this.FloderBox.Text);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.SaveBox.Text = FileManager.SelectFile("合成Access|*.mdb", "请选择合成的Access文件", this.SaveBox.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.FloderBox.Text) && !string.IsNullOrEmpty(this.SaveBox.Text))
            {
                var tool = new MergeAccessTool() { Folder = this.FloderBox.Text, SaveFilePath = this.SaveBox.Text };
                this.button3.Text = "正在合成...";
                this.button3.Enabled = false;
                try
                {
                   

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.ToString());
                }
                if (!tool.Work())
                {
                    MessageBox.Show(tool.Error);
                }

                this.button3.Text = "合成";
                this.button3.Enabled = true;
            }
        }
    }
}
