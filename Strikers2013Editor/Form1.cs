using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Strikers2013Editor
{
    public partial class Strikers2013Editor : Form
    {
        public Strikers2013Editor()
        {
            InitializeComponent();
        }

        private void movesFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MoveEditor moveEditor = new MoveEditor();

            moveEditor.ShowDialog();
        }
    }
}
