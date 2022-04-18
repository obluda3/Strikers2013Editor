namespace Strikers2013Editor.Forms
{
    partial class MoveEditor
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnApply = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbElement = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nudTP = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudPowerMax = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudPower = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTier = new System.Windows.Forms.ComboBox();
            this.gbUsers = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chkCoop = new System.Windows.Forms.CheckedListBox();
            this.chkUsers = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.nudCoop = new System.Windows.Forms.NumericUpDown();
            this.gbAdvanced = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.nudOutRange = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbPowerup = new System.Windows.Forms.ComboBox();
            this.cmbMove = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.nudEffectRange = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.nudRangeAssist = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.gbMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPowerMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPower)).BeginInit();
            this.gbUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCoop)).BeginInit();
            this.gbAdvanced.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEffectRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRangeAssist)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(602, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // btnApply
            // 
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(515, 529);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 5;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // gbMain
            // 
            this.gbMain.Controls.Add(this.label6);
            this.gbMain.Controls.Add(this.cmbStatus);
            this.gbMain.Controls.Add(this.label5);
            this.gbMain.Controls.Add(this.cmbElement);
            this.gbMain.Controls.Add(this.label4);
            this.gbMain.Controls.Add(this.nudTP);
            this.gbMain.Controls.Add(this.label3);
            this.gbMain.Controls.Add(this.nudPowerMax);
            this.gbMain.Controls.Add(this.label2);
            this.gbMain.Controls.Add(this.nudPower);
            this.gbMain.Controls.Add(this.label1);
            this.gbMain.Controls.Add(this.cmbTier);
            this.gbMain.Enabled = false;
            this.gbMain.Location = new System.Drawing.Point(12, 65);
            this.gbMain.Name = "gbMain";
            this.gbMain.Size = new System.Drawing.Size(230, 247);
            this.gbMain.TabIndex = 6;
            this.gbMain.TabStop = false;
            this.gbMain.Text = "Main";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(81, 154);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbStatus.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Element";
            // 
            // cmbElement
            // 
            this.cmbElement.FormattingEnabled = true;
            this.cmbElement.Location = new System.Drawing.Point(81, 127);
            this.cmbElement.Name = "cmbElement";
            this.cmbElement.Size = new System.Drawing.Size(121, 21);
            this.cmbElement.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "TP";
            // 
            // nudTP
            // 
            this.nudTP.Location = new System.Drawing.Point(81, 100);
            this.nudTP.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudTP.Name = "nudTP";
            this.nudTP.Size = new System.Drawing.Size(50, 20);
            this.nudTP.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Max Power";
            // 
            // nudPowerMax
            // 
            this.nudPowerMax.Location = new System.Drawing.Point(81, 73);
            this.nudPowerMax.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudPowerMax.Name = "nudPowerMax";
            this.nudPowerMax.Size = new System.Drawing.Size(50, 20);
            this.nudPowerMax.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Power";
            // 
            // nudPower
            // 
            this.nudPower.Location = new System.Drawing.Point(81, 46);
            this.nudPower.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudPower.Name = "nudPower";
            this.nudPower.Size = new System.Drawing.Size(50, 20);
            this.nudPower.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Tier";
            // 
            // cmbTier
            // 
            this.cmbTier.FormattingEnabled = true;
            this.cmbTier.Location = new System.Drawing.Point(81, 19);
            this.cmbTier.Name = "cmbTier";
            this.cmbTier.Size = new System.Drawing.Size(121, 21);
            this.cmbTier.TabIndex = 14;
            // 
            // gbUsers
            // 
            this.gbUsers.Controls.Add(this.label9);
            this.gbUsers.Controls.Add(this.label8);
            this.gbUsers.Controls.Add(this.chkCoop);
            this.gbUsers.Controls.Add(this.chkUsers);
            this.gbUsers.Controls.Add(this.label7);
            this.gbUsers.Controls.Add(this.nudCoop);
            this.gbUsers.Enabled = false;
            this.gbUsers.Location = new System.Drawing.Point(248, 65);
            this.gbUsers.Name = "gbUsers";
            this.gbUsers.Size = new System.Drawing.Size(342, 458);
            this.gbUsers.TabIndex = 7;
            this.gbUsers.TabStop = false;
            this.gbUsers.Text = "Users and Partners";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 243);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Partners";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Users";
            // 
            // chkCoop
            // 
            this.chkCoop.FormattingEnabled = true;
            this.chkCoop.Location = new System.Drawing.Point(100, 236);
            this.chkCoop.Name = "chkCoop";
            this.chkCoop.Size = new System.Drawing.Size(229, 184);
            this.chkCoop.TabIndex = 23;
            // 
            // chkUsers
            // 
            this.chkUsers.FormattingEnabled = true;
            this.chkUsers.Location = new System.Drawing.Point(100, 46);
            this.chkUsers.Name = "chkUsers";
            this.chkUsers.Size = new System.Drawing.Size(229, 184);
            this.chkUsers.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Partners count";
            // 
            // nudCoop
            // 
            this.nudCoop.Location = new System.Drawing.Point(100, 20);
            this.nudCoop.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudCoop.Name = "nudCoop";
            this.nudCoop.Size = new System.Drawing.Size(79, 20);
            this.nudCoop.TabIndex = 18;
            // 
            // gbAdvanced
            // 
            this.gbAdvanced.Controls.Add(this.label14);
            this.gbAdvanced.Controls.Add(this.nudRangeAssist);
            this.gbAdvanced.Controls.Add(this.label13);
            this.gbAdvanced.Controls.Add(this.nudEffectRange);
            this.gbAdvanced.Controls.Add(this.label11);
            this.gbAdvanced.Controls.Add(this.nudOutRange);
            this.gbAdvanced.Controls.Add(this.label10);
            this.gbAdvanced.Controls.Add(this.cmbPowerup);
            this.gbAdvanced.Enabled = false;
            this.gbAdvanced.Location = new System.Drawing.Point(12, 318);
            this.gbAdvanced.Name = "gbAdvanced";
            this.gbAdvanced.Size = new System.Drawing.Size(230, 234);
            this.gbAdvanced.TabIndex = 8;
            this.gbAdvanced.TabStop = false;
            this.gbAdvanced.Text = "Advanced";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Range";
            // 
            // nudOutRange
            // 
            this.nudOutRange.Location = new System.Drawing.Point(152, 46);
            this.nudOutRange.Name = "nudOutRange";
            this.nudOutRange.Size = new System.Drawing.Size(50, 20);
            this.nudOutRange.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Power-up";
            // 
            // cmbPowerup
            // 
            this.cmbPowerup.FormattingEnabled = true;
            this.cmbPowerup.Location = new System.Drawing.Point(81, 19);
            this.cmbPowerup.Name = "cmbPowerup";
            this.cmbPowerup.Size = new System.Drawing.Size(121, 21);
            this.cmbPowerup.TabIndex = 26;
            this.cmbPowerup.SelectedIndexChanged += new System.EventHandler(this.cmbPowerup_SelectedIndexChanged);
            // 
            // cmbMove
            // 
            this.cmbMove.Enabled = false;
            this.cmbMove.FormattingEnabled = true;
            this.cmbMove.Location = new System.Drawing.Point(163, 32);
            this.cmbMove.Name = "cmbMove";
            this.cmbMove.Size = new System.Drawing.Size(264, 21);
            this.cmbMove.TabIndex = 9;
            this.cmbMove.SelectedIndexChanged += new System.EventHandler(this.cmbMove_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(123, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Move";
            // 
            // nudEffectRange
            // 
            this.nudEffectRange.Enabled = false;
            this.nudEffectRange.Location = new System.Drawing.Point(151, 72);
            this.nudEffectRange.Name = "nudEffectRange";
            this.nudEffectRange.Size = new System.Drawing.Size(50, 20);
            this.nudEffectRange.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 74);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 13);
            this.label13.TabIndex = 31;
            this.label13.Text = "Effect range";
            // 
            // nudRangeAssist
            // 
            this.nudRangeAssist.Enabled = false;
            this.nudRangeAssist.Location = new System.Drawing.Point(151, 98);
            this.nudRangeAssist.Name = "nudRangeAssist";
            this.nudRangeAssist.Size = new System.Drawing.Size(50, 20);
            this.nudRangeAssist.TabIndex = 32;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 100);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 13);
            this.label14.TabIndex = 33;
            this.label14.Text = "Range assist";
            // 
            // MoveEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 564);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbMove);
            this.Controls.Add(this.gbAdvanced);
            this.Controls.Add(this.gbUsers);
            this.Controls.Add(this.gbMain);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MoveEditor";
            this.Text = "MoveEditor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbMain.ResumeLayout(false);
            this.gbMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPowerMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPower)).EndInit();
            this.gbUsers.ResumeLayout(false);
            this.gbUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCoop)).EndInit();
            this.gbAdvanced.ResumeLayout(false);
            this.gbAdvanced.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEffectRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRangeAssist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.GroupBox gbMain;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbElement;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudTP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudPowerMax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudPower;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTier;
        private System.Windows.Forms.GroupBox gbUsers;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckedListBox chkCoop;
        private System.Windows.Forms.CheckedListBox chkUsers;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudCoop;
        private System.Windows.Forms.GroupBox gbAdvanced;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nudOutRange;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbPowerup;
        private System.Windows.Forms.ComboBox cmbMove;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown nudRangeAssist;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown nudEffectRange;
    }
}