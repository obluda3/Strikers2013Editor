using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Strikers2013Editor.IO;
using Strikers2013Editor.Logic;

namespace Strikers2013Editor.Forms
{
    public partial class SaveEditor : Form
    {
        Encoding sjis = Encoding.GetEncoding("sjis");
        Save save;
        string[] wazaNames, playerNames;

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

                    save.baseOffset = (uint)(0x2598 + slot * 0x68548);

                    cmbTeam.Items.Clear();
                    lstPlayers.Items.Clear();
                    lstTeam.Items.Clear();

                    save.ParseSaveFile();

                    var assembly = Assembly.GetExecutingAssembly();
                    using (var playernamesfile = assembly.GetManifestResourceStream("Strikers2013Editor.Common.playernames.txt"))
                    {
                        using (StreamReader sr = new StreamReader(playernamesfile))
                        {
                            var playerNamesList = new List<string>();
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                playerNamesList.Add(line);
                            }

                            playerNames = playerNamesList.ToArray();
                        }
                    }
                    lstPlayers.Items.AddRange(playerNames);
                    cmbTeam.Items.AddRange(playerNames);

                    foreach (var player in save.team)
                    {
                        lstTeam.Items.Add(playerNames[player]);
                    }
                    txtProfileName.Text = save.profileName;
                    txtOnlineName.Text = save.onlineName;
                    nudProfile.Value = save.profile;
                    nudProfileOnline.Value = save.onlineProfile;
                    nudInazumaPoints.Value = save.inazumaPoints;
                    nudHours.Value = save.hoursPlayed;
                    nudMinutes.Value = save.minutesPlayed / 0x1c200;
                    nudCreationTime.Value = save.creationTime;
                    nudCreationDate.Value = save.creationDate;


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
            save.onlineName = txtOnlineName.Text;
        }

        private void nudProfile_ValueChanged(object sender, EventArgs e)
        {
            save.profile = (uint)nudProfile.Value;
        }

        private void nudProfileOnline_ValueChanged(object sender, EventArgs e)
        {
            save.onlineProfile = (uint)nudProfileOnline.Value;
        }

        private void nudCreationTime_ValueChanged(object sender, EventArgs e)
        {
            save.creationTime = (uint)nudCreationTime.Value;
        }

        private void nudCreationDate_ValueChanged(object sender, EventArgs e)
        {
            save.creationDate = (uint)nudCreationDate.Value;
        }

        private void nudMinutes_ValueChanged(object sender, EventArgs e)
        {
            save.minutesPlayed = (uint)nudMinutes.Value * 0x1c200;
        }

        private void nudHours_ValueChanged(object sender, EventArgs e)
        {
            save.hoursPlayed = (uint)nudHours.Value;
        }

        private void txtProfileName_TextChanged(object sender, EventArgs e)
        {
            save.profileName = txtProfileName.Text;
        }
        private void lstTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTeam.SelectedIndex != -1)
                cmbTeam.SelectedIndex = save.team[lstTeam.SelectedIndex];
        }

        private void cmbTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            save.team[lstTeam.SelectedIndex] = (short)cmbTeam.SelectedIndex;
            lstTeam.Items[lstTeam.SelectedIndex] = playerNames[cmbTeam.SelectedIndex];
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var player = save.players[lstPlayers.SelectedIndex];


            player.MoveList.Lv1 = Convert.ToInt16(txtLV1.Text, 16);
            player.MoveList.Lv2 = Convert.ToInt16(txtLV2.Text, 16);
            player.MoveList.Lv3 = Convert.ToInt16(txtLV3.Text, 16);
            player.MoveList.Catch1 = Convert.ToInt16(txtCatch1.Text, 16);
            player.MoveList.Catch2 = Convert.ToInt16(txtCatch2.Text, 16);
            player.MoveList.Catch3 = Convert.ToInt16(txtCatch3.Text, 16);
            player.MoveList.Dribble = Convert.ToInt16(txtDribble.Text, 16);
            player.MoveList.Defense = Convert.ToInt16(txtDefense.Text, 16);
            player.MoveList.SP = Convert.ToInt16(txtSP.Text, 16);

            save.players[lstPlayers.SelectedIndex] = player;
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            var player = save.players[lstPlayers.SelectedIndex];
            var stats = player.Stats;

            stats.Kick = stats.MaxKick;
            stats.TP = stats.MaxTP;
            stats.Body = stats.MaxBody;
            stats.Control = stats.MaxControl;
            stats.Guard = stats.MaxGuard;
            stats.Speed = stats.MaxSpeed;
            stats.Catch = stats.MaxCatch;

            player.Stats = stats;

            save.players[lstPlayers.SelectedIndex] = player;

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

        private void lstPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var player = save.players[lstPlayers.SelectedIndex];

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
