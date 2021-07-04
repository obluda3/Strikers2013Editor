using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using Strikers2013Editor.IO;
using Strikers2013Editor.Logic;

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

                    ParsePlayerFile(moveStream);
                    cmbElement.Items.AddRange(Enum.GetNames(typeof(Element)));
                    cmbPosition.Items.AddRange(Enum.GetNames(typeof(Position)));
                    cmbTA.Items.AddRange(Enum.GetNames(typeof(TacticalAction)));
                    cmbSex.Items.AddRange(Enum.GetNames(typeof(Gender)));
                    cmbBodytype.Items.AddRange(Enum.GetNames(typeof(Bodytype)));
                }
            }
        }
        private void ParsePlayerFile(Stream player)
        {
            using (var br = new BeBinaryReader(player))
            {
                br.BaseStream.Position = 0xFA4;
                var playerList = new List<PlayerInfo>();
                for (var i = 0; i < 0x198; i++)
                {
                    if (br.BaseStream.Position > br.BaseStream.Length - 0x148)
                        break;
                    var player1 = new PlayerInfo();
                    player1.ID = br.ReadInt32();
                    player1.Padding = br.ReadInt32();
                    player1.HiddenName = br.ReadInt32(); // 14.bin line minus 4
                    player1.ShortName = br.ReadInt32(); // 14.bin line minus 4
                    player1.FullName = br.ReadInt32(); // 14.bin line minus 4
                    player1.Name = Encoding.ASCII.GetString(br.ReadBytes(24));
                    player1.Gender = (Gender)br.ReadInt32();
                    player1.IdleAnimation = br.ReadInt32();
                    player1.Unk1 = br.ReadInt32();
                    player1.Description = br.ReadInt32(); // 14.bin line minus 2
                    player1.Bodytype = (Bodytype)br.ReadInt32();
                    player1.Scale = br.ReadInt32();
                    player1.ShadowSize = br.ReadInt32();
                    player1.TacticalAction = (TacticalAction)br.ReadInt32();
                    player1.CourseAnimation = br.ReadInt32();
                    player1.Team = br.ReadInt32();
                    player1.Emblem = br.ReadInt32();
                    player1.TeamPortrait = br.ReadInt32();
                    player1.Position = br.ReadInt32();
                    player1.MatchFaceModel = br.ReadInt32();
                    player1.Facemodel = br.ReadInt32(); // I'm assuming both of them are the face models but i'm not sure
                    player1.Facemodel2 = br.ReadInt32();
                    player1.Unk9 = br.ReadInt32();
                    player1.Unk10 = br.ReadInt32();
                    player1.Unk11 = br.ReadInt32();
                    player1.Portrait = br.ReadInt32();
                    player1.Unk12 = br.ReadInt32();
                    player1.LeftPortrait = br.ReadInt32();
                    player1.RightPortrait = br.ReadInt32();
                    br.BaseStream.Position += 12 * 8;
                    player1.SkinColor1 = Color.FromArgb(br.ReadInt32());
                    player1.SkinColor2 = Color.FromArgb(br.ReadInt32());
                    player1.Unk15 = br.ReadInt32();
                    player1.Element = (Element)br.ReadInt32();
                    player1.ChargeTimeProfile = br.ReadInt32();
                    player1.Unk17 = br.ReadInt32();
                    player1.Unk18 = br.ReadInt32();
                    player1.Voice = br.ReadInt32();
                    player1.ArmedAttribution = br.ReadInt32();
                    player1.Unk21 = br.ReadInt32();
                    player1.Price = br.ReadInt16();
                    player1.ListPosition = br.ReadInt16();
                    player1.TeamListPosition = br.ReadInt32();
                    player1.Unk25 = br.ReadInt32();
                    player1.Pad2 = br.ReadBytes(44);

                    playerList.Add(player1);

                    listBox1.Items.Add(player1.Name);
                }

                Players = playerList.ToArray();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var player = Players[listBox1.SelectedIndex];
            
            cmbPosition.SelectedIndex = player.Position > 0 ? player.Position - 0x22 : player.Position;
            cmbTA.SelectedIndex = (int)player.TacticalAction - 0x14;
            cmbSex.SelectedIndex = (int)player.Gender;
            cmbElement.SelectedIndex = (int)player.Element;
            cmbBodytype.SelectedIndex = (int)player.Bodytype;
            nudPrice.Value = player.Price;    
            nudIdle.Value = player.IdleAnimation;
            nudCourse.Value = player.CourseAnimation;
            nudFace.Value = player.Facemodel;
            nudFace2.Value = player.Facemodel2;
            nudFace3.Value = player.MatchFaceModel;
            nudDescription.Value = player.Description;
            nudHeight.Value = player.Scale;
            nudShadow.Value = player.ShadowSize;
            nudVoice.Value = player.Voice;
            nudShortName1.Value = player.ShortName;
            nudShortName2.Value = player.HiddenName;
            nudFullName.Value = player.FullName;
            nudPortrait.Value = player.Portrait;
            nudLeftPortrait.Value = player.LeftPortrait;
            nudRightPortrait.Value = player.RightPortrait;
            nudTeam.Value = player.Team;
            nudEmblem.Value = player.Emblem;
            nudListPosition.Value = player.ListPosition;
            nudListPosition2.Value = player.TeamListPosition;
            nudTeamlistPortrait.Value = player.TeamPortrait;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var player = Players[listBox1.SelectedIndex];

            player.Position = cmbPosition.SelectedIndex > 0 ? cmbPosition.SelectedIndex + 0x22 : 0;
            player.TacticalAction = (TacticalAction)cmbTA.SelectedIndex + 0x14;
            player.Gender = (Gender)cmbSex.SelectedIndex;
            player.Element = (Element)cmbElement.SelectedIndex;
            player.Bodytype = (Bodytype)cmbBodytype.SelectedIndex;
            player.Price = (short)nudPrice.Value;
            player.IdleAnimation = (int)nudIdle.Value;
            player.CourseAnimation = (int)nudCourse.Value;
            player.Facemodel = (int)nudFace.Value;
            player.Facemodel2 = (int)nudFace2.Value;
            player.MatchFaceModel = (int)nudFace3.Value;
            player.Scale = (int)nudHeight.Value;
            player.ShadowSize = (int)nudShadow.Value;
            player.Voice = (int)nudVoice.Value;
            player.ShortName = (int)nudShortName1.Value;
            player.HiddenName = (int)nudShortName2.Value;
            player.FullName = (int)nudFullName.Value;
            player.Portrait = (int)nudPortrait.Value;
            player.LeftPortrait = (int)nudLeftPortrait.Value;
            player.RightPortrait = (int)nudRightPortrait.Value;
            player.Team = (int)nudTeam.Value;
            player.Emblem = (int)nudEmblem.Value;
            player.ListPosition = (short)nudListPosition.Value;
            player.Description = (int)nudDescription.Value;
            player.TeamListPosition = (int)nudListPosition2.Value;
            player.TeamPortrait = (int)nudTeamlistPortrait.Value;

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
                            bw.Write(player.Padding);
                            bw.Write(player.HiddenName); // 14.bin line minus 4
                            bw.Write(player.ShortName); // 14.bin line minus 4
                            bw.Write(player.FullName); // 14.bin line minus 4
                            bw.Write(Encoding.ASCII.GetBytes(player.Name));
                            bw.Write((int)player.Gender);
                            bw.Write(player.IdleAnimation);
                            bw.Write(player.Unk1);
                            bw.Write(player.Description); // 14.bin line minus 2
                            bw.Write((int)player.Bodytype);
                            bw.Write(player.Scale);
                            bw.Write(player.ShadowSize);
                            bw.Write((int)player.TacticalAction);
                            bw.Write(player.CourseAnimation);
                            bw.Write(player.Team);
                            bw.Write(player.Emblem);
                            bw.Write(player.TeamPortrait);
                            bw.Write(player.Position);
                            bw.Write(player.MatchFaceModel);
                            bw.Write(player.Facemodel);
                            bw.Write(player.Facemodel2);
                            bw.Write(player.Unk9);
                            bw.Write(player.Unk10);
                            bw.Write(player.Unk11);
                            bw.Write(player.Portrait);
                            bw.Write(player.Unk12);
                            bw.Write(player.LeftPortrait);
                            bw.Write(player.RightPortrait);
                            bw.BaseStream.Position += 12 * 8;
                            var color1 = Color.FromArgb(0, player.SkinColor1.R, player.SkinColor1.G, player.SkinColor1.B);
                            var color2 = Color.FromArgb(0,player.SkinColor2.R, player.SkinColor2.G, player.SkinColor2.B);
                            bw.Write(color1.ToArgb());
                            bw.Write(color2.ToArgb());
                            bw.Write(player.Unk15);
                            bw.Write((int)player.Element);
                            bw.Write(player.ChargeTimeProfile);
                            bw.Write(player.Unk17);
                            bw.Write(player.Unk18);
                            bw.Write(player.Voice);
                            bw.Write(player.ArmedAttribution);
                            bw.Write(player.Unk21);
                            bw.Write(player.Price);
                            bw.Write(player.ListPosition);
                            bw.Write(player.TeamListPosition);
                            bw.Write(player.Unk25);
                            bw.Write(player.Pad2);
                        }
                    }

                    MessageBox.Show("Succesfully saved.", "Done");


                }
            }

        }

        

        private void nudPrice_Changed(object sender, EventArgs e)
        {

        }

        private void cmbElement_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
