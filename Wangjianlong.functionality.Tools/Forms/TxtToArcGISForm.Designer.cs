namespace Wangjianlong.functionality.Tools.Forms
{
    partial class TxtToArcGISForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TxtToArcGISForm));
            this.button4 = new System.Windows.Forms.Button();
            this.Tranlatebutton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.OutputtextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.FoldertextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(212, 111);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 15;
            this.button4.Text = "关闭";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Tranlatebutton
            // 
            this.Tranlatebutton.Location = new System.Drawing.Point(83, 112);
            this.Tranlatebutton.Name = "Tranlatebutton";
            this.Tranlatebutton.Size = new System.Drawing.Size(75, 23);
            this.Tranlatebutton.TabIndex = 14;
            this.Tranlatebutton.Text = "转换";
            this.Tranlatebutton.UseVisualStyleBackColor = true;
            this.Tranlatebutton.Click += new System.EventHandler(this.Tranlatebutton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(398, 64);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // OutputtextBox
            // 
            this.OutputtextBox.Location = new System.Drawing.Point(83, 66);
            this.OutputtextBox.Name = "OutputtextBox";
            this.OutputtextBox.ReadOnly = true;
            this.OutputtextBox.Size = new System.Drawing.Size(309, 21);
            this.OutputtextBox.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "输出文件：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(398, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FoldertextBox
            // 
            this.FoldertextBox.Location = new System.Drawing.Point(83, 24);
            this.FoldertextBox.Name = "FoldertextBox";
            this.FoldertextBox.ReadOnly = true;
            this.FoldertextBox.Size = new System.Drawing.Size(309, 21);
            this.FoldertextBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "文件目录：";
            // 
            // TxtToArcGISForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 152);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.Tranlatebutton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.OutputtextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FoldertextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TxtToArcGISForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "国土资源部文件转ArcGIS文件";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button Tranlatebutton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox OutputtextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox FoldertextBox;
        private System.Windows.Forms.Label label1;
    }
}