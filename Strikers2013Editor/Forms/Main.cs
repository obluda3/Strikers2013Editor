﻿using System;
using System.Windows.Forms;
using System.Text;

namespace Strikers2013Editor.Forms
{
    public partial class Strikers2013Editor : Form
    {
        public Strikers2013Editor()
        {
            InitializeComponent();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        private void movesFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MoveEditor moveEditor = new MoveEditor();

            moveEditor.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PlayerEditor playerEditor = new PlayerEditor();
            playerEditor.ShowDialog();
        }

        private void save_Click(object sender, EventArgs e)
        {
            SaveEditor saveEditor = new SaveEditor();
            saveEditor.ShowDialog();
        }

        private void Strikers2013Editor_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            TeamEditor teamEditor = new TeamEditor();
            teamEditor.ShowDialog();
        }

        private void btnMove2_Click(object sender, EventArgs e)
        {
            MoveInfoEditor moveAnimEditor = new MoveInfoEditor();
            moveAnimEditor.ShowDialog();
        }
    }
}
