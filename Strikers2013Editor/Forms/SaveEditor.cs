﻿using System;
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
        string[] moveNames, playerNames, emblemNames, formationNames;

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
                    moveNames = Names.GetTextFile("Strikers2013Editor.Common.wazaNames.txt");
                    formationNames = Names.GetTextFile("Strikers2013Editor.Common.formationNames.txt");

                    lstPlayers.Items.AddRange(playerNames);
                    cmbManager.Items.AddRange(playerNames);
                    cmbCurPlayer.Items.AddRange(playerNames);
                    cmbCoach.Items.AddRange(playerNames);
                    cmbFormation.Items.AddRange(formationNames);
                    cmbTeamKit.Items.AddRange(emblemNames);
                    cmbPlayerKit.Items.AddRange(emblemNames);
                    cmbEmblem.Items.AddRange(emblemNames);

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
                    // In an older version, emblems and formations were mistaken for eachother
                    // this should fix some saves
                    cmbFormation.SelectedIndex = save.Team.Formation >= cmbFormation.Items.Count ? 0 : save.Team.Formation;
                    cmbTeamKit.SelectedIndex = save.Team.Kit;
                    cmbCoach.SelectedIndex = save.Team.Coach;
                    cmbManager.SelectedIndex = save.Team.Manager;
                    cmbEmblem.SelectedIndex = save.Team.Emblem;

                    cmbLv1.Items.AddRange(moveNames);
                    cmbLv2.Items.AddRange(moveNames);
                    cmbLv3.Items.AddRange(moveNames);
                    cmbSP.Items.AddRange(moveNames);
                    cmbCatch1.Items.AddRange(moveNames);
                    cmbCatch2.Items.AddRange(moveNames);
                    cmbCatch3.Items.AddRange(moveNames);
                    cmbDribble.Items.AddRange(moveNames);
                    cmbDefense.Items.AddRange(moveNames);

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
                sfd.Filter = "Save file (*.sav)|*.sav|All files (*.*)|*.*";

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
            if (lstTeam.SelectedIndex != -1)
            {
                var player = save.Team.Players[lstTeam.SelectedIndex];
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

            player.Stats.Flag |= chkMixi1.Checked ? 0x10 : 0;
            player.Stats.Flag |= chkMixi2.Checked ? 0x20 : 0;

            player.MoveList.Lv1 = (short)cmbLv1.SelectedIndex;
            player.MoveList.Lv2 = (short)cmbLv2.SelectedIndex;
            player.MoveList.Lv3 = (short)cmbLv3.SelectedIndex;
            player.MoveList.Catch1 = (short)cmbCatch1.SelectedIndex;
            player.MoveList.Catch2 = (short)cmbCatch2.SelectedIndex;
            player.MoveList.Catch3 = (short)cmbCatch3.SelectedIndex;
            player.MoveList.Dribble = (short)cmbDribble.SelectedIndex;
            player.MoveList.Defense = (short)cmbDefense.SelectedIndex;
            player.MoveList.SP = (short)cmbSP.SelectedIndex;

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

        private void cmbFormation_SelectedIndexChanged(object sender, EventArgs e)
        {
            save.Team.Formation = cmbFormation.SelectedIndex;
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

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkMixi2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cmbCatch2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCatch3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbEmblem_SelectedIndexChanged(object sender, EventArgs e)
        {
            save.Team.Emblem = (short)cmbEmblem.SelectedIndex;
        }

        private void cmbManager_SeletedIndexChanged(object sender, EventArgs e)
        {
            save.Team.Manager = cmbManager.SelectedIndex;
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
            chkMixi1.Checked = (player.Stats.Flag & 0x10) == 0x10;
            chkMixi2.Checked = (player.Stats.Flag & 0x20) == 0x20;

            cmbLv1.SelectedIndex = player.MoveList.Lv1;
            cmbLv2.SelectedIndex = player.MoveList.Lv2;
            cmbLv3.SelectedIndex = player.MoveList.Lv3;
            cmbCatch1.SelectedIndex = player.MoveList.Catch1;
            cmbCatch2.SelectedIndex = player.MoveList.Catch2;
            cmbCatch3.SelectedIndex = player.MoveList.Catch3;
            cmbDribble.SelectedIndex = player.MoveList.Dribble;
            cmbDefense.SelectedIndex = player.MoveList.Defense;
            cmbSP.SelectedIndex = player.MoveList.SP;


        }
    }
}
