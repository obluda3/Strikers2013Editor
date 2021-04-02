namespace Strikers2013Editor.Forms
{
    partial class SaveEditor
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dumpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnApply = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudSpeed = new System.Windows.Forms.NumericUpDown();
            this.nudCatch = new System.Windows.Forms.NumericUpDown();
            this.nudGuard = new System.Windows.Forms.NumericUpDown();
            this.nudControl = new System.Windows.Forms.NumericUpDown();
            this.nudBody = new System.Windows.Forms.NumericUpDown();
            this.nudKick = new System.Windows.Forms.NumericUpDown();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSP = new System.Windows.Forms.TextBox();
            this.txtCatch3 = new System.Windows.Forms.TextBox();
            this.txtCatch2 = new System.Windows.Forms.TextBox();
            this.txtCatch1 = new System.Windows.Forms.TextBox();
            this.txtDefense = new System.Windows.Forms.TextBox();
            this.txtDribble = new System.Windows.Forms.TextBox();
            this.txtLV3 = new System.Windows.Forms.TextBox();
            this.txtLV2 = new System.Windows.Forms.TextBox();
            this.txtLV1 = new System.Windows.Forms.TextBox();
            this.lstPlayers = new System.Windows.Forms.ListBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbTeam = new System.Windows.Forms.ComboBox();
            this.lstTeam = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudProfileOnline = new System.Windows.Forms.NumericUpDown();
            this.nudProfile = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOnlineName = new System.Windows.Forms.TextBox();
            this.txtProfileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.nudTP = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGuard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBody)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKick)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudProfileOnline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudProfile)).BeginInit();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTP)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(502, 24);
            this.menuStrip1.TabIndex = 1;
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
            this.openToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // dumpToolStripMenuItem
            // 
            this.dumpToolStripMenuItem.Enabled = false;
            this.dumpToolStripMenuItem.Name = "dumpToolStripMenuItem";
            this.dumpToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.dumpToolStripMenuItem.Text = "Dump";
            this.dumpToolStripMenuItem.Click += new System.EventHandler(this.dumpToolStripMenuItem_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnApply);
            this.tabPage3.Controls.Add(this.tabControl2);
            this.tabPage3.Controls.Add(this.lstPlayers);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(469, 439);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Players";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(387, 316);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(232, 6);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(234, 304);
            this.tabControl2.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.nudTP);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.nudSpeed);
            this.tabPage2.Controls.Add(this.nudCatch);
            this.tabPage2.Controls.Add(this.nudGuard);
            this.tabPage2.Controls.Add(this.nudControl);
            this.tabPage2.Controls.Add(this.nudBody);
            this.tabPage2.Controls.Add(this.nudKick);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(226, 278);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Stats";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 138);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 13);
            this.label19.TabIndex = 11;
            this.label19.Text = "Catch";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 112);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(38, 13);
            this.label18.TabIndex = 10;
            this.label18.Text = "Speed";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 86);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(36, 13);
            this.label17.TabIndex = 9;
            this.label17.Text = "Guard";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 60);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(40, 13);
            this.label16.TabIndex = 8;
            this.label16.Text = "Control";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 34);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(31, 13);
            this.label15.TabIndex = 7;
            this.label15.Text = "Body";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Kick";
            // 
            // nudSpeed
            // 
            this.nudSpeed.Enabled = false;
            this.nudSpeed.Location = new System.Drawing.Point(94, 110);
            this.nudSpeed.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nudSpeed.Name = "nudSpeed";
            this.nudSpeed.Size = new System.Drawing.Size(56, 20);
            this.nudSpeed.TabIndex = 5;
            // 
            // nudCatch
            // 
            this.nudCatch.Enabled = false;
            this.nudCatch.Location = new System.Drawing.Point(94, 136);
            this.nudCatch.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nudCatch.Name = "nudCatch";
            this.nudCatch.Size = new System.Drawing.Size(56, 20);
            this.nudCatch.TabIndex = 4;
            // 
            // nudGuard
            // 
            this.nudGuard.Enabled = false;
            this.nudGuard.Location = new System.Drawing.Point(94, 84);
            this.nudGuard.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nudGuard.Name = "nudGuard";
            this.nudGuard.Size = new System.Drawing.Size(56, 20);
            this.nudGuard.TabIndex = 3;
            // 
            // nudControl
            // 
            this.nudControl.Enabled = false;
            this.nudControl.Location = new System.Drawing.Point(94, 58);
            this.nudControl.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nudControl.Name = "nudControl";
            this.nudControl.Size = new System.Drawing.Size(56, 20);
            this.nudControl.TabIndex = 2;
            // 
            // nudBody
            // 
            this.nudBody.Enabled = false;
            this.nudBody.Location = new System.Drawing.Point(94, 32);
            this.nudBody.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nudBody.Name = "nudBody";
            this.nudBody.Size = new System.Drawing.Size(56, 20);
            this.nudBody.TabIndex = 1;
            // 
            // nudKick
            // 
            this.nudKick.Enabled = false;
            this.nudKick.Location = new System.Drawing.Point(94, 6);
            this.nudKick.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nudKick.Name = "nudKick";
            this.nudKick.Size = new System.Drawing.Size(56, 20);
            this.nudKick.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label14);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Controls.Add(this.label11);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.txtSP);
            this.tabPage4.Controls.Add(this.txtCatch3);
            this.tabPage4.Controls.Add(this.txtCatch2);
            this.tabPage4.Controls.Add(this.txtCatch1);
            this.tabPage4.Controls.Add(this.txtDefense);
            this.tabPage4.Controls.Add(this.txtDribble);
            this.tabPage4.Controls.Add(this.txtLV3);
            this.tabPage4.Controls.Add(this.txtLV2);
            this.tabPage4.Controls.Add(this.txtLV1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(226, 278);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Moves";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 217);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 13);
            this.label14.TabIndex = 24;
            this.label14.Text = "Catch 3";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 191);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "Catch 2";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 165);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Catch 1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 139);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Defense";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 113);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Dribble";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "SP";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Lv. 3";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Lv. 2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Lv. 1";
            // 
            // txtSP
            // 
            this.txtSP.Location = new System.Drawing.Point(94, 214);
            this.txtSP.Name = "txtSP";
            this.txtSP.Size = new System.Drawing.Size(56, 20);
            this.txtSP.TabIndex = 15;
            // 
            // txtCatch3
            // 
            this.txtCatch3.Location = new System.Drawing.Point(94, 188);
            this.txtCatch3.Name = "txtCatch3";
            this.txtCatch3.Size = new System.Drawing.Size(56, 20);
            this.txtCatch3.TabIndex = 14;
            // 
            // txtCatch2
            // 
            this.txtCatch2.Location = new System.Drawing.Point(94, 162);
            this.txtCatch2.Name = "txtCatch2";
            this.txtCatch2.Size = new System.Drawing.Size(56, 20);
            this.txtCatch2.TabIndex = 13;
            // 
            // txtCatch1
            // 
            this.txtCatch1.Location = new System.Drawing.Point(94, 136);
            this.txtCatch1.Name = "txtCatch1";
            this.txtCatch1.Size = new System.Drawing.Size(56, 20);
            this.txtCatch1.TabIndex = 12;
            // 
            // txtDefense
            // 
            this.txtDefense.Location = new System.Drawing.Point(94, 110);
            this.txtDefense.Name = "txtDefense";
            this.txtDefense.Size = new System.Drawing.Size(56, 20);
            this.txtDefense.TabIndex = 11;
            // 
            // txtDribble
            // 
            this.txtDribble.Location = new System.Drawing.Point(94, 84);
            this.txtDribble.Name = "txtDribble";
            this.txtDribble.Size = new System.Drawing.Size(56, 20);
            this.txtDribble.TabIndex = 10;
            // 
            // txtLV3
            // 
            this.txtLV3.Location = new System.Drawing.Point(94, 58);
            this.txtLV3.Name = "txtLV3";
            this.txtLV3.Size = new System.Drawing.Size(56, 20);
            this.txtLV3.TabIndex = 9;
            // 
            // txtLV2
            // 
            this.txtLV2.Location = new System.Drawing.Point(94, 32);
            this.txtLV2.Name = "txtLV2";
            this.txtLV2.Size = new System.Drawing.Size(56, 20);
            this.txtLV2.TabIndex = 8;
            // 
            // txtLV1
            // 
            this.txtLV1.Location = new System.Drawing.Point(94, 6);
            this.txtLV1.Name = "txtLV1";
            this.txtLV1.Size = new System.Drawing.Size(56, 20);
            this.txtLV1.TabIndex = 7;
            // 
            // lstPlayers
            // 
            this.lstPlayers.FormattingEnabled = true;
            this.lstPlayers.Location = new System.Drawing.Point(6, 6);
            this.lstPlayers.Name = "lstPlayers";
            this.lstPlayers.Size = new System.Drawing.Size(220, 420);
            this.lstPlayers.TabIndex = 1;
            this.lstPlayers.SelectedIndexChanged += new System.EventHandler(this.lstPlayers_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.nudProfileOnline);
            this.tabPage1.Controls.Add(this.nudProfile);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtOnlineName);
            this.tabPage1.Controls.Add(this.txtProfileName);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(469, 439);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbTeam);
            this.groupBox1.Controls.Add(this.lstTeam);
            this.groupBox1.Location = new System.Drawing.Point(191, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 317);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Team";
            // 
            // cmbTeam
            // 
            this.cmbTeam.FormattingEnabled = true;
            this.cmbTeam.Location = new System.Drawing.Point(6, 289);
            this.cmbTeam.Name = "cmbTeam";
            this.cmbTeam.Size = new System.Drawing.Size(132, 21);
            this.cmbTeam.TabIndex = 2;
            this.cmbTeam.SelectedIndexChanged += new System.EventHandler(this.cmbTeam_SelectedIndexChanged);
            // 
            // lstTeam
            // 
            this.lstTeam.FormattingEnabled = true;
            this.lstTeam.Location = new System.Drawing.Point(6, 19);
            this.lstTeam.Name = "lstTeam";
            this.lstTeam.Size = new System.Drawing.Size(260, 264);
            this.lstTeam.TabIndex = 1;
            this.lstTeam.SelectedIndexChanged += new System.EventHandler(this.lstTeam_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Online Picture";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Picture";
            // 
            // nudProfileOnline
            // 
            this.nudProfileOnline.Location = new System.Drawing.Point(85, 97);
            this.nudProfileOnline.Maximum = new decimal(new int[] {
            98,
            0,
            0,
            0});
            this.nudProfileOnline.Name = "nudProfileOnline";
            this.nudProfileOnline.Size = new System.Drawing.Size(51, 20);
            this.nudProfileOnline.TabIndex = 5;
            this.nudProfileOnline.ValueChanged += new System.EventHandler(this.nudProfileOnline_ValueChanged);
            // 
            // nudProfile
            // 
            this.nudProfile.Location = new System.Drawing.Point(85, 70);
            this.nudProfile.Maximum = new decimal(new int[] {
            98,
            0,
            0,
            0});
            this.nudProfile.Name = "nudProfile";
            this.nudProfile.Size = new System.Drawing.Size(51, 20);
            this.nudProfile.TabIndex = 4;
            this.nudProfile.ValueChanged += new System.EventHandler(this.nudProfile_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Online Name";
            // 
            // txtOnlineName
            // 
            this.txtOnlineName.Location = new System.Drawing.Point(85, 43);
            this.txtOnlineName.MaxLength = 16;
            this.txtOnlineName.Name = "txtOnlineName";
            this.txtOnlineName.Size = new System.Drawing.Size(100, 20);
            this.txtOnlineName.TabIndex = 2;
            this.txtOnlineName.TextChanged += new System.EventHandler(this.txtOnlineName_TextChanged);
            // 
            // txtProfileName
            // 
            this.txtProfileName.Location = new System.Drawing.Point(85, 17);
            this.txtProfileName.MaxLength = 16;
            this.txtProfileName.Name = "txtProfileName";
            this.txtProfileName.Size = new System.Drawing.Size(100, 20);
            this.txtProfileName.TabIndex = 1;
            this.txtProfileName.TextChanged += new System.EventHandler(this.txtProfileName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Profile Name";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Enabled = false;
            this.tabControl1.Location = new System.Drawing.Point(13, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(477, 465);
            this.tabControl1.TabIndex = 2;
            // 
            // nudTP
            // 
            this.nudTP.Enabled = false;
            this.nudTP.Location = new System.Drawing.Point(94, 162);
            this.nudTP.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.nudTP.Name = "nudTP";
            this.nudTP.Size = new System.Drawing.Size(56, 20);
            this.nudTP.TabIndex = 12;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 164);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(21, 13);
            this.label20.TabIndex = 13;
            this.label20.Text = "TP";
            // 
            // SaveEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 505);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "SaveEditor";
            this.Text = "SaveEditor";
            this.Load += new System.EventHandler(this.SaveEditor_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGuard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBody)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKick)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudProfileOnline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudProfile)).EndInit();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudTP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ListBox lstPlayers;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbTeam;
        private System.Windows.Forms.ListBox lstTeam;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudProfileOnline;
        private System.Windows.Forms.NumericUpDown nudProfile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOnlineName;
        private System.Windows.Forms.TextBox txtProfileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudSpeed;
        private System.Windows.Forms.NumericUpDown nudCatch;
        private System.Windows.Forms.NumericUpDown nudGuard;
        private System.Windows.Forms.NumericUpDown nudControl;
        private System.Windows.Forms.NumericUpDown nudBody;
        private System.Windows.Forms.NumericUpDown nudKick;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSP;
        private System.Windows.Forms.TextBox txtCatch3;
        private System.Windows.Forms.TextBox txtCatch2;
        private System.Windows.Forms.TextBox txtCatch1;
        private System.Windows.Forms.TextBox txtDefense;
        private System.Windows.Forms.TextBox txtDribble;
        private System.Windows.Forms.TextBox txtLV3;
        private System.Windows.Forms.TextBox txtLV2;
        private System.Windows.Forms.TextBox txtLV1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ToolStripMenuItem dumpToolStripMenuItem;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown nudTP;
    }
}