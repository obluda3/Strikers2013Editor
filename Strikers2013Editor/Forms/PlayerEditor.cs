﻿using System;
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
                    player1.padding = br.ReadInt32();
                    player1.hiddenName = br.ReadInt32(); // 14.bin line minus 4
                    player1.shortName = br.ReadInt32(); // 14.bin line minus 4
                    player1.fullName = br.ReadInt32(); // 14.bin line minus 4
                    player1.name = Encoding.ASCII.GetString(br.ReadBytes(24));
                    player1.gender = (Gender)br.ReadInt32();
                    player1.idleAnimation = br.ReadInt32();
                    player1.unk1 = br.ReadInt32();
                    player1.description = br.ReadInt32(); // 14.bin line minus 2
                    player1.bodytype = (Bodytype)br.ReadInt32();
                    player1.height = br.ReadInt32();
                    player1.shadowSize = br.ReadInt32();
                    player1.tacticalAction = (TacticalAction)br.ReadInt32();
                    player1.courseAnimation = br.ReadInt32();
                    player1.team = br.ReadInt32();
                    player1.emblem = br.ReadInt32();
                    player1.teamPortrait = br.ReadInt32();
                    player1.position = br.ReadInt32();
                    player1.matchFaceModel = br.ReadInt32();
                    player1.facemodel = br.ReadInt32(); // I'm assuming both of them are the face models but i'm not sure
                    player1.facemodel2 = br.ReadInt32();
                    player1.unk9 = br.ReadInt32();
                    player1.unk10 = br.ReadInt32();
                    player1.unk11 = br.ReadInt32();
                    player1.portrait = br.ReadInt32();
                    player1.unk12 = br.ReadInt32();
                    player1.leftPortrait = br.ReadInt32();
                    player1.rightPortrait = br.ReadInt32();
                    br.BaseStream.Position += 12 * 8;
                    player1.skinColor1 = Color.FromArgb(br.ReadInt32());
                    player1.skinColor2 = Color.FromArgb(br.ReadInt32());
                    player1.unk15 = br.ReadInt32();
                    player1.element = (Element)br.ReadInt32();
                    player1.chargeTimeProfile = br.ReadInt32();
                    player1.unk17 = br.ReadInt32();
                    player1.unk18 = br.ReadInt32();
                    player1.voice = br.ReadInt32();
                    player1.armedAttribution = br.ReadInt32();
                    player1.unk21 = br.ReadInt32();
                    player1.price = br.ReadInt16();
                    player1.listPosition = br.ReadInt16();
                    player1.teamListPosition = br.ReadInt32();
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
            cmbTA.SelectedIndex = (int)player.tacticalAction - 0x14;
            cmbSex.SelectedIndex = (int)player.gender;
            cmbElement.SelectedIndex = (int)player.element;
            cmbBodytype.SelectedIndex = (int)player.bodytype;
            nudPrice.Value = player.price;    
            nudIdle.Value = player.idleAnimation;
            nudCourse.Value = player.courseAnimation;
            nudFace.Value = player.facemodel;
            nudFace2.Value = player.facemodel2;
            nudFace3.Value = player.matchFaceModel;
            nudDescription.Value = player.description;
            nudHeight.Value = player.height;
            nudShadow.Value = player.shadowSize;
            nudVoice.Value = player.voice;
            nudShortName1.Value = player.shortName;
            nudShortName2.Value = player.hiddenName;
            nudFullName.Value = player.fullName;
            nudPortrait.Value = player.portrait;
            nudLeftPortrait.Value = player.leftPortrait;
            nudRightPortrait.Value = player.rightPortrait;
            nudTeam.Value = player.team;
            nudEmblem.Value = player.emblem;
            nudListPosition.Value = player.listPosition;
            nudListPosition2.Value = player.teamListPosition;
            nudTeamlistPortrait.Value = player.teamPortrait;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var player = Players[listBox1.SelectedIndex];

            player.position = cmbPosition.SelectedIndex > 0 ? cmbPosition.SelectedIndex + 0x22 : 0;
            player.tacticalAction = (TacticalAction)cmbTA.SelectedIndex + 0x14;
            player.gender = (Gender)cmbSex.SelectedIndex;
            player.element = (Element)cmbElement.SelectedIndex;
            player.bodytype = (Bodytype)cmbBodytype.SelectedIndex;
            player.price = (short)nudPrice.Value;
            player.idleAnimation = (int)nudIdle.Value;
            player.courseAnimation = (int)nudCourse.Value;
            player.facemodel = (int)nudFace.Value;
            player.facemodel2 = (int)nudFace2.Value;
            player.matchFaceModel = (int)nudFace3.Value;
            player.height = (int)nudHeight.Value;
            player.shadowSize = (int)nudShadow.Value;
            player.voice = (int)nudVoice.Value;
            player.shortName = (int)nudShortName1.Value;
            player.hiddenName = (int)nudShortName2.Value;
            player.fullName = (int)nudFullName.Value;
            player.portrait = (int)nudPortrait.Value;
            player.leftPortrait = (int)nudLeftPortrait.Value;
            player.rightPortrait = (int)nudRightPortrait.Value;
            player.team = (int)nudTeam.Value;
            player.emblem = (int)nudEmblem.Value;
            player.listPosition = (short)nudListPosition.Value;
            player.description = (int)nudDescription.Value;
            player.teamListPosition = (int)nudListPosition2.Value;
            player.teamPortrait = (int)nudTeamlistPortrait.Value;

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
                            bw.Write(player.hiddenName); // 14.bin line minus 4
                            bw.Write(player.shortName); // 14.bin line minus 4
                            bw.Write(player.fullName); // 14.bin line minus 4
                            bw.Write(Encoding.ASCII.GetBytes(player.name));
                            bw.Write((int)player.gender);
                            bw.Write(player.idleAnimation);
                            bw.Write(player.unk1);
                            bw.Write(player.description); // 14.bin line minus 2
                            bw.Write((int)player.bodytype);
                            bw.Write(player.height);
                            bw.Write(player.shadowSize);
                            bw.Write((int)player.tacticalAction);
                            bw.Write(player.courseAnimation);
                            bw.Write(player.team);
                            bw.Write(player.emblem);
                            bw.Write(player.teamPortrait);
                            bw.Write(player.position);
                            bw.Write(player.matchFaceModel);
                            bw.Write(player.facemodel);
                            bw.Write(player.facemodel2);
                            bw.Write(player.unk9);
                            bw.Write(player.unk10);
                            bw.Write(player.unk11);
                            bw.Write(player.portrait);
                            bw.Write(player.unk12);
                            bw.Write(player.leftPortrait);
                            bw.Write(player.rightPortrait);
                            bw.BaseStream.Position += 12 * 8;
                            var color1 = Color.FromArgb(0, player.skinColor1.R, player.skinColor1.G, player.skinColor1.B);
                            var color2 = Color.FromArgb(0,player.skinColor2.R, player.skinColor2.G, player.skinColor2.B);
                            bw.Write(color1.ToArgb());
                            bw.Write(color2.ToArgb());
                            bw.Write(player.unk15);
                            bw.Write((int)player.element);
                            bw.Write(player.chargeTimeProfile);
                            bw.Write(player.unk17);
                            bw.Write(player.unk18);
                            bw.Write(player.voice);
                            bw.Write(player.armedAttribution);
                            bw.Write(player.unk21);
                            bw.Write(player.price);
                            bw.Write(player.listPosition);
                            bw.Write(player.teamListPosition);
                            bw.Write(player.unk25);
                            bw.Write(player.pad2);
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
