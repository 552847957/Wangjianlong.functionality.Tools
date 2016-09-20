namespace Wangjianlong.functionality.Tools
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.DefineProjectionButton = new System.Windows.Forms.Button();
            this.MergeTCMCButton = new System.Windows.Forms.Button();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // DefineProjectionButton
            // 
            this.DefineProjectionButton.Location = new System.Drawing.Point(12, 12);
            this.DefineProjectionButton.Name = "DefineProjectionButton";
            this.DefineProjectionButton.Size = new System.Drawing.Size(193, 23);
            this.DefineProjectionButton.TabIndex = 0;
            this.DefineProjectionButton.Text = "批量定义（Define Projection）";
            this.DefineProjectionButton.UseVisualStyleBackColor = true;
            this.DefineProjectionButton.Click += new System.EventHandler(this.DefineProjectionButton_Click);
            // 
            // MergeTCMCButton
            // 
            this.MergeTCMCButton.Location = new System.Drawing.Point(13, 42);
            this.MergeTCMCButton.Name = "MergeTCMCButton";
            this.MergeTCMCButton.Size = new System.Drawing.Size(192, 23);
            this.MergeTCMCButton.TabIndex = 1;
            this.MergeTCMCButton.Text = "合并（关联图层名）";
            this.MergeTCMCButton.UseVisualStyleBackColor = true;
            this.MergeTCMCButton.Click += new System.EventHandler(this.MergeTCMCButton_Click);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(173, 217);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 261);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.MergeTCMCButton);
            this.Controls.Add(this.DefineProjectionButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主菜单";
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DefineProjectionButton;
        private System.Windows.Forms.Button MergeTCMCButton;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
    }
}