namespace Wangjianlong.functionality.Tools
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.label1 = new System.Windows.Forms.Label();
            this.FolderTextBox = new System.Windows.Forms.TextBox();
            this.ChooseFolderbutton = new System.Windows.Forms.Button();
            this.Analyzebutton = new System.Windows.Forms.Button();
            this.ChooseCoordbutton = new System.Windows.Forms.Button();
            this.CoordinateTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(344, 113);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "请选择目录：";
            // 
            // FolderTextBox
            // 
            this.FolderTextBox.Location = new System.Drawing.Point(95, 23);
            this.FolderTextBox.Name = "FolderTextBox";
            this.FolderTextBox.Size = new System.Drawing.Size(237, 21);
            this.FolderTextBox.TabIndex = 2;
            // 
            // ChooseFolderbutton
            // 
            this.ChooseFolderbutton.Location = new System.Drawing.Point(339, 21);
            this.ChooseFolderbutton.Name = "ChooseFolderbutton";
            this.ChooseFolderbutton.Size = new System.Drawing.Size(37, 23);
            this.ChooseFolderbutton.TabIndex = 3;
            this.ChooseFolderbutton.Text = "...";
            this.ChooseFolderbutton.UseVisualStyleBackColor = true;
            this.ChooseFolderbutton.Click += new System.EventHandler(this.ChooseFolderbutton_Click);
            // 
            // Analyzebutton
            // 
            this.Analyzebutton.Location = new System.Drawing.Point(95, 121);
            this.Analyzebutton.Name = "Analyzebutton";
            this.Analyzebutton.Size = new System.Drawing.Size(75, 23);
            this.Analyzebutton.TabIndex = 4;
            this.Analyzebutton.Text = "定义坐标系";
            this.Analyzebutton.UseVisualStyleBackColor = true;
            this.Analyzebutton.Click += new System.EventHandler(this.Analyzebutton_Click);
            // 
            // ChooseCoordbutton
            // 
            this.ChooseCoordbutton.Location = new System.Drawing.Point(340, 67);
            this.ChooseCoordbutton.Name = "ChooseCoordbutton";
            this.ChooseCoordbutton.Size = new System.Drawing.Size(37, 23);
            this.ChooseCoordbutton.TabIndex = 7;
            this.ChooseCoordbutton.Text = "...";
            this.ChooseCoordbutton.UseVisualStyleBackColor = true;
            this.ChooseCoordbutton.Click += new System.EventHandler(this.ChooseCoordbutton_Click);
            // 
            // CoordinateTextBox
            // 
            this.CoordinateTextBox.Location = new System.Drawing.Point(96, 69);
            this.CoordinateTextBox.Name = "CoordinateTextBox";
            this.CoordinateTextBox.Size = new System.Drawing.Size(237, 21);
            this.CoordinateTextBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "坐标系文件：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 156);
            this.Controls.Add(this.ChooseCoordbutton);
            this.Controls.Add(this.CoordinateTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Analyzebutton);
            this.Controls.Add(this.ChooseFolderbutton);
            this.Controls.Add(this.FolderTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.axLicenseControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "批量定义坐标系(Defined Projection)";
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FolderTextBox;
        private System.Windows.Forms.Button ChooseFolderbutton;
        private System.Windows.Forms.Button Analyzebutton;
        private System.Windows.Forms.Button ChooseCoordbutton;
        private System.Windows.Forms.TextBox CoordinateTextBox;
        private System.Windows.Forms.Label label2;
    }
}

