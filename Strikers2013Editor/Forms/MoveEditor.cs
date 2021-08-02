using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Strikers2013Editor.IO;
using Strikers2013Editor.Logic;
using Strikers2013Editor.Common;

namespace Strikers2013Editor.Forms
{
    public partial class MoveEditor : Form
    {
        byte[] moveFile;
        Move[] moves;
        string[] playerNames;
        string[] moveNames;
        public MoveEditor()
        {
            InitializeComponent();
            toolTip1.SetToolTip(chkUsers, "10 possible users");
            toolTip2.SetToolTip(chkUsers, "10 possible partners");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Move file (0/20.bin) (*.bin)|*.bin|All files (*.*)|*.*";
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    moveFile = File.ReadAllBytes(ofd.FileName);
                    var moveStream = new MemoryStream(moveFile);

                    listBox1.Enabled = true;
                    tabControl1.Enabled = true;
                    btnApply.Enabled = true;
                    exportToolStripMenuItem.Enabled = true;
                    saveToolStripMenuItem.Enabled = true;

                    ParseMoveFile(moveStream);
                    cmbTier.Items.AddRange(Enum.GetNames(typeof(Tier)));
                    cmbElement.Items.AddRange(Enum.GetNames(typeof(Element)));
                    cmbStatus.Items.AddRange(Enum.GetNames(typeof(Status)));
                    chkCoop.Items.AddRange(playerNames);
                    chkUsers.Items.AddRange(playerNames);


                }
            }
        }
        private void ParseMoveFile(Stream move)
        {
            // Gets the names of the moves
            moveNames = Names.GetTextFile("Strikers2013Editor.Common.wazaNames.txt");
            playerNames = Names.GetTextFile("Strikers2013Editor.Common.playernames.txt");

            // Parse the moves
            using (var br = new BeBinaryReader(move))
            {
                br.BaseStream.Position += 24;
                var moveCount = br.ReadInt32();
                moves = new Move[moveCount];
                for (var i = 0; i < moveCount; i++)
                {
                    moves[i] = new Move(br);
                    listBox1.Items.Add(moveNames[i]);
                }
            }


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var move = moves[listBox1.SelectedIndex];

            cmbTier.SelectedIndex = (int)move.Tier;
            nudPower.Value = move.BasePower;
            nudPowerMax.Value = move.MaxPower;
            nudTP.Value = move.Tp;
            cmbElement.SelectedIndex = (int)move.Element;
            cmbStatus.SelectedIndex = (int)move.Status;
            nudCoop.Value = move.CoopPartnersCount;


            chkUsers.SelectedIndex = -1;
            chkCoop.SelectedIndex = -1;

            for (var i = 0; i < playerNames.Length; i++)
            {
                chkUsers.SetItemChecked(i, false);
                chkCoop.SetItemChecked(i, false);
            }

            // waza_info[13] through waza_info[22] are for the users of the moves
            foreach (var user in move.Users)
            {
                if (user != 0)
                    chkUsers.SetItemChecked(user, true);
            }
            // waza_info[23] through waza_info[32] are for the co-op users of the moves
            foreach (var partner in move.Partners)
            {
                if (partner != 0)
                    chkCoop.SetItemChecked(partner, true);
            }


        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var move = moves[listBox1.SelectedIndex];

            move.Tier = (Tier)cmbTier.SelectedIndex;
            move.BasePower = (ushort)nudPower.Value;
            move.MaxPower = (ushort)nudPowerMax.Value;
            move.Tp = (ushort)nudTP.Value;
            move.Element = (Element)cmbElement.SelectedIndex;
            move.Status = (Status)cmbStatus.SelectedIndex;
            move.CoopPartnersCount = (ushort)nudCoop.Value;

            // Sets the users of the hissatsu
            var index = 0;
            for(var i = 0; i < chkUsers.CheckedIndices.Count; i++)
            {
                move.Users[index] = (ushort)chkUsers.CheckedIndices[i];
                index++;
            }
            for(var i = index; i < 10; i++)
            {
                move.Users[i] = 0;
            }

            // Sets the coop users of the hissatsu
            index = 0;
            for (var i = 0; i < chkCoop.CheckedIndices.Count; i++)
            {
                move.Partners[index] = (ushort)chkCoop.CheckedIndices[i];
                index++;
            }
            for (var i = index; i < 10; i++)
            {
                move.Partners[i] = 0;
            }

            moves[listBox1.SelectedIndex] = move;
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";
                sfd.DefaultExt = ".txt";
                sfd.FileName = "waza.txt";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var filename = sfd.FileName;
                    using (var sw = new StreamWriter(File.Open(filename, FileMode.Create)))
                    {
                        for (var i = 0; i < listBox1.Items.Count; i++)
                        {
                            var waza = moves[i];
                            sw.Write(moveNames[i]);
                            sw.Write(",");
                            foreach (var value in waza.wazaInfo)
                            {
                                sw.Write(value);
                                sw.Write(",");
                            }
                            sw.WriteLine();
                        }

                    }
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Move file(0 / 20.bin) (*.bin) | *.bin | All files(*.*) | *.* ";
                sfd.DefaultExt = ".bin";
                sfd.FileName = "waza.bin";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var filename = sfd.FileName;
                    var file = File.Open(filename, FileMode.Create);
                    using (var bw = new BeBinaryWriter(file))
                    {
                        bw.Write(moveFile);
                        bw.BaseStream.Position = 28;
                        foreach (var waza in moves)
                        {
                            waza.Write(bw);
                        }
                    }

                    MessageBox.Show("Succesfully saved.", "Done");


                }
            }

        }

        // Limited CheckedListBox because there are only 10 users/partners per hissatsu

        private void chkUsers_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (chkUsers.CheckedIndices.Count >= 10)
            {
                e.NewValue = CheckState.Unchecked;
            }
        }

        private void chkCoop_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (chkCoop.CheckedIndices.Count >= 10)
            {
                e.NewValue = CheckState.Unchecked;
            }
        }

        private void importToDatbinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "dat.bin (*.bin)|*.bin|All files (*.*)|*.*";
                ofd.RestoreDirectory = true;
                ofd.FileName = "dat.bin";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (var ofd1 = new OpenFileDialog())
                    {
                        ofd1.Filter = "mcb1.bln (*.bln)|*.bln|All files (*.*)|*.*";
                        ofd1.RestoreDirectory = true;
                        ofd1.FileName = "mcb1.bln";
                        if (ofd1.ShowDialog() == DialogResult.OK)
                        {
                            using (var br = new BinaryReader(File.OpenRead(ofd1.FileName)))
                            {
                                br.BaseStream.Position = 0xAC8F4;
                                var offset = br.ReadInt32();
                                var size = br.ReadInt32();
                                var data = br.ReadBytes(size);
                                using (var bw = new BinaryWriter(File.OpenWrite(ofd.FileName)))
                                {
                                    bw.BaseStream.Position = offset;
                                    bw.Write(data);
                                }
                            }
                            MessageBox.Show("Succesfully imported.", "Done");
                        }
                    }
                }
            }
        }

        private void cmbTier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
