using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Wangjianlong.functionality.Tools.Forms;

namespace Wangjianlong.functionality.Tools
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void DefineProjectionButton_Click(object sender, EventArgs e)
        {
            var form = new Form1();
            form.ShowDialog(this);
        }

        private void MergeTCMCButton_Click(object sender, EventArgs e)
        {
            var form = new MergeTCMCForm();
            form.ShowDialog(this);
        }

        private void Projectionbutton_Click(object sender, EventArgs e)
        {
            var form = new ProjectionForm();
            form.ShowDialog(this);
        }

        private void PolylineToPolygonbutton_Click(object sender, EventArgs e)
        {
            var form = new PolylineToPolygonForm();
            form.ShowDialog(this);
        }

        private void ProgressBarButton_Click(object sender, EventArgs e)
        {
            var form = new ProgressBarForm();
            form.ShowDialog(this);
        }

        private void ExtractCADButton_Click(object sender, EventArgs e)
        {
            var form = new ExtractCADForm();
            form.ShowDialog(this);
        }
    }
}
