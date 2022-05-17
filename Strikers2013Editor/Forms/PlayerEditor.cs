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
        private byte[] DataBackup;
        private List<PlayerDef> Players;
        private string[] PlayerNames;
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
                    cmbPlayers.Enabled = true;
                    gbAdvanced.Enabled = true;
                    gbClubroom.Enabled = true;
                    gbInMatch.Enabled = true;
                    gbMain.Enabled = true;
                    gbMisc.Enabled = true;
                    btnApply.Enabled = true;
                    gbEquip.Enabled = true;
                    saveToolStripMenuItem.Enabled = true;

                    cmbElement.Items.Clear();
                    cmbPosition.Items.Clear();
                    cmbTA.Items.Clear();
                    cmbSex.Items.Clear();
                    cmbBodytype.Items.Clear();
                    cmbCharge.Items.Clear();
                    cmbPlayers.Items.Clear();

                    ParsePlayerFile(File.OpenRead(ofd.FileName));
                    cmbElement.Items.AddRange(Enum.GetNames(typeof(Element)));
                    cmbPosition.Items.AddRange(Enum.GetNames(typeof(Position)));
                    cmbTA.Items.AddRange(Enum.GetNames(typeof(TacticalAction)));
                    cmbSex.Items.AddRange(Enum.GetNames(typeof(Gender)));
                    cmbBodytype.Items.AddRange(Enum.GetNames(typeof(Bodytype)));
                    cmbCharge.Items.AddRange(Names.ChargeProfilesNames);
                    cmbPlayers.SelectedIndex = 0;
                }
            }
        }
        private void ParsePlayerFile(Stream input)
        {
            PlayerNames = Names.GetTextFile("Strikers2013Editor.Common.playerNames.txt");
            using (var br = new BeBinaryReader(input))
            {
                DataBackup = br.ReadBytes(0xFA4);
                br.BaseStream.Position = 0x10;
                var count = br.ReadInt32();
                br.BaseStream.Position = 0xFA4;
                Players = new List<PlayerDef>();
                for (var i = 1; i < count; i++)
                {
                    if (br.BaseStream.Position > br.BaseStream.Length - 0x148)
                        break;
                    var player = new PlayerDef(br);

                    Players.Add(player);
                    if (i < PlayerNames.Length)
                        cmbPlayers.Items.Add(PlayerNames[i]);
                    else
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
            txtPlyName.Text = player.Name;
            txtSpClothes1.Text = player.Equip[0];
            txtSpClothes2.Text = player.Equip[1];

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
            player.Name = txtPlyName.Text;
            player.Equip[0] = txtSpClothes1.Text;
            player.Equip[1] = txtSpClothes2.Text;
            if (player.ID >= PlayerNames.Length)
                cmbPlayers.Items[cmbPlayers.SelectedIndex] = txtPlyName.Text;
        
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
                        bw.Write(DataBackup);
                        bw.BaseStream.Position = 0x10;
                        bw.Write(Players.Count + 1);
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

        private void button1_Click(object sender, EventArgs e)
        {
            PlayerDef player = Players[0];
            cmbPlayers.Items.Add(player.Name);
            Players.Add(player);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Players.RemoveAt(Players.Count - 1);
            cmbPlayers.Items.RemoveAt(Players.Count);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
