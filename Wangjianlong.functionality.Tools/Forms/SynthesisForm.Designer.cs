namespace Wangjianlong.functionality.Tools.Forms
{
    partial class SynthesisForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.InputtextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SavetextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Synthesisbutton = new System.Windows.Forms.Button();
            this.Closebutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "多线段文件：";
            // 
            // InputtextBox
            // 
            this.InputtextBox.Location = new System.Drawing.Point(87, 24);
            this.InputtextBox.Name = "InputtextBox";
            this.InputtextBox.ReadOnly = true;
            this.InputtextBox.Size = new System.Drawing.Size(253, 21);
            this.InputtextBox.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(346, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(346, 62);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(44, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SavetextBox
            // 
            this.SavetextBox.Location = new System.Drawing.Point(87, 64);
            this.SavetextBox.Name = "SavetextBox";
            this.SavetextBox.ReadOnly = true;
            this.SavetextBox.Size = new System.Drawing.Size(253, 21);
            this.SavetextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "输出文件：";
            // 
            // Synthesisbutton
            // 
            this.Synthesisbutton.Location = new System.Drawing.Point(87, 118);
            this.Synthesisbutton.Name = "Synthesisbutton";
            this.Synthesisbutton.Size = new System.Drawing.Size(75, 23);
            this.Synthesisbutton.TabIndex = 6;
            this.Synthesisbutton.Text = "合成";
            this.Synthesisbutton.UseVisualStyleBackColor = true;
            this.Synthesisbutton.Click += new System.EventHandler(this.Synthesisbutton_Click);
            // 
            // Closebutton
            // 
            this.Closebutton.Location = new System.Drawing.Point(265, 118);
            this.Closebutton.Name = "Closebutton";
            this.Closebutton.Size = new System.Drawing.Size(75, 23);
            this.Closebutton.TabIndex = 7;
            this.Closebutton.Text = "关闭";
            this.Closebutton.UseVisualStyleBackColor = true;
            this.Closebutton.Click += new System.EventHandler(this.Closebutton_Click);
            // 
            // SynthesisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 153);
            this.Controls.Add(this.Closebutton);
            this.Controls.Add(this.Synthesisbutton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.SavetextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.InputtextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SynthesisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "多线段合成";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InputtextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox SavetextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Synthesisbutton;
        private System.Windows.Forms.Button Closebutton;
    }
}