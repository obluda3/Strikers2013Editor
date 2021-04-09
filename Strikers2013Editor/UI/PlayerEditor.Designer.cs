namespace Strikers2013Editor.Forms
{
    partial class PlayerEditor
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
            this.btnApply = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSex = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTA = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbElement = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbBody = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.nudFace2 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudFace = new System.Windows.Forms.NumericUpDown();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dumpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFace2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFace)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(253, 221);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 9;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Enabled = false;
            this.tabControl1.Location = new System.Drawing.Point(248, 34);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(341, 181);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cmbSex);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cmbTA);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.cmbElement);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cmbPosition);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(333, 155);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Gender";
            // 
            // cmbSex
            // 
            this.cmbSex.FormattingEnabled = true;
            this.cmbSex.Location = new System.Drawing.Point(75, 89);
            this.cmbSex.Name = "cmbSex";
            this.cmbSex.Size = new System.Drawing.Size(121, 21);
            this.cmbSex.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "TA";
            // 
            // cmbTA
            // 
            this.cmbTA.FormattingEnabled = true;
            this.cmbTA.Location = new System.Drawing.Point(75, 61);
            this.cmbTA.Name = "cmbTA";
            this.cmbTA.Size = new System.Drawing.Size(121, 21);
            this.cmbTA.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Element";
            // 
            // cmbElement
            // 
            this.cmbElement.FormattingEnabled = true;
            this.cmbElement.Location = new System.Drawing.Point(75, 33);
            this.cmbElement.Name = "cmbElement";
            this.cmbElement.Size = new System.Drawing.Size(121, 21);
            this.cmbElement.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Position";
            // 
            // cmbPosition
            // 
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Location = new System.Drawing.Point(75, 6);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(121, 21);
            this.cmbPosition.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.nudHeight);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.cmbBody);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.nudFace2);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.nudFace);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(333, 155);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Advanced";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Height";
            // 
            // nudHeight
            // 
            this.nudHeight.Location = new System.Drawing.Point(98, 58);
            this.nudHeight.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudHeight.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.nudHeight.Name = "nudHeight";
            this.nudHeight.Size = new System.Drawing.Size(79, 20);
            this.nudHeight.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Bodytype";
            // 
            // cmbBody
            // 
            this.cmbBody.FormattingEnabled = true;
            this.cmbBody.Location = new System.Drawing.Point(98, 84);
            this.cmbBody.Name = "cmbBody";
            this.cmbBody.Size = new System.Drawing.Size(121, 21);
            this.cmbBody.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Face Model";
            // 
            // nudFace2
            // 
            this.nudFace2.Location = new System.Drawing.Point(98, 32);
            this.nudFace2.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudFace2.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.nudFace2.Name = "nudFace2";
            this.nudFace2.Size = new System.Drawing.Size(79, 20);
            this.nudFace2.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Face Model";
            // 
            // nudFace
            // 
            this.nudFace.Location = new System.Drawing.Point(98, 6);
            this.nudFace.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudFace.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.nudFace.Name = "nudFace";
            this.nudFace.Size = new System.Drawing.Size(79, 20);
            this.nudFace.TabIndex = 19;
            // 
            // listBox1
            // 
            this.listBox1.Enabled = false;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 33);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(230, 381);
            this.listBox1.TabIndex = 7;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(604, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.dumpToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // dumpToolStripMenuItem
            // 
            this.dumpToolStripMenuItem.Enabled = false;
            this.dumpToolStripMenuItem.Name = "dumpToolStripMenuItem";
            this.dumpToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dumpToolStripMenuItem.Text = "Dump";
            this.dumpToolStripMenuItem.Click += new System.EventHandler(this.dumpToolStripMenuItem_Click);
            // 
            // PlayerEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 436);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "PlayerEditor";
            this.Text = "PlayerEditor";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFace2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFace)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbElement;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudFace2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudFace;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbBody;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudHeight;
        private System.Windows.Forms.ToolStripMenuItem dumpToolStripMenuItem;
    }
}