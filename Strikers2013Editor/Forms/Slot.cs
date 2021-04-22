using System;
using System.Windows.Forms;

namespace Strikers2013Editor.Forms
{
    public partial class Slot : Form
    {
        public int SlotIndex  { get; private set;}
        public Slot()
        {
            InitializeComponent();
            SlotIndex = 0;
        }

     
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                SlotIndex = 0;
            if (radioButton2.Checked)
                SlotIndex = 1;
            if (radioButton3.Checked)
                SlotIndex = 2;
            if (radioButton4.Checked)
                SlotIndex = 3;
            this.DialogResult = DialogResult.OK;

        }
    }
}
