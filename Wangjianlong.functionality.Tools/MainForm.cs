using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Wangjianlong.functionality.Tools.Forms;
using Wangjianlong.functionality.Tools.Forms.Ztop;

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

        private void Synthesisbutton_Click(object sender, EventArgs e)
        {
            var form = new SynthesisForm();
            form.ShowDialog(this);
        }

        private void TxtToArcGISbutton_Click(object sender, EventArgs e)
        {
            var form = new TxtToArcGISForm();
            form.ShowDialog(this);
        }

        private void Provincebutton_Click(object sender, EventArgs e)
        {
            var form = new ProvinceTxtToArcGISForm();
            form.ShowDialog(this);
        }

        private void MultiAccessbutton_Click(object sender, EventArgs e)
        {
            var form = new MultiAccessForm();
            form.ShowDialog(this);
        }
    }
}
