using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Strikers2013Editor.IO;
using Strikers2013Editor.Base;

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
                    using (var playernamesfile = assembly.GetManifestResourceStream("Strikers2013Editor.Database.playernames.txt"))
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
                sfd.FileName = "inazuma2.sav";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var filename = sfd.FileName;
                    var file = File.Open(filename, FileMode.Create);
                    save.ApplyEdits(file);
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

        private void toolTip1_Popup_1(object sender, PopupEventArgs e)
        {

        }

        private void nudCreationTime_ValueChanged(object sender, EventArgs e)
        {
            save.creationTime = (uint)nudCreationTime.Value;
        }

        private void nudCreationDate_ValueChanged(object sender, EventArgs e)
        {
            save.creationDate = (uint)nudCreationDate.Value;
        }

        private void dtpCreation_ValueChanged(object sender, EventArgs e)
        {

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

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

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


            player.waza[0] = Convert.ToInt16(txtLV1.Text, 16);
            player.waza[1] = Convert.ToInt16(txtLV2.Text, 16);
            player.waza[2] = Convert.ToInt16(txtLV3.Text, 16);
            player.waza[12] = Convert.ToInt16(txtCatch1.Text, 16);
            player.waza[13] = Convert.ToInt16(txtCatch2.Text, 16);
            player.waza[14] = Convert.ToInt16(txtCatch3.Text, 16);
            player.waza[4] = Convert.ToInt16(txtDribble.Text, 16);
            player.waza[8] = Convert.ToInt16(txtDefense.Text, 16);
            player.waza[16] = Convert.ToInt16(txtSP.Text, 16);

            save.players[lstPlayers.SelectedIndex] = player;

        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            var stats = save.players[lstPlayers.SelectedIndex].stats;
            for (var i = 0; i < 13; i += 2)
                stats[i] = stats[i + 1];
            save.players[lstPlayers.SelectedIndex].stats = stats;

            nudKick.Value = stats[2];
            nudBody.Value = stats[6];
            nudControl.Value = stats[10];
            nudGuard.Value = stats[8];
            nudCatch.Value = stats[4];
            nudSpeed.Value = stats[12];
            nudTP.Value = stats[0];
        }

        private void lstPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var player = save.players[lstPlayers.SelectedIndex];

            nudKick.Value = player.stats[2];
            nudBody.Value = player.stats[6];
            nudControl.Value = player.stats[10];
            nudGuard.Value = player.stats[8];
            nudCatch.Value = player.stats[4];
            nudSpeed.Value = player.stats[12];
            nudTP.Value = player.stats[0];

            txtLV1.Text = Convert.ToString(player.waza[0], 16);
            txtLV2.Text = Convert.ToString(player.waza[1], 16);
            txtLV3.Text = Convert.ToString(player.waza[2], 16);
            txtSP.Text = Convert.ToString(player.waza[16], 16);
            txtDefense.Text = Convert.ToString(player.waza[4], 16);
            txtDribble.Text = Convert.ToString(player.waza[8], 16);
            txtCatch1.Text = Convert.ToString(player.waza[12], 16);
            txtCatch2.Text = Convert.ToString(player.waza[13], 16);
            txtCatch3.Text = Convert.ToString(player.waza[14], 16);


        }
    }
}
