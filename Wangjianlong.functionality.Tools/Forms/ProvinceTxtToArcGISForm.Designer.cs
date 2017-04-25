namespace Wangjianlong.functionality.Tools.Forms
{
    partial class ProvinceTxtToArcGISForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProvinceTxtToArcGISForm));
            this.button1 = new System.Windows.Forms.Button();
            this.TxttextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.OutputtextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.FolderTranlatebutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(403, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TxttextBox
            // 
            this.TxttextBox.Location = new System.Drawing.Point(88, 21);
            this.TxttextBox.Name = "TxttextBox";
            this.TxttextBox.ReadOnly = true;
            this.TxttextBox.Size = new System.Drawing.Size(309, 21);
            this.TxttextBox.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "文件：";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(403, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // OutputtextBox
            // 
            this.OutputtextBox.Location = new System.Drawing.Point(88, 67);
            this.OutputtextBox.Name = "OutputtextBox";
            this.OutputtextBox.ReadOnly = true;
            this.OutputtextBox.Size = new System.Drawing.Size(309, 21);
            this.OutputtextBox.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "输出文件：";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(88, 112);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 17;
            this.buttonOK.Text = "转换";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // FolderTranlatebutton
            // 
            this.FolderTranlatebutton.Location = new System.Drawing.Point(207, 111);
            this.FolderTranlatebutton.Name = "FolderTranlatebutton";
            this.FolderTranlatebutton.Size = new System.Drawing.Size(75, 23);
            this.FolderTranlatebutton.TabIndex = 18;
            this.FolderTranlatebutton.Text = "目录转换";
            this.FolderTranlatebutton.UseVisualStyleBackColor = true;
            this.FolderTranlatebutton.Click += new System.EventHandler(this.FolderTranlatebutton_Click);
            // 
            // ProvinceTxtToArcGISForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 158);
            this.Controls.Add(this.FolderTranlatebutton);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.OutputtextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TxttextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProvinceTxtToArcGISForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "省坐标转ArcGIS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TxttextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox OutputtextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button FolderTranlatebutton;
    }
}