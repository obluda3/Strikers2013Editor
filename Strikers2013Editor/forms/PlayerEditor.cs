using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Be.IO;

namespace Strikers2013Editor
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

                    ParsePlayerFile(moveStream);
                    cmbElement.Items.AddRange(new string[] { "Wind", "Wood", "Fire", "Earth", "Void", "???", "???", "???" });
                    cmbPosition.Items.AddRange(new string[] { "GK", "DF", "MF", "FW",});
                    cmbTA.Items.AddRange(new string[] { "Feint", "Roll", "Short","Jump","White Sprint","Red Sprint","Girl" }) ;
                    cmbSex.Items.AddRange(new string[] { "Male", "Female","Other" });
                    cmbBody.Items.AddRange(new string[] {"Man","Large","Chibi","Muscle","Girl1","Girl2" });
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
                    player1.team = br.ReadInt32();
                    player1.team2 = br.ReadInt32();
                    player1.unk6 = br.ReadInt32();
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
                    player1.unk22 = br.ReadInt16();
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
                            bw.Write(player.team);
                            bw.Write(player.team2);
                            bw.Write(player.unk6);
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
                            bw.Write(player.unk22);
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
    }
}
