using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Strikers2013Editor.IO;
using Strikers2013Editor.Logic;
using Strikers2013Editor.Common;

namespace Strikers2013Editor.Forms
{
    public partial class SaveEditor : Form
    {
        Encoding sjis = Encoding.GetEncoding("sjis");
        Save save;
        string[] wazaNames, playerNames, emblemNames;

        public SaveEditor()
        {
            InitializeComponent();
        }

        private void SaveEditor_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(nudCreationDate, "Format used is YYMMDD");
            toolTip2.SetToolTip(nudCreationTime, "Format used is HHMM");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Save file (*.sav)|*.sav|All files (*.*)|*.*";
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var slotDialog = new Slot();
                    var slot = 0;
                    if(slotDialog.ShowDialog() == DialogResult.OK)
                    {
                        slot = slotDialog.SlotIndex; 
                    }

                    save = new Save(ofd.FileName);

                    save.BaseOffset = (uint)(0x2598 + slot * 0x68548);

                    cmbCurPlayer.Items.Clear();
                    lstPlayers.Items.Clear();
                    lstTeam.Items.Clear();

                    save.ParseSaveFile();

                    playerNames = Names.GetTextFile("Strikers2013Editor.Common.playerNames.txt");
                    emblemNames = Names.GetTextFile("Strikers2013Editor.Common.emblemNames.txt");

                    lstPlayers.Items.AddRange(playerNames);
                    cmbCurPlayer.Items.AddRange(playerNames);
                    cmbTeamEmblem.Items.AddRange(emblemNames);
                    cmbTeamKit.Items.AddRange(emblemNames);
                    cmbPlayerKit.Items.AddRange(emblemNames);
                    cmbCoach.Items.AddRange(playerNames);

                    foreach (var player in save.Team.Players)
                    {
                        lstTeam.Items.Add(playerNames[player.Id]);
                    }
                    txtProfileName.Text = save.ProfileName;
                    txtOnlineName.Text = save.OnlineName;
                    nudProfile.Value = save.Profile;
                    nudProfileOnline.Value = save.OnlineProfile;
                    nudInazumaPoints.Value = save.InazumaPoints;
                    nudHours.Value = save.HoursPlayed;
                    nudMinutes.Value = save.MinutesPlayed / 0x1c200;
                    nudCreationTime.Value = save.CreationTime;
                    nudCreationDate.Value = save.CreationDate;

                    txtTeamInfo.Text = save.Team.Name;
                    cmbTeamEmblem.SelectedIndex = save.Team.Emblem;
                    cmbTeamKit.SelectedIndex = save.Team.Kit;
                    cmbCoach.SelectedIndex = save.Team.Coach;
                    


                    tabControl1.Enabled = true;
                    saveToolStripMenuItem.Enabled = true;
                    nudProfile.Enabled = true;
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Save file(inazuma2.sav) (*.sav) | *.sav | All files(*.*) | *.* ";
                sfd.DefaultExt = ".sav";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    save.ApplyEdits(sfd.FileName);
                    MessageBox.Show("Succesfully saved.", "Done");
                }
            }
        }

        private void txtOnlineName_TextChanged(object sender, EventArgs e)
        {
            save.OnlineName = txtOnlineName.Text;
        }

        private void nudProfile_ValueChanged(object sender, EventArgs e)
        {
            save.Profile = (uint)nudProfile.Value;
        }

        private void nudProfileOnline_ValueChanged(object sender, EventArgs e)
        {
            save.OnlineProfile = (uint)nudProfileOnline.Value;
        }

        private void nudCreationTime_ValueChanged(object sender, EventArgs e)
        {
            save.CreationTime = (uint)nudCreationTime.Value;
        }

        private void nudCreationDate_ValueChanged(object sender, EventArgs e)
        {
            save.CreationDate = (uint)nudCreationDate.Value;
        }

        private void nudMinutes_ValueChanged(object sender, EventArgs e)
        {
            save.MinutesPlayed = (uint)nudMinutes.Value * 0x1c200;
        }

        private void nudHours_ValueChanged(object sender, EventArgs e)
        {
            save.HoursPlayed = (uint)nudHours.Value;
        }

        private void txtProfileName_TextChanged(object sender, EventArgs e)
        {
            save.ProfileName = txtProfileName.Text;
        }
        private void lstTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            var player = save.Team.Players[lstTeam.SelectedIndex];
            if (lstTeam.SelectedIndex != -1)
            {
                cmbCurPlayer.SelectedIndex = player.Id;
                cmbPlayerKit.SelectedIndex = player.ClubroomKit;
                nudSquadNumber.Value = player.KitNumber;
                chkKey.Checked = (player.Flag & 0x2000) == 0x2000;
            }
        }

        private void cmbTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            save.Team.Players[lstTeam.SelectedIndex].Id = cmbCurPlayer.SelectedIndex;
            lstTeam.Items[lstTeam.SelectedIndex] = playerNames[cmbCurPlayer.SelectedIndex];

        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var player = save.Players[lstPlayers.SelectedIndex];


            player.MoveList.Lv1 = Convert.ToInt16(txtLV1.Text, 16);
            player.MoveList.Lv2 = Convert.ToInt16(txtLV2.Text, 16);
            player.MoveList.Lv3 = Convert.ToInt16(txtLV3.Text, 16);
            player.MoveList.Catch1 = Convert.ToInt16(txtCatch1.Text, 16);
            player.MoveList.Catch2 = Convert.ToInt16(txtCatch2.Text, 16);
            player.MoveList.Catch3 = Convert.ToInt16(txtCatch3.Text, 16);
            player.MoveList.Dribble = Convert.ToInt16(txtDribble.Text, 16);
            player.MoveList.Defense = Convert.ToInt16(txtDefense.Text, 16);
            player.MoveList.SP = Convert.ToInt16(txtSP.Text, 16);

            save.Players[lstPlayers.SelectedIndex] = player;
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            var player = save.Players[lstPlayers.SelectedIndex];
            var stats = player.Stats;

            stats.Kick = stats.MaxKick;
            stats.TP = stats.MaxTP;
            stats.Body = stats.MaxBody;
            stats.Control = stats.MaxControl;
            stats.Guard = stats.MaxGuard;
            stats.Speed = stats.MaxSpeed;
            stats.Catch = stats.MaxCatch;

            player.Stats = stats;

            save.Players[lstPlayers.SelectedIndex] = player;

            nudKick.Value = player.Stats.Kick;
            nudBody.Value = player.Stats.Body;
            nudControl.Value = player.Stats.Control;
            nudGuard.Value = player.Stats.Guard;
            nudCatch.Value = player.Stats.Catch;
            nudSpeed.Value = player.Stats.Speed;
            nudTP.Value = player.Stats.TP;
        }

        private void nudTP_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nudKick_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void txtTeamInfo_TextChanged(object sender, EventArgs e)
        {
            save.Team.Name = txtTeamInfo.Text;
        }

        private void cmbTeamKit_SelectedIndexChanged(object sender, EventArgs e)
        {
            save.Team.Kit = cmbTeamKit.SelectedIndex;
        }

        private void cmbTeamEmblem_SelectedIndexChanged(object sender, EventArgs e)
        {
            save.Team.Emblem = cmbTeamEmblem.SelectedIndex;
        }

        private void cmbCoach_SelectedIndexChanged(object sender, EventArgs e)
        {
            save.Team.Coach = cmbCoach.SelectedIndex;
        }

        private void nudSquadNumber_ValueChanged(object sender, EventArgs e)
        {
            save.Team.Players[lstTeam.SelectedIndex].KitNumber = (int)nudSquadNumber.Value;
        }

        private void chkKey_CheckedChanged(object sender, EventArgs e)
        {
            save.Team.Players[lstTeam.SelectedIndex].Flag ^= 0x2000; 
        }

        private void cmbPlayerKit_SelectedIndexChanged(object sender, EventArgs e)
        {
            save.Team.Players[lstTeam.SelectedIndex].ClubroomKit = cmbPlayerKit.SelectedIndex;
        }

        private void lstPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var player = save.Players[lstPlayers.SelectedIndex];

            nudKick.Value = player.Stats.Kick;
            nudBody.Value = player.Stats.Body;
            nudControl.Value = player.Stats.Control;
            nudGuard.Value = player.Stats.Guard;
            nudCatch.Value = player.Stats.Catch;
            nudSpeed.Value = player.Stats.Speed;
            nudTP.Value = player.Stats.TP;

            txtLV1.Text = Convert.ToString(player.MoveList.Lv1, 16);
            txtLV2.Text = Convert.ToString(player.MoveList.Lv2, 16);
            txtLV3.Text = Convert.ToString(player.MoveList.Lv3, 16);
            txtSP.Text = Convert.ToString(player.MoveList.SP, 16);
            txtDefense.Text = Convert.ToString(player.MoveList.Defense, 16);
            txtDribble.Text = Convert.ToString(player.MoveList.Dribble, 16);
            txtCatch1.Text = Convert.ToString(player.MoveList.Catch1, 16);
            txtCatch2.Text = Convert.ToString(player.MoveList.Catch2, 16);
            txtCatch3.Text = Convert.ToString(player.MoveList.Catch3, 16);


        }
    }
}
