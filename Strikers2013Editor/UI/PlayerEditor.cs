using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Strikers2013Editor.IO;
using Strikers2013Editor.Base;

namespace Strikers2013Editor.Forms
{
    public partial class PlayerEditor : Form
    {
        byte[] playerFile;
        PlayerInfo[] Players;
        public PlayerEditor()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Move file (0/104.bin) (*.bin)|*.bin|All files (*.*)|*.*";
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    playerFile = File.ReadAllBytes(ofd.FileName);
                    var moveStream = new MemoryStream(playerFile);

                    listBox1.Enabled = true;
                    tabControl1.Enabled = true;
                    btnApply.Enabled = true;
                    saveToolStripMenuItem.Enabled = true;
                    dumpToolStripMenuItem.Enabled = true;

                    ParsePlayerFile(moveStream);
                    cmbElement.Items.AddRange(new string[] { "Wind", "Wood", "Fire", "Earth", "Void", "???", "???", "???" });
                    cmbPosition.Items.AddRange(new string[] { "GK", "DF", "MF", "FW", });
                    cmbTA.Items.AddRange(new string[] { "Feint", "Roll", "Short", "Jump", "White Sprint", "Red Sprint", "Girl" });
                    cmbSex.Items.AddRange(new string[] { "Male", "Female", "Other" });
                    cmbBody.Items.AddRange(new string[] { "Man", "Large", "Chibi", "Muscle", "Girl1", "Girl2" });
                }
            }
        }
        private void ParsePlayerFile(Stream player)
        {
            using (var br = new BeBinaryReader(player))
            {
                br.BaseStream.Position = 0xFA4;
                var playerList = new List<PlayerInfo>();
                Console.WriteLine("test");
                for (var i = 0; i < 0x198; i++)
                {
                    if (br.BaseStream.Position > br.BaseStream.Length - 0x148)
                        break;
                    var player1 = new PlayerInfo();
                    player1.ID = br.ReadInt32();
                    player1.padding = br.ReadInt32();
                    player1.shortName2 = br.ReadInt32(); // 14.bin line minus 4
                    player1.shortName = br.ReadInt32(); // 14.bin line minus 4
                    player1.fullName = br.ReadInt32(); // 14.bin line minus 4
                    player1.name = Encoding.ASCII.GetString(br.ReadBytes(24));
                    player1.gender = br.ReadInt32();
                    player1.unk1 = br.ReadInt32();
                    player1.unk2 = br.ReadInt32();
                    player1.description = br.ReadInt32(); // 14.bin line minus 2
                    player1.bodytype = br.ReadInt32();
                    player1.height = br.ReadInt32();
                    player1.unk4 = br.ReadInt32();
                    player1.tacticalaction = br.ReadInt32();
                    player1.unk3 = br.ReadInt32();
                    player1.team2 = br.ReadInt32();
                    player1.team = br.ReadInt32();
                    player1.playerListPortrait = br.ReadInt32();
                    player1.position = br.ReadInt32();
                    player1.unk8 = br.ReadInt32();
                    player1.facemodel = br.ReadInt32(); // I'm assuming both of them are the face models but i'm not sure
                    player1.facemodel2 = br.ReadInt32();
                    player1.unk9 = br.ReadInt32();
                    player1.unk10 = br.ReadInt32();
                    player1.unk11 = br.ReadInt32();
                    player1.playerMugshot = br.ReadInt32();
                    player1.unk12 = br.ReadInt32();
                    player1.playerPortrait = br.ReadInt32();
                    player1.playerOtherPortrait = br.ReadInt32();
                    br.BaseStream.Position += 12 * 8;
                    player1.unk13 = br.ReadInt32();
                    player1.unk14 = br.ReadInt32();
                    player1.unk15 = br.ReadInt32();
                    player1.element = br.ReadInt32();
                    player1.unk16 = br.ReadInt32();
                    player1.unk17 = br.ReadInt32();
                    player1.unk18 = br.ReadInt32();
                    player1.unk19 = br.ReadInt32();
                    player1.armedAttribution = br.ReadInt32();
                    player1.unk21 = br.ReadInt32();
                    player1.price = br.ReadInt16();
                    player1.unk23 = br.ReadInt16();
                    player1.unk24 = br.ReadInt32();
                    player1.unk25 = br.ReadInt32();
                    player1.pad2 = br.ReadBytes(44);

                    playerList.Add(player1);

                    listBox1.Items.Add(player1.name);
                }

                Players = playerList.ToArray();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var player = Players[listBox1.SelectedIndex];

            cmbPosition.SelectedIndex = player.position > 0 ? player.position - 0x22 : player.position;
            cmbTA.SelectedIndex = player.tacticalaction - 0x14;
            cmbSex.SelectedIndex = player.gender;
            cmbElement.SelectedIndex = player.element;
            cmbBody.SelectedIndex = player.bodytype;
            nudFace.Value = player.facemodel;
            nudFace2.Value = player.facemodel2;
            nudHeight.Value = player.height;

        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var player = Players[listBox1.SelectedIndex];

            player.position = cmbPosition.SelectedIndex > 0 ? cmbPosition.SelectedIndex + 0x22 : 0;
            player.tacticalaction = cmbTA.SelectedIndex + 0x14;
            player.gender = cmbSex.SelectedIndex;
            player.element = cmbElement.SelectedIndex;
            player.facemodel = (int)nudFace.Value;
            player.facemodel2 = (int)nudFace2.Value;
            player.height = (int)nudHeight.Value;
            player.bodytype = cmbBody.SelectedIndex;


            Players[listBox1.SelectedIndex] = player;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Move file(0 / 104.bin) (*.bin) | *.bin | All files(*.*) | *.* ";
                sfd.DefaultExt = ".bin";
                sfd.FileName = "players.bin";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var filename = sfd.FileName;
                    var file = File.Open(filename, FileMode.Create);
                    using (var bw = new BeBinaryWriter(file))
                    {
                        bw.Write(playerFile);
                        bw.BaseStream.Position = 0xFA4;
                        foreach (var player in Players)
                        {
                            bw.Write(player.ID);
                            bw.Write(player.padding);
                            bw.Write(player.shortName2); // 14.bin line minus 4
                            bw.Write(player.shortName); // 14.bin line minus 4
                            bw.Write(player.fullName); // 14.bin line minus 4
                            bw.Write(Encoding.ASCII.GetBytes(player.name));
                            bw.Write(player.gender);
                            bw.Write(player.unk1);
                            bw.Write(player.unk2);
                            bw.Write(player.description); // 14.bin line minus 2
                            bw.Write(player.bodytype);
                            bw.Write(player.height);
                            bw.Write(player.unk4);
                            bw.Write(player.tacticalaction);
                            bw.Write(player.unk3);
                            bw.Write(player.team2);
                            bw.Write(player.team);
                            bw.Write(player.playerListPortrait);
                            bw.Write(player.position);
                            bw.Write(player.unk8);
                            bw.Write(player.facemodel);
                            bw.Write(player.facemodel2);
                            bw.Write(player.unk9);
                            bw.Write(player.unk10);
                            bw.Write(player.unk11);
                            bw.Write(player.playerMugshot);
                            bw.Write(player.unk12);
                            bw.Write(player.playerPortrait);
                            bw.Write(player.playerOtherPortrait);
                            bw.BaseStream.Position += 12 * 8;
                            bw.Write(player.unk13);
                            bw.Write(player.unk14);
                            bw.Write(player.unk15);
                            bw.Write(player.element);
                            bw.Write(player.unk16);
                            bw.Write(player.unk17);
                            bw.Write(player.unk18);
                            bw.Write(player.unk19);
                            bw.Write(player.armedAttribution);
                            bw.Write(player.unk21);
                            bw.Write(player.price);
                            bw.Write(player.unk23);
                            bw.Write(player.unk24);
                            bw.Write(player.unk25);
                            bw.Write(player.pad2);
                        }
                    }

                    MessageBox.Show("Succesfully saved.", "Done");


                }
            }

        }

        private void dumpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text file (*.txt) | *.txt | All files(*.*) | *.* ";
                sfd.DefaultExt = ".txt";
                sfd.FileName = "players.txt";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var sw = new StreamWriter(File.Open(sfd.FileName, FileMode.Create)))
                    {
                        /// BEHOLD THE UGLIEST CODE EVER
                        /// 
                        var plinfo = new PlayerInfo();
                        sw.Write(nameof(plinfo.ID));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.padding));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.shortName2)); // 14.bin line minus 4
                        sw.Write(",");
                        sw.Write(nameof(plinfo.shortName)); // 14.bin line minus 4
                        sw.Write(",");
                        sw.Write(nameof(plinfo.fullName)); // 14.bin line minus 4
                        sw.Write(",");
                        sw.Write(nameof(plinfo.name));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.gender));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.unk1));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.unk2));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.description)); // 14.bin line minus 2
                        sw.Write(",");
                        sw.Write(nameof(plinfo.bodytype));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.height));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.unk4));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.tacticalaction));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.unk3));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.team2));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.team));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.playerListPortrait));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.position));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.unk8));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.facemodel));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.facemodel2));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.unk9));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.unk10));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.unk11));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.playerMugshot));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.unk12));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.playerPortrait));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.playerOtherPortrait));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.unk13));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.unk14));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.unk15));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.element));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.unk16));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.unk17));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.unk18));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.unk19));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.armedAttribution));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.unk21));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.price));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.unk23));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.unk24));
                        sw.Write(",");
                        sw.Write(nameof(plinfo.unk25));
                        sw.Write("\n");
                        foreach (var player in Players)
                        {
                            sw.Write(player.ID);
                            sw.Write(",");
                            sw.Write(player.padding);
                            sw.Write(",");
                            sw.Write(player.shortName2); // 14.bin line minus 4
                            sw.Write(",");
                            sw.Write(player.shortName); // 14.bin line minus 4
                            sw.Write(",");
                            sw.Write(player.fullName); // 14.bin line minus 4
                            sw.Write(",");
                            sw.Write(player.name);
                            sw.Write(",");
                            sw.Write(player.gender);
                            sw.Write(",");
                            sw.Write(player.unk1);
                            sw.Write(",");
                            sw.Write(player.unk2);
                            sw.Write(",");
                            sw.Write(player.description); // 14.bin line minus 2
                            sw.Write(",");
                            sw.Write(player.bodytype);
                            sw.Write(",");
                            sw.Write(player.height);
                            sw.Write(",");
                            sw.Write(player.unk4);
                            sw.Write(",");
                            sw.Write(player.tacticalaction);
                            sw.Write(",");
                            sw.Write(player.unk3);
                            sw.Write(",");
                            sw.Write(player.team2);
                            sw.Write(",");
                            sw.Write(player.team);
                            sw.Write(",");
                            sw.Write(player.playerListPortrait);
                            sw.Write(",");
                            sw.Write(player.position);
                            sw.Write(",");
                            sw.Write(player.unk8);
                            sw.Write(",");
                            sw.Write(player.facemodel);
                            sw.Write(",");
                            sw.Write(player.facemodel2);
                            sw.Write(",");
                            sw.Write(player.unk9);
                            sw.Write(",");
                            sw.Write(player.unk10);
                            sw.Write(",");
                            sw.Write(player.unk11);
                            sw.Write(",");
                            sw.Write(player.playerMugshot);
                            sw.Write(",");
                            sw.Write(player.unk12);
                            sw.Write(",");
                            sw.Write(player.playerPortrait);
                            sw.Write(",");
                            sw.Write(player.playerOtherPortrait);
                            sw.Write(",");
                            sw.Write(player.unk13);
                            sw.Write(",");
                            sw.Write(player.unk14);
                            sw.Write(",");
                            sw.Write(player.unk15);
                            sw.Write(",");
                            sw.Write(player.element);
                            sw.Write(",");
                            sw.Write(player.unk16);
                            sw.Write(",");
                            sw.Write(player.unk17);
                            sw.Write(",");
                            sw.Write(player.unk18);
                            sw.Write(",");
                            sw.Write(player.unk19);
                            sw.Write(",");
                            sw.Write(player.armedAttribution);
                            sw.Write(",");
                            sw.Write(player.unk21);
                            sw.Write(",");
                            sw.Write(player.price);
                            sw.Write(",");
                            sw.Write(player.unk23);
                            sw.Write(",");
                            sw.Write(player.unk24);
                            sw.Write(",");
                            sw.Write(player.unk25);
                            sw.Write("\n");
                        }
                    }
                }
            } 
        } 
    }
}
