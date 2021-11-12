using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using Strikers2013Editor.IO;
using Strikers2013Editor.Logic;
using Strikers2013Editor.Common;

namespace Strikers2013Editor.Forms
{
    public partial class PlayerEditor : Form
    {
        private byte[] filedata;
        private PlayerInfo[] Players;
        public PlayerEditor()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Player file (0/104.bin) (*.bin)|*.bin|All files (*.*)|*.*";
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filedata = File.ReadAllBytes(ofd.FileName);

                    cmbPlayers.Enabled = true;
                    gbAdvanced.Enabled = true;
                    gbClubroom.Enabled = true;
                    gbInMatch.Enabled = true;
                    gbMain.Enabled = true;
                    gbMisc.Enabled = true;
                    btnApply.Enabled = true;
                    saveToolStripMenuItem.Enabled = true;

                    ParsePlayerFile(File.OpenRead(ofd.FileName));
                    cmbElement.Items.AddRange(Enum.GetNames(typeof(Element)));
                    cmbPosition.Items.AddRange(Enum.GetNames(typeof(Position)));
                    cmbTA.Items.AddRange(Enum.GetNames(typeof(TacticalAction)));
                    cmbSex.Items.AddRange(Enum.GetNames(typeof(Gender)));
                    cmbBodytype.Items.AddRange(Enum.GetNames(typeof(Bodytype)));
                    cmbCharge.Items.AddRange(Names.ChargeProfilesNames);

                    cmbPlayers.SelectedIndex = 1;
                }
            }
        }
        private void ParsePlayerFile(Stream input)
        {
            using (var br = new BeBinaryReader(input))
            {
                br.BaseStream.Position = 0xFA4;
                Players = new PlayerInfo[0x19C];
                for (var i = 0; i < 0x19C; i++)
                {
                    if (br.BaseStream.Position > br.BaseStream.Length - 0x148)
                        break;
                    var player = new PlayerInfo(br);

                    Players[i] = player;

                    cmbPlayers.Items.Add(player.Name);
                }
            }
        }

        private void cmbPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var player = Players[cmbPlayers.SelectedIndex];
            
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
            cmbCharge.SelectedIndex = player.ChargeProfile;

            var color1 = Color.FromArgb(player.SkinColor1.R, player.SkinColor1.G, player.SkinColor1.B);
            var color2 = Color.FromArgb(player.SkinColor2.R, player.SkinColor2.G, player.SkinColor2.B);
            picCol1.BackColor = color1;
            picCol2.BackColor = color2;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var player = Players[cmbPlayers.SelectedIndex];

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
            player.ChargeProfile = cmbCharge.SelectedIndex;

            var color1 = Color.FromArgb(0, picCol1.BackColor.R, picCol1.BackColor.G, picCol1.BackColor.B);
            var color2 = Color.FromArgb(0, picCol2.BackColor.R, picCol2.BackColor.G, picCol2.BackColor.B);

            player.SkinColor1 = color1;
            player.SkinColor2 = color2;

            Players[cmbPlayers.SelectedIndex] = player;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Player file(0 / 104.bin) (*.bin) | *.bin | All files(*.*) | *.* ";
                sfd.DefaultExt = ".bin";
                sfd.FileName = "players.bin";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var filename = sfd.FileName;
                    var file = File.Open(filename, FileMode.Create);
                    using (var bw = new BeBinaryWriter(file))
                    {
                        bw.Write(filedata);
                        bw.BaseStream.Position = 0xFA4;
                        foreach (var player in Players)
                        {
                            player.Write(bw);
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

        private Color GetColor(Color original)
        {
            var output = original;
            using (var cd = new ColorDialog())
            {
                cd.ShowHelp = true;
                cd.Color = original;
                cd.FullOpen = true;

                if (cd.ShowDialog() == DialogResult.OK)
                    output = cd.Color;
            }
            return output;
        }

        private void picCol1_Click(object sender, EventArgs e)
        {
            picCol1.BackColor = GetColor(picCol1.BackColor);
        }

        private void picCol2_Click(object sender, EventArgs e)
        {
            picCol2.BackColor = GetColor(picCol2.BackColor);
        }
    }
}
