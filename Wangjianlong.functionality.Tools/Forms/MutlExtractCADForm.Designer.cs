namespace Wangjianlong.functionality.Tools.Forms
{
    partial class MutlExtractCADForm
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
            this.FlodertextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ColorscheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AnalyzeColorbutton = new System.Windows.Forms.Button();
            this.FilescheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SavetextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MutilToPolylinebutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "CAD目录：";
            // 
            // FlodertextBox
            // 
            this.FlodertextBox.Location = new System.Drawing.Point(76, 19);
            this.FlodertextBox.Name = "FlodertextBox";
            this.FlodertextBox.ReadOnly = true;
            this.FlodertextBox.Size = new System.Drawing.Size(262, 21);
            this.FlodertextBox.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(344, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ColorscheckedListBox
            // 
            this.ColorscheckedListBox.FormattingEnabled = true;
            this.ColorscheckedListBox.Location = new System.Drawing.Point(259, 89);
            this.ColorscheckedListBox.Name = "ColorscheckedListBox";
            this.ColorscheckedListBox.Size = new System.Drawing.Size(120, 228);
            this.ColorscheckedListBox.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(257, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "颜色列表：";
            // 
            // AnalyzeColorbutton
            // 
            this.AnalyzeColorbutton.Location = new System.Drawing.Point(76, 390);
            this.AnalyzeColorbutton.Name = "AnalyzeColorbutton";
            this.AnalyzeColorbutton.Size = new System.Drawing.Size(75, 23);
            this.AnalyzeColorbutton.TabIndex = 10;
            this.AnalyzeColorbutton.Text = "分析颜色";
            this.AnalyzeColorbutton.UseVisualStyleBackColor = true;
            this.AnalyzeColorbutton.Click += new System.EventHandler(this.AnalyzeColorbutton_Click);
            // 
            // FilescheckedListBox
            // 
            this.FilescheckedListBox.FormattingEnabled = true;
            this.FilescheckedListBox.Location = new System.Drawing.Point(76, 89);
            this.FilescheckedListBox.Name = "FilescheckedListBox";
            this.FilescheckedListBox.Size = new System.Drawing.Size(120, 228);
            this.FilescheckedListBox.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "CAD文件列表：";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(76, 428);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "批量提取Polyline";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(344, 336);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(45, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SavetextBox
            // 
            this.SavetextBox.Location = new System.Drawing.Point(76, 338);
            this.SavetextBox.Name = "SavetextBox";
            this.SavetextBox.ReadOnly = true;
            this.SavetextBox.Size = new System.Drawing.Size(262, 21);
            this.SavetextBox.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 341);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "输出文件：";
            // 
            // MutilToPolylinebutton
            // 
            this.MutilToPolylinebutton.Location = new System.Drawing.Point(220, 428);
            this.MutilToPolylinebutton.Name = "MutilToPolylinebutton";
            this.MutilToPolylinebutton.Size = new System.Drawing.Size(159, 23);
            this.MutilToPolylinebutton.TabIndex = 17;
            this.MutilToPolylinebutton.Text = "批量提取Polygon";
            this.MutilToPolylinebutton.UseVisualStyleBackColor = true;
            this.MutilToPolylinebutton.Click += new System.EventHandler(this.MutilToPolylinebutton_Click);
            // 
            // MutlExtractCADForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 466);
            this.Controls.Add(this.MutilToPolylinebutton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.SavetextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.FilescheckedListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AnalyzeColorbutton);
            this.Controls.Add(this.ColorscheckedListBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FlodertextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MutlExtractCADForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "批量提取";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FlodertextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckedListBox ColorscheckedListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button AnalyzeColorbutton;
        private System.Windows.Forms.CheckedListBox FilescheckedListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox SavetextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button MutilToPolylinebutton;
    }
}