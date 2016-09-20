using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wangjianlong.functionality.Tools.Tools
{
    public class DialogClass
    {
        public virtual string Description { get; }
        protected int MaxValue { get; set; }
        protected bool CanContinue { get; set; }
        public int hWd { get; set; }

        protected ITrackCancel TrackCancel { get; set; }
        protected IProgressDialogFactory ProgressDialogFactory { get; set; }
        protected IProgressDialog2 ProgressDialog { get; set; }
        protected IStepProgressor StepProgressor { get; set; }
        public virtual bool Work()
        {
            TrackCancel = new CancelTrackerClass();
            ProgressDialogFactory = new ProgressDialogFactoryClass();
            ProgressDialog = ProgressDialogFactory.Create(TrackCancel, hWd) as IProgressDialog2;
            ProgressDialog.CancelEnabled = false;
            ProgressDialog.Description = Description;
            ProgressDialog.Title = Description;
            ProgressDialog.Animation = esriProgressAnimationTypes.esriProgressGlobe;
            StepProgressor = ProgressDialog as IStepProgressor;
            StepProgressor.MinRange = 0;
            StepProgressor.StepValue = 1;
            ProgressDialog.ShowDialog();
            return true;
        }
    }
}
