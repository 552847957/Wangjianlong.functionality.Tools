namespace Wangjianlong.functionality.Tools.Forms.Mutiples
{
    partial class MutipleClipForm
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
            this.AccesstextBox = new System.Windows.Forms.TextBox();
            this.Accessbutton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.LayerscheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.FolderSavebutton = new System.Windows.Forms.Button();
            this.SaveFoldertextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.AnalyzeLayerbutton = new System.Windows.Forms.Button();
            this.SelectClipDataBasebutton = new System.Windows.Forms.Button();
            this.ClipDatabasetextBox = new System.Windows.Forms.TextBox();
            this.ReadClipbutton = new System.Windows.Forms.Button();
            this.ClipcheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.NotLayerbutton = new System.Windows.Forms.Button();
            this.AllLayerbutton = new System.Windows.Forms.Button();
            this.AllClipbutton = new System.Windows.Forms.Button();
            this.NotClipbutton = new System.Windows.Forms.Button();
            this.AntonymLayerButton = new System.Windows.Forms.Button();
            this.AntonymClipbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据文件：";
            // 
            // AccesstextBox
            // 
            this.AccesstextBox.Location = new System.Drawing.Point(86, 20);
            this.AccesstextBox.Name = "AccesstextBox";
            this.AccesstextBox.ReadOnly = true;
            this.AccesstextBox.Size = new System.Drawing.Size(252, 21);
            this.AccesstextBox.TabIndex = 1;
            // 
            // Accessbutton
            // 
            this.Accessbutton.Location = new System.Drawing.Point(344, 18);
            this.Accessbutton.Name = "Accessbutton";
            this.Accessbutton.Size = new System.Drawing.Size(38, 23);
            this.Accessbutton.TabIndex = 2;
            this.Accessbutton.Text = "...";
            this.Accessbutton.UseVisualStyleBackColor = true;
            this.Accessbutton.Click += new System.EventHandler(this.Accessbutton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "图层列表：";
            // 
            // LayerscheckedListBox
            // 
            this.LayerscheckedListBox.FormattingEnabled = true;
            this.LayerscheckedListBox.Location = new System.Drawing.Point(86, 65);
            this.LayerscheckedListBox.Name = "LayerscheckedListBox";
            this.LayerscheckedListBox.Size = new System.Drawing.Size(120, 212);
            this.LayerscheckedListBox.TabIndex = 4;
            // 
            // FolderSavebutton
            // 
            this.FolderSavebutton.Location = new System.Drawing.Point(341, 550);
            this.FolderSavebutton.Name = "FolderSavebutton";
            this.FolderSavebutton.Size = new System.Drawing.Size(38, 23);
            this.FolderSavebutton.TabIndex = 7;
            this.FolderSavebutton.Text = "...";
            this.FolderSavebutton.UseVisualStyleBackColor = true;
            this.FolderSavebutton.Click += new System.EventHandler(this.FolderSavebutton_Click);
            // 
            // SaveFoldertextBox
            // 
            this.SaveFoldertextBox.Location = new System.Drawing.Point(85, 552);
            this.SaveFoldertextBox.Name = "SaveFoldertextBox";
            this.SaveFoldertextBox.ReadOnly = true;
            this.SaveFoldertextBox.Size = new System.Drawing.Size(250, 21);
            this.SaveFoldertextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 555);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "保存目录：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(85, 590);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Clip";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "Clip数据库：";
            // 
            // AnalyzeLayerbutton
            // 
            this.AnalyzeLayerbutton.Location = new System.Drawing.Point(212, 65);
            this.AnalyzeLayerbutton.Name = "AnalyzeLayerbutton";
            this.AnalyzeLayerbutton.Size = new System.Drawing.Size(167, 23);
            this.AnalyzeLayerbutton.TabIndex = 11;
            this.AnalyzeLayerbutton.Text = "读取数据文件图层列表";
            this.AnalyzeLayerbutton.UseVisualStyleBackColor = true;
            this.AnalyzeLayerbutton.Click += new System.EventHandler(this.AnalyzeLayerbutton_Click);
            // 
            // SelectClipDataBasebutton
            // 
            this.SelectClipDataBasebutton.Location = new System.Drawing.Point(341, 295);
            this.SelectClipDataBasebutton.Name = "SelectClipDataBasebutton";
            this.SelectClipDataBasebutton.Size = new System.Drawing.Size(38, 23);
            this.SelectClipDataBasebutton.TabIndex = 13;
            this.SelectClipDataBasebutton.Text = "...";
            this.SelectClipDataBasebutton.UseVisualStyleBackColor = true;
            this.SelectClipDataBasebutton.Click += new System.EventHandler(this.SelectClipDataBasebutton_Click);
            // 
            // ClipDatabasetextBox
            // 
            this.ClipDatabasetextBox.Location = new System.Drawing.Point(85, 297);
            this.ClipDatabasetextBox.Name = "ClipDatabasetextBox";
            this.ClipDatabasetextBox.ReadOnly = true;
            this.ClipDatabasetextBox.Size = new System.Drawing.Size(250, 21);
            this.ClipDatabasetextBox.TabIndex = 12;
            // 
            // ReadClipbutton
            // 
            this.ReadClipbutton.Location = new System.Drawing.Point(212, 331);
            this.ReadClipbutton.Name = "ReadClipbutton";
            this.ReadClipbutton.Size = new System.Drawing.Size(167, 23);
            this.ReadClipbutton.TabIndex = 16;
            this.ReadClipbutton.Text = "读取Clip图层列表";
            this.ReadClipbutton.UseVisualStyleBackColor = true;
            this.ReadClipbutton.Click += new System.EventHandler(this.ReadClipbutton_Click);
            // 
            // ClipcheckedListBox
            // 
            this.ClipcheckedListBox.FormattingEnabled = true;
            this.ClipcheckedListBox.Location = new System.Drawing.Point(86, 331);
            this.ClipcheckedListBox.Name = "ClipcheckedListBox";
            this.ClipcheckedListBox.Size = new System.Drawing.Size(120, 212);
            this.ClipcheckedListBox.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 331);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "Clip图层列表：";
            // 
            // NotLayerbutton
            // 
            this.NotLayerbutton.Location = new System.Drawing.Point(304, 106);
            this.NotLayerbutton.Name = "NotLayerbutton";
            this.NotLayerbutton.Size = new System.Drawing.Size(75, 23);
            this.NotLayerbutton.TabIndex = 17;
            this.NotLayerbutton.Text = "全不选";
            this.NotLayerbutton.UseVisualStyleBackColor = true;
            this.NotLayerbutton.Click += new System.EventHandler(this.NotLayerbutton_Click);
            // 
            // AllLayerbutton
            // 
            this.AllLayerbutton.Location = new System.Drawing.Point(212, 106);
            this.AllLayerbutton.Name = "AllLayerbutton";
            this.AllLayerbutton.Size = new System.Drawing.Size(75, 23);
            this.AllLayerbutton.TabIndex = 18;
            this.AllLayerbutton.Text = "全选";
            this.AllLayerbutton.UseVisualStyleBackColor = true;
            this.AllLayerbutton.Click += new System.EventHandler(this.AllLayerbutton_Click);
            // 
            // AllClipbutton
            // 
            this.AllClipbutton.Location = new System.Drawing.Point(212, 373);
            this.AllClipbutton.Name = "AllClipbutton";
            this.AllClipbutton.Size = new System.Drawing.Size(75, 23);
            this.AllClipbutton.TabIndex = 20;
            this.AllClipbutton.Text = "全选";
            this.AllClipbutton.UseVisualStyleBackColor = true;
            this.AllClipbutton.Click += new System.EventHandler(this.AllClipbutton_Click);
            // 
            // NotClipbutton
            // 
            this.NotClipbutton.Location = new System.Drawing.Point(304, 373);
            this.NotClipbutton.Name = "NotClipbutton";
            this.NotClipbutton.Size = new System.Drawing.Size(75, 23);
            this.NotClipbutton.TabIndex = 19;
            this.NotClipbutton.Text = "全不选";
            this.NotClipbutton.UseVisualStyleBackColor = true;
            this.NotClipbutton.Click += new System.EventHandler(this.NotClipbutton_Click);
            // 
            // AntonymLayerButton
            // 
            this.AntonymLayerButton.Location = new System.Drawing.Point(212, 149);
            this.AntonymLayerButton.Name = "AntonymLayerButton";
            this.AntonymLayerButton.Size = new System.Drawing.Size(75, 23);
            this.AntonymLayerButton.TabIndex = 21;
            this.AntonymLayerButton.Text = "反选";
            this.AntonymLayerButton.UseVisualStyleBackColor = true;
            this.AntonymLayerButton.Click += new System.EventHandler(this.AntonymLayerButton_Click);
            // 
            // AntonymClipbutton
            // 
            this.AntonymClipbutton.Location = new System.Drawing.Point(212, 415);
            this.AntonymClipbutton.Name = "AntonymClipbutton";
            this.AntonymClipbutton.Size = new System.Drawing.Size(75, 23);
            this.AntonymClipbutton.TabIndex = 22;
            this.AntonymClipbutton.Text = "反选";
            this.AntonymClipbutton.UseVisualStyleBackColor = true;
            this.AntonymClipbutton.Click += new System.EventHandler(this.AntonymClipbutton_Click);
            // 
            // MutipleClipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 622);
            this.Controls.Add(this.AntonymClipbutton);
            this.Controls.Add(this.AntonymLayerButton);
            this.Controls.Add(this.AllClipbutton);
            this.Controls.Add(this.NotClipbutton);
            this.Controls.Add(this.AllLayerbutton);
            this.Controls.Add(this.NotLayerbutton);
            this.Controls.Add(this.ReadClipbutton);
            this.Controls.Add(this.ClipcheckedListBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SelectClipDataBasebutton);
            this.Controls.Add(this.ClipDatabasetextBox);
            this.Controls.Add(this.AnalyzeLayerbutton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FolderSavebutton);
            this.Controls.Add(this.SaveFoldertextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LayerscheckedListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Accessbutton);
            this.Controls.Add(this.AccesstextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MutipleClipForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "批量Clip";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AccesstextBox;
        private System.Windows.Forms.Button Accessbutton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox LayerscheckedListBox;
        private System.Windows.Forms.Button FolderSavebutton;
        private System.Windows.Forms.TextBox SaveFoldertextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button AnalyzeLayerbutton;
        private System.Windows.Forms.Button SelectClipDataBasebutton;
        private System.Windows.Forms.TextBox ClipDatabasetextBox;
        private System.Windows.Forms.Button ReadClipbutton;
        private System.Windows.Forms.CheckedListBox ClipcheckedListBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button NotLayerbutton;
        private System.Windows.Forms.Button AllLayerbutton;
        private System.Windows.Forms.Button AllClipbutton;
        private System.Windows.Forms.Button NotClipbutton;
        private System.Windows.Forms.Button AntonymLayerButton;
        private System.Windows.Forms.Button AntonymClipbutton;
    }
}