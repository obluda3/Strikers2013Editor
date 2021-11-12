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
        private byte[] data;
        private Move[] moves;
        private string[] playerNames;
        private string[] moveNames;
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
                    data = File.ReadAllBytes(ofd.FileName);

                    cmbMove.Enabled = true;
                    gbMain.Enabled = true;
                    gbAdvanced.Enabled = true;
                    gbUsers.Enabled = true;
                    btnApply.Enabled = true;
                    saveToolStripMenuItem.Enabled = true;

                    ParseMoveFile(File.OpenRead(ofd.FileName));
                    cmbTier.Items.AddRange(Enum.GetNames(typeof(Tier)));
                    cmbElement.Items.AddRange(Enum.GetNames(typeof(Element)));
                    cmbStatus.Items.AddRange(Enum.GetNames(typeof(Status)));
                    cmbPowerup.Items.AddRange(Enum.GetNames(typeof(PowerUpIndicator)));
                    chkCoop.Items.AddRange(playerNames);
                    chkCoop.Items[0] = "Anyone";
                    chkUsers.Items.AddRange(playerNames);
                    cmbMove.SelectedIndex = 0;


                }
            }
        }
        private void ParseMoveFile(Stream move)
        {
            // Gets the names of the moves
            moveNames = Names.GetTextFile("Strikers2013Editor.Common.wazaNames.txt");
            playerNames = Names.GetTextFile("Strikers2013Editor.Common.playerNames.txt");

            // Parse the moves
            using (var br = new BeBinaryReader(move))
            {
                br.BaseStream.Position += 24;
                var moveCount = br.ReadInt32();
                moves = new Move[moveCount];
                for (var i = 0; i < moveCount; i++)
                {
                    moves[i] = new Move(br);
                    cmbMove.Items.Add(moveNames[i]);
                }
            }


        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var move = moves[cmbMove.SelectedIndex];

            move.Tier = (Tier)cmbTier.SelectedIndex;
            move.BasePower = (ushort)nudPower.Value;
            move.MaxPower = (ushort)nudPowerMax.Value;
            move.Tp = (ushort)nudTP.Value;
            move.Element = (Element)cmbElement.SelectedIndex;
            move.Status = (Status)cmbStatus.SelectedIndex;
            move.PowerUpIndicator = (PowerUpIndicator)cmbPowerup.SelectedIndex;
            move.Range = (ushort)nudRange.Value;
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

            moves[cmbMove.SelectedIndex] = move;
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
                        bw.Write(data);
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

        private void cmbMove_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMove.SelectedIndex = cmbMove.SelectedIndex != 0 ? cmbMove.SelectedIndex : 1;
            var move = moves[cmbMove.SelectedIndex];

            cmbTier.SelectedIndex = (int)move.Tier;
            nudPower.Value = move.BasePower;
            nudPowerMax.Value = move.MaxPower;
            nudTP.Value = move.Tp;
            cmbElement.SelectedIndex = (int)move.Element;
            cmbStatus.SelectedIndex = (int)move.Status;
            cmbPowerup.SelectedIndex = (int)move.PowerUpIndicator;
            nudCoop.Value = move.CoopPartnersCount;
            nudRange.Value = move.Range;


            chkUsers.SelectedIndex = -1;
            chkCoop.SelectedIndex = -1;

            for (var i = 0; i < playerNames.Length; i++)
            {
                chkUsers.SetItemChecked(i, false);
                chkCoop.SetItemChecked(i, false);
            }

            foreach (var user in move.Users)
            {
                if (user != 0)
                    chkUsers.SetItemChecked(user, true);
            }
            for (var i = 0; i < move.Partners.Length; i++)
            {
                var partner = move.Partners[i];
                if (partner != 0 || ((partner == 0) && (i == 0)))
                    chkCoop.SetItemChecked(partner, true);
            }


        }

        private void cmbPowerup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
