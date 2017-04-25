namespace Wangjianlong.functionality.Tools.Forms
{
    partial class ExtractCADForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtractCADForm));
            this.label1 = new System.Windows.Forms.Label();
            this.CADtextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.LayerscheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ColorscheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SaveFiletextBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.ExtractButton = new System.Windows.Forms.Button();
            this.ExtractTYbutton = new System.Windows.Forms.Button();
            this.MutExtractbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "CAD文件：";
            // 
            // CADtextBox
            // 
            this.CADtextBox.Location = new System.Drawing.Point(79, 20);
            this.CADtextBox.Name = "CADtextBox";
            this.CADtextBox.ReadOnly = true;
            this.CADtextBox.Size = new System.Drawing.Size(262, 21);
            this.CADtextBox.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(344, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "图层列表：";
            // 
            // LayerscheckedListBox
            // 
            this.LayerscheckedListBox.FormattingEnabled = true;
            this.LayerscheckedListBox.Location = new System.Drawing.Point(79, 96);
            this.LayerscheckedListBox.Name = "LayerscheckedListBox";
            this.LayerscheckedListBox.Size = new System.Drawing.Size(120, 228);
            this.LayerscheckedListBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(219, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "颜色列表：";
            // 
            // ColorscheckedListBox
            // 
            this.ColorscheckedListBox.FormattingEnabled = true;
            this.ColorscheckedListBox.Location = new System.Drawing.Point(221, 96);
            this.ColorscheckedListBox.Name = "ColorscheckedListBox";
            this.ColorscheckedListBox.Size = new System.Drawing.Size(120, 228);
            this.ColorscheckedListBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 343);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "输出文件：";
            // 
            // SaveFiletextBox
            // 
            this.SaveFiletextBox.Location = new System.Drawing.Point(79, 340);
            this.SaveFiletextBox.Name = "SaveFiletextBox";
            this.SaveFiletextBox.ReadOnly = true;
            this.SaveFiletextBox.Size = new System.Drawing.Size(262, 21);
            this.SaveFiletextBox.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(344, 338);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(45, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ExtractButton
            // 
            this.ExtractButton.Location = new System.Drawing.Point(79, 390);
            this.ExtractButton.Name = "ExtractButton";
            this.ExtractButton.Size = new System.Drawing.Size(75, 23);
            this.ExtractButton.TabIndex = 11;
            this.ExtractButton.Text = "提取";
            this.ExtractButton.UseVisualStyleBackColor = true;
            this.ExtractButton.Click += new System.EventHandler(this.ExtractButton_Click);
            // 
            // ExtractTYbutton
            // 
            this.ExtractTYbutton.Location = new System.Drawing.Point(178, 390);
            this.ExtractTYbutton.Name = "ExtractTYbutton";
            this.ExtractTYbutton.Size = new System.Drawing.Size(94, 23);
            this.ExtractTYbutton.TabIndex = 12;
            this.ExtractTYbutton.Text = "提取（唐尧）";
            this.ExtractTYbutton.UseVisualStyleBackColor = true;
            this.ExtractTYbutton.Click += new System.EventHandler(this.ExtractTYbutton_Click);
            // 
            // MutExtractbutton
            // 
            this.MutExtractbutton.Location = new System.Drawing.Point(296, 390);
            this.MutExtractbutton.Name = "MutExtractbutton";
            this.MutExtractbutton.Size = new System.Drawing.Size(75, 23);
            this.MutExtractbutton.TabIndex = 13;
            this.MutExtractbutton.Text = "批量提取";
            this.MutExtractbutton.UseVisualStyleBackColor = true;
            this.MutExtractbutton.Click += new System.EventHandler(this.MutExtractbutton_Click);
            // 
            // ExtractCADForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 425);
            this.Controls.Add(this.MutExtractbutton);
            this.Controls.Add(this.ExtractTYbutton);
            this.Controls.Add(this.ExtractButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.SaveFiletextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ColorscheckedListBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LayerscheckedListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CADtextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExtractCADForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "提取CAD图层";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CADtextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox LayerscheckedListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox ColorscheckedListBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SaveFiletextBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button ExtractButton;
        private System.Windows.Forms.Button ExtractTYbutton;
        private System.Windows.Forms.Button MutExtractbutton;
    }
}