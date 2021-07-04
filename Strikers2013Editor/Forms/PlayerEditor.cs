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
        private void ParsePlayerFile(Stream input)
        {
            using (var br = new BeBinaryReader(input))
            {
                br.BaseStream.Position = 0xFA4;
                var playerList = new List<PlayerInfo>();
                for (var i = 0; i < 0x198; i++)
                {
                    if (br.BaseStream.Position > br.BaseStream.Length - 0x148)
                        break;
                    var player = new PlayerInfo(br);

                    playerList.Add(player);

                    listBox1.Items.Add(player.Name);
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
    }
}
