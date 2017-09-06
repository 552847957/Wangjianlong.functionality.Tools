namespace Wangjianlong.functionality.Tools.Forms.Mutiples
{
    partial class MutipleSelectForm
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
            this.MDBtextBox = new System.Windows.Forms.TextBox();
            this.SelectMDBbutton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SaveFiletextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Selectbutton = new System.Windows.Forms.Button();
            this.LayercomboBox = new System.Windows.Forms.ComboBox();
            this.FieldcomboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据库文件：";
            // 
            // MDBtextBox
            // 
            this.MDBtextBox.Location = new System.Drawing.Point(95, 25);
            this.MDBtextBox.Name = "MDBtextBox";
            this.MDBtextBox.ReadOnly = true;
            this.MDBtextBox.Size = new System.Drawing.Size(240, 21);
            this.MDBtextBox.TabIndex = 1;
            // 
            // SelectMDBbutton
            // 
            this.SelectMDBbutton.Location = new System.Drawing.Point(342, 25);
            this.SelectMDBbutton.Name = "SelectMDBbutton";
            this.SelectMDBbutton.Size = new System.Drawing.Size(35, 23);
            this.SelectMDBbutton.TabIndex = 2;
            this.SelectMDBbutton.Text = "...";
            this.SelectMDBbutton.UseVisualStyleBackColor = true;
            this.SelectMDBbutton.Click += new System.EventHandler(this.SelectMDBbutton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "图层列表：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "提取字段：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(342, 159);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SaveFiletextBox
            // 
            this.SaveFiletextBox.Location = new System.Drawing.Point(95, 159);
            this.SaveFiletextBox.Name = "SaveFiletextBox";
            this.SaveFiletextBox.ReadOnly = true;
            this.SaveFiletextBox.Size = new System.Drawing.Size(240, 21);
            this.SaveFiletextBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "保存文件：";
            // 
            // Selectbutton
            // 
            this.Selectbutton.Location = new System.Drawing.Point(94, 201);
            this.Selectbutton.Name = "Selectbutton";
            this.Selectbutton.Size = new System.Drawing.Size(75, 23);
            this.Selectbutton.TabIndex = 10;
            this.Selectbutton.Text = "Select";
            this.Selectbutton.UseVisualStyleBackColor = true;
            this.Selectbutton.Click += new System.EventHandler(this.Selectbutton_Click);
            // 
            // LayercomboBox
            // 
            this.LayercomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LayercomboBox.FormattingEnabled = true;
            this.LayercomboBox.Location = new System.Drawing.Point(95, 74);
            this.LayercomboBox.Name = "LayercomboBox";
            this.LayercomboBox.Size = new System.Drawing.Size(281, 20);
            this.LayercomboBox.TabIndex = 11;
            this.LayercomboBox.SelectedIndexChanged += new System.EventHandler(this.LayercomboBox_SelectedIndexChanged);
            // 
            // FieldcomboBox
            // 
            this.FieldcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FieldcomboBox.FormattingEnabled = true;
            this.FieldcomboBox.Location = new System.Drawing.Point(95, 115);
            this.FieldcomboBox.Name = "FieldcomboBox";
            this.FieldcomboBox.Size = new System.Drawing.Size(281, 20);
            this.FieldcomboBox.TabIndex = 12;
            // 
            // MutipleSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 239);
            this.Controls.Add(this.FieldcomboBox);
            this.Controls.Add(this.LayercomboBox);
            this.Controls.Add(this.Selectbutton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SaveFiletextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SelectMDBbutton);
            this.Controls.Add(this.MDBtextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MutipleSelectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "批量Select";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MDBtextBox;
        private System.Windows.Forms.Button SelectMDBbutton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox SaveFiletextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Selectbutton;
        private System.Windows.Forms.ComboBox LayercomboBox;
        private System.Windows.Forms.ComboBox FieldcomboBox;
    }
}