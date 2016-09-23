using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Wangjianlong.functionality.Tools
{
    public partial class ProgressBarForm : Form
    {
        public ProgressBarForm()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for(var i = 0; i < 100; i++)
            {
                if (this.backgroundWorker1.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                System.Threading.Thread.Sleep(500);
                this.backgroundWorker1.ReportProgress(i);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                MessageBox.Show("取消");
            }else if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else
            {
                MessageBox.Show("Done");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            this.backgroundWorker1.RunWorkerAsync();
            this.button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.backgroundWorker1.WorkerSupportsCancellation == true)
            {
                this.backgroundWorker1.CancelAsync();
            }
           // this.button2.Enabled = false;
        }
    }
}
