using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Strikers2013Editor.IO;
using Strikers2013Editor.Base;

namespace Strikers2013Editor.Forms
{
    public partial class MoveEditor : Form
    {
        byte[] moveFile;
        Move[] moves;
        string[] playerNames;
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
                    cmbTier.Items.AddRange(new string[] { "Lv.1", "Lv.2", "Lv.3", "SP" });
                    cmbElement.Items.AddRange(new string[] { "Wind", "Wood", "Fire", "Earth", "Void", "???", "???", "???" });
                    cmbStatus.Items.AddRange(new string[] { "Normal", "Long", "Block", "Chain", "Punch 1", "Punch 2", });
                    chkCoop.Items.AddRange(playerNames);
                    chkUsers.Items.AddRange(playerNames);


                }
            }
        }

        private void ParseMoveFile(Stream move)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string[] moveNames;

            // Gets the names of the moves
            using (var movenamesfile = assembly.GetManifestResourceStream("Strikers2013Editor.Database.wazaNames.txt"))
            {
                using (StreamReader sr = new StreamReader(movenamesfile))
                {
                    var moveNamesList = new List<string>();
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        moveNamesList.Add(line);
                    }

                    moveNames = moveNamesList.ToArray();
                }
            }
            using (var playernamesfile = assembly.GetManifestResourceStream("Strikers2013Editor.Database.playernames.txt"))
            {
                using (StreamReader sr = new StreamReader(playernamesfile))
                {
                    var playerNamesList = new List<string>();
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        playerNamesList.Add(line);
                    }

                    playerNames = playerNamesList.ToArray();
                }
            }


            // Parse the moves
            using (var br = new BeBinaryReader(move))
            {
                br.BaseStream.Position += 24;
                var moveCount = br.ReadInt32();
                moves = new Move[moveCount];
                for (var i = 0; i < moveCount; i++)
                {
                    moves[i] = new Move();
                    moves[i].name = moveNames[i];
                    var wazaInfo = new ushort[70];
                    for (var _i = 0; _i < 70; _i++)
                    {
                        wazaInfo[_i] = br.ReadUInt16();
                    }
                    moves[i].wazaInfo = wazaInfo;
                    listBox1.Items.Add(moves[i].name);
                }
            }


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var wazainfo = moves[listBox1.SelectedIndex].wazaInfo;

            cmbTier.SelectedIndex = wazainfo[0];
            nudPower.Value = wazainfo[1];
            nudPowerMax.Value = wazainfo[2];
            nudTP.Value = wazainfo[3];
            cmbElement.SelectedIndex = wazainfo[4];
            cmbStatus.SelectedIndex = wazainfo[5];
            nudCoop.Value = wazainfo[10];


            chkUsers.SelectedIndex = -1;
            chkCoop.SelectedIndex = -1;

            for (var i = 0; i < playerNames.Length; i++)
            {
                chkUsers.SetItemChecked(i, false);
                chkCoop.SetItemChecked(i, false);
            }

            // waza_info[13] through waza_info[22] are for the users of the moves
            for (var i = 13; i < 23; i++)
            {
                if (wazainfo[i] != 0)
                    chkUsers.SetItemChecked(wazainfo[i], true);
            }
            // waza_info[23] through waza_info[32] are for the co-op users of the moves
            for (var i = 23; i < 33; i++)
            {
                if (wazainfo[i] != 0)
                    chkCoop.SetItemChecked(wazainfo[i], true);
            }


        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var wazainfo = moves[listBox1.SelectedIndex].wazaInfo;

            wazainfo[0] = (ushort)cmbTier.SelectedIndex;
            wazainfo[1] = (ushort)nudPower.Value;
            wazainfo[2] = (ushort)nudPowerMax.Value;
            wazainfo[3] = (ushort)nudTP.Value;
            wazainfo[4] = (ushort)cmbElement.SelectedIndex;
            wazainfo[5] = (ushort)cmbStatus.SelectedIndex;
            wazainfo[10] = (ushort)nudCoop.Value;

            // Sets the users of the hissatsu
            var index = 13;
            for(var i = 0; i < chkUsers.CheckedIndices.Count; i++)
            {
                wazainfo[index] = (ushort)chkUsers.CheckedIndices[i];
                index++;
            }
            for(var i = index; i < 23; i++)
            {
                wazainfo[i] = 0;
            }

            // Sets the coop users of the hissatsu
            index = 23;
            for (var i = 0; i < chkCoop.CheckedIndices.Count; i++)
            {
                wazainfo[index] = (ushort)chkCoop.CheckedIndices[i];
                index++;
            }
            for (var i = index; i < 33; i++)
            {
                wazainfo[i] = 0;
            }


            moves[listBox1.SelectedIndex].wazaInfo = wazainfo;
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
                            sw.Write(waza.name);
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
                            foreach (var info in waza.wazaInfo)
                                bw.Write(info);
                        }
                    }

                    MessageBox.Show("Succesfully saved.", "Done");


                }
            }

        }

        private void chkUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void chkUsers_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (chkUsers.CheckedIndices.Count >= 10)
            {
                e.NewValue = CheckState.Unchecked;
            }
        }
        private void chkCoop_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void chkCoop_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (chkCoop.CheckedIndices.Count >= 10)
            {
                e.NewValue = CheckState.Unchecked;
            }
        }
        public void LimitCheckedListBoxMaxSelection(int maxCount, EventArgs e, object list)
        {
            
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

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void cmbElement_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
