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
        private Save save;
        private string[] moveNames, playerNames, emblemNames, formationNames;

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

                    save = new Save(ofd.FileName, slot);

                    cmbCurPlayer.Items.Clear();
                    lstPlayers.Items.Clear();
                    lstTeam.Items.Clear();

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

                    
                    txtProfileName.Text = save.ProfileName;
                    txtOnlineName.Text = save.OnlineName;
                    nudProfile.Value = save.Profile;
                    nudProfileOnline.Value = save.OnlineProfile;
                    nudInazumaPoints.Value = save.InazumaPoints;
                    nudHours.Value = save.HoursPlayed;
                    nudMinutes.Value = save.MinutesPlayed / 0x1c200;
                    nudCreationTime.Value = save.CreationTime;
                    nudCreationDate.Value = save.CreationDate;

                    InitTeam();

                    cmbLv1.Items.AddRange(moveNames);
                    cmbLv2.Items.AddRange(moveNames);
                    cmbLv3.Items.AddRange(moveNames);
                    cmbSP.Items.AddRange(moveNames);
                    cmbCatch1.Items.AddRange(moveNames);
                    cmbCatch2.Items.AddRange(moveNames);
                    cmbCatch3.Items.AddRange(moveNames);
                    cmbDribble.Items.AddRange(moveNames);
                    cmbDefense.Items.AddRange(moveNames);
                    cmbUnkMove1.Items.AddRange(moveNames);
                    cmbUnkMove2.Items.AddRange(moveNames);
                    cmbUnkMove3.Items.AddRange(moveNames);
                    cmbUnkMove4.Items.AddRange(moveNames);
                    cmbUnkMove5.Items.AddRange(moveNames);
                    cmbKakusei2.Items.AddRange(moveNames);
                    cmbKakusei3.Items.AddRange(moveNames);

                    tabControl1.Enabled = true;
                    saveToolStripMenuItem.Enabled = true;
                    nudProfile.Enabled = true;
                    var fixedPlayers = "";
                    for (int i = 0; i < save.Players.Length; i++)
                    {
                        var cur = save.Players[i];
                        var stats = cur.Stats;
                        // This kind of thing needs to be logged
                        if (stats.MaxKick < stats.Kick)
                        {
                            fixedPlayers += $"{playerNames[i]} - Kick {stats.Kick} -> {stats.MaxKick}\n";
                            stats.Kick = stats.MaxKick;
                        }
                        if (stats.MaxBody < stats.Body)
                        {
                            fixedPlayers += $"{playerNames[i]} - Body {stats.Body} -> {stats.MaxBody}\n";
                            stats.Body = stats.MaxBody;
                        }
                        if (stats.MaxGuard < stats.Guard)
                        {
                            fixedPlayers += $"{playerNames[i]} - Guard {stats.Guard} -> {stats.MaxGuard}\n";
                            stats.Guard = stats.MaxGuard;
                        }
                        if (stats.MaxControl < stats.Control)
                        {
                            fixedPlayers += $"{playerNames[i]} - Control {stats.Control} -> {stats.MaxControl}\n";
                            stats.Control = stats.MaxControl;
                        }
                        if (stats.MaxSpeed < stats.Speed)
                        {
                            fixedPlayers += $"{playerNames[i]} - Speed {stats.Speed} -> {stats.MaxSpeed}\n";
                            stats.Speed = stats.MaxSpeed;
                        }
                        if (stats.MaxCatch < stats.Catch)
                        {
                            fixedPlayers += $"{playerNames[i]} - Catch {stats.Catch} -> {stats.MaxCatch}\n";
                            stats.Catch = stats.MaxCatch;
                        }
                        cur.Stats = stats;
                        save.Players[i] = cur;
                    }
                    if (fixedPlayers != "")
                    {
                        Console.WriteLine(fixedPlayers, "Supplement bug");
                    }
                }
            }
        }

        private void InitTeam()
        {
            lstTeam.Items.Clear();
            foreach (var player in save.Team.Players)
            {
                lstTeam.Items.Add(playerNames[player.Id]);
            }
            txtTeamInfo.Text = save.Team.Name;
            // In an older version, emblems and formations were mistaken for eachother
            // this should fix some saves
            cmbFormation.SelectedIndex = save.Team.Formation >= cmbFormation.Items.Count ? 0 : save.Team.Formation;
            cmbTeamKit.SelectedIndex = save.Team.Kit;
            cmbCoach.SelectedIndex = save.Team.Coach;
            cmbManager.SelectedIndex = save.Team.Manager;
            cmbEmblem.SelectedIndex = save.Team.Emblem;
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

            var flag = player.Stats.Flag;
            // Reset bits
            flag &= ~0x10;
            flag &= ~0x20;
            flag |= chkMixi1.Checked ? 0x10 : 0;
            flag |= chkMixi2.Checked ? 0x20 : 0;
            player.Stats.Flag = flag;

            player.MoveList.Lv1 = (short)cmbLv1.SelectedIndex;
            player.MoveList.Lv2 = (short)cmbLv2.SelectedIndex;
            player.MoveList.Lv3 = (short)cmbLv3.SelectedIndex;
            player.MoveList.Catch1 = (short)cmbCatch1.SelectedIndex;
            player.MoveList.Catch2 = (short)cmbCatch2.SelectedIndex;
            player.MoveList.Catch3 = (short)cmbCatch3.SelectedIndex;
            player.MoveList.Dribble = (short)cmbDribble.SelectedIndex;
            player.MoveList.Defense = (short)cmbDefense.SelectedIndex;
            player.MoveList.SP = (short)cmbSP.SelectedIndex;
            player.Stats.MoveUnk = (short)cmbUnkMove1.SelectedIndex;
            player.Stats.MoveKakusei2_2 = (short)cmbUnkMove2.SelectedIndex;
            player.Stats.MoveKakusei2_3 = (short)cmbUnkMove3.SelectedIndex;
            player.Stats.MoveKakusei3_2 = (short)cmbUnkMove3.SelectedIndex;
            player.Stats.MoveKakusei3_3 = (short)cmbUnkMove3.SelectedIndex;
            player.Stats.MoveKakusei2 = (short)cmbKakusei2.SelectedIndex;
            player.Stats.MoveKakusei3 = (short)cmbKakusei3.SelectedIndex;

            player.Stats.Kick = (byte)nudKick.Value;
            player.Stats.MaxKick = (byte)nudKickMax.Value;
            player.Stats.Body = (byte)nudBody.Value;
            player.Stats.MaxBody = (byte)nudBodyMax.Value;
            player.Stats.Control = (byte)nudControl.Value;
            player.Stats.MaxControl = (byte)nudControlMax.Value;
            player.Stats.Guard = (byte)nudGuard.Value;
            player.Stats.MaxGuard = (byte)nudGuardMax.Value;
            player.Stats.Speed = (byte)nudSpeed.Value;
            player.Stats.MaxSpeed = (byte)nudSpeedMax.Value;
            player.Stats.Catch = (byte)nudCatch.Value;
            player.Stats.MaxCatch = (byte)nudCatchMax.Value;
            player.Stats.TP = (byte)nudTP.Value;
            player.Stats.MaxTP = (byte)nudTPMax.Value;

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

        private void btnTeamSave_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "STrikers teaM file (*.stm)|*.stm|All files (*.*)|*.*";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var file = File.OpenWrite(sfd.FileName);
                    using (var bw = new BeBinaryWriter(file))
                    {
                        bw.Write(0x5445414D);
                        TeamSave.Save(bw, save);
                        MessageBox.Show("Succesfully saved.", "Done");
                    }
                }
            }
        }

        private void btnTeamLoad_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "STrikers teaM file (*.stm)|*.stm|All files (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var file = File.OpenRead(ofd.FileName);
                    using (var br = new BeBinaryReader(file))
                    {
                        if (br.ReadInt32() != 0x5445414D)
                        {
                            MessageBox.Show("Invalid file", "Error");
                            return;
                        }
                        TeamSave.Load(br, save);
                        InitTeam();
                    }               
                }
            }
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
            nudKickMax.Value = player.Stats.MaxKick;
            nudBodyMax.Value = player.Stats.MaxBody;
            nudControlMax.Value = player.Stats.MaxControl;
            nudGuardMax.Value = player.Stats.MaxGuard;
            nudSpeedMax.Value = player.Stats.MaxSpeed;
            nudCatchMax.Value = player.Stats.MaxCatch;
            nudTPMax.Value = player.Stats.MaxTP;

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
            cmbUnkMove1.SelectedIndex = player.Stats.MoveUnk;
            cmbUnkMove2.SelectedIndex = player.Stats.MoveKakusei2_2;
            cmbUnkMove3.SelectedIndex = player.Stats.MoveKakusei2_3;
            cmbUnkMove4.SelectedIndex = player.Stats.MoveKakusei3_2;
            cmbUnkMove5.SelectedIndex = player.Stats.MoveKakusei3_3;
            cmbKakusei2.SelectedIndex = player.Stats.MoveKakusei2;
            cmbKakusei3.SelectedIndex = player.Stats.MoveKakusei3;

        }
    }
}
