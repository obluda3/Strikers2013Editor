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

        byte[] saveFile;
        short[] team = new short[16];
        Player[] players = new Player[412];
        

        string profileName, onlineName;
        string[] playerNames, wazaNames;
        uint profile, onlineProfile, baseOffset, minutesPlayed, hoursPlayed, inazumaPoints,creationDate,creationTime;
        


        const int STATS_OFFSET = 0xad74;
        const int WAZA_OFFSET = 0x640a4;
        const int TEAM_OFFSET = 0x63f66;
        const int PROFILE_OFFSET = 0x6775a;
        const int ONLINE_PROFILE = 0x1d8;
        const int PROFILENAME_OFFSET = 0x1f8;



        public SaveEditor()
        {
            InitializeComponent();
        }

        private void SaveEditor_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(nudCreationDate, "Format used is YYMMDD");
            toolTip2.SetToolTip(nudCreationTime, "Format used is HHMM");
        }
        private void ParseSaveFile(Stream saveStream) 
        {
            // Get the names of the players
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
            using (var movenamesfile = assembly.GetManifestResourceStream("Strikers2013Editor.Database.wazaNames.txt"))
            {
                using (StreamReader sr = new StreamReader(movenamesfile))
                {
                    var moveNamesList = new List<string>();
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        moveNamesList.Add(line);
                    }

                    wazaNames = moveNamesList.ToArray();
                }
            }

            using (var br = new BeBinaryReader(saveStream))
            {
                br.BaseStream.Position = ONLINE_PROFILE;
                onlineName = sjis.GetString(br.ReadBytes(16));
                onlineProfile = br.ReadUInt32();

                br.BaseStream.Position = baseOffset; // Hours stuff
                
                creationDate = br.ReadUInt32();
                creationTime = br.ReadUInt32();
                hoursPlayed = br.ReadUInt32();
                minutesPlayed = br.ReadUInt32();



                br.BaseStream.Position = baseOffset + 0x1d4;
                inazumaPoints = br.ReadUInt32();
               
                br.BaseStream.Position = baseOffset + PROFILENAME_OFFSET;
                profileName = sjis.GetString(br.ReadBytes(16));
                


                for(var i = 0; i < 412; i++)
                {
                    // STATS
                    var player = new Player();
                    br.BaseStream.Position = baseOffset + STATS_OFFSET + i * 0x3c;
                    player.tp = br.ReadByte();
                    br.ReadByte();
                    player.kick = br.ReadByte();
                    br.ReadByte();
                    player._catch = br.ReadByte();
                    br.ReadByte();
                    player.body = br.ReadByte();
                    br.ReadByte();
                    player.guard = br.ReadByte();
                    br.ReadByte();
                    player.control = br.ReadByte();
                    br.ReadByte();
                    player.speed = br.ReadByte();

                    // WAZA
                    br.BaseStream.Position = baseOffset + WAZA_OFFSET + i * 0x22;
                    player.lv1 = br.ReadInt16();
                    player.lv2 = br.ReadInt16();
                    player.lv3 = br.ReadInt16();
                    br.ReadInt16();
                    player.defense = br.ReadInt16();
                    br.BaseStream.Position += 6;
                    player.lv1gk = br.ReadInt16();
                    br.BaseStream.Position += 6;
                    player.lv2gk = br.ReadInt16();
                    player.lv3gk = br.ReadInt16();
                    player.sp = br.ReadInt16();
                    br.ReadInt16();
                    player.dribble = br.ReadInt16();

                    players[i] = player;
                    lstPlayers.Items.Add(playerNames[i]);
                }
                for(var i = 0; i < 16; i++)
                {
                    br.BaseStream.Position = baseOffset + TEAM_OFFSET + 0x14 * i;
                    team[i] = br.ReadInt16();
                    lstTeam.Items.Add(playerNames[team[i]]);
                }
                br.BaseStream.Position = baseOffset + PROFILE_OFFSET;
                profile = br.ReadUInt32();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Save file (*.sav)|*.sav|All files (*.*)|*.*";
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    saveFile = File.ReadAllBytes(ofd.FileName);
                    var saveStream = new MemoryStream(saveFile);

                    var slotDialog = new Slot();
                    var slot = 0;
                    if(slotDialog.ShowDialog() == DialogResult.OK)
                    {
                        slot = slotDialog.SlotIndex; 
                    }

                    baseOffset = (uint)(0x2598 + slot * 0x68548);

                    cmbTeam.Items.Clear();
                    lstPlayers.Items.Clear();
                    lstTeam.Items.Clear();



                    ParseSaveFile(saveStream);

                    cmbTeam.Items.AddRange(playerNames);




                    txtProfileName.Text = profileName;
                    txtOnlineName.Text = onlineName;
                    nudProfile.Value = profile;
                    nudProfileOnline.Value = onlineProfile;
                    nudInazumaPoints.Value = inazumaPoints;
                    nudHours.Value = hoursPlayed;
                    nudMinutes.Value = minutesPlayed / 0x1c200;
                    nudCreationTime.Value = creationTime;
                    nudCreationDate.Value = creationDate;


                    tabControl1.Enabled = true;
                    saveToolStripMenuItem.Enabled = true;
                    dumpToolStripMenuItem.Enabled = true;
                    nudProfile.Enabled = true;
                    


                }
            }
        }

     


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveStream = new MemoryStream(saveFile);
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Save file(inazuma2.sav) (*.sav) | *.sav | All files(*.*) | *.* ";
                sfd.DefaultExt = ".sav";
                sfd.FileName = "inazuma2.sav";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var filename = sfd.FileName;
                    var file = File.Open(filename, FileMode.Create);
                    using (var bw = new BeBinaryWriter(file))
                    {
                        bw.Write(saveFile);
                        bw.BaseStream.Position = 0x1d8;
                        bw.Write(StringTo16LongArray(onlineName));
                        bw.Write(onlineProfile);

                        bw.BaseStream.Position = baseOffset;
                        bw.Write(creationDate);
                        bw.Write(creationTime);
                        bw.Write(hoursPlayed);
                        bw.Write(minutesPlayed);

                        bw.BaseStream.Position = baseOffset + 0x1d4;
                        bw.Write(inazumaPoints);

                        bw.BaseStream.Position = baseOffset + PROFILENAME_OFFSET;
                        bw.Write(StringTo16LongArray(profileName));

                        for (var i = 0; i < 412; i++)
                        {
                            var player = players[i];
                            // STATS
                            bw.BaseStream.Position = baseOffset + STATS_OFFSET + i * 0x3c;
                            bw.Write(player.tp);
                            bw.BaseStream.Position += 1;
                            bw.Write(player.kick);
                            bw.BaseStream.Position += 1;
                            bw.Write(player._catch);
                            bw.BaseStream.Position += 1;
                            bw.Write(player.body);
                            bw.BaseStream.Position += 1;
                            bw.Write(player.guard);
                            bw.BaseStream.Position += 1;
                            bw.Write(player.control);
                            bw.BaseStream.Position += 1;
                            bw.Write(player.speed);

                            // WAZA
                            bw.BaseStream.Position = baseOffset + WAZA_OFFSET + i * 0x22;
                            bw.Write(player.lv1);
                            bw.Write(player.lv2);
                            bw.Write(player.lv3);
                            bw.BaseStream.Position += 2;
                            bw.Write(player.sp);
                            bw.BaseStream.Position += 6;
                            bw.Write(player.dribble);
                            bw.BaseStream.Position += 6;
                            bw.Write(player.defense);
                            bw.Write(player.lv1gk);
                            bw.Write(player.lv2gk);
                            bw.BaseStream.Position += 2;
                            bw.Write(player.lv3gk);

                        }
                        for (var i = 0; i < 16; i++)
                        {
                            bw.BaseStream.Position = baseOffset + TEAM_OFFSET + 0x14 * i;
                            bw.Write(team[i]);
                        }
                        bw.BaseStream.Position = baseOffset + PROFILE_OFFSET;
                        bw.Write(profile);

                    }
                    MessageBox.Show("Succesfully saved.", "Done");


                }

                
            }

            
        }

        private byte[] StringTo16LongArray(string text)
        {
            byte[] buffer = new byte[16];
            for (var i = 0; i < 16; i++)
                buffer[i] = 0;
            var textBuffer = sjis.GetBytes(text);
            for (var i = 0; i < 16; i++)
            {
                if (i == textBuffer.Length)
                    break;
                buffer[i] = textBuffer[i];
            }
            return buffer;
        }

        private void dumpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";
                sfd.DefaultExt = ".txt";
                sfd.FileName = "waza.txt";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var filename = sfd.FileName;
                    using (var sw = new StreamWriter(File.Open(filename, FileMode.Create)))
                    {
                        sw.WriteLine("==SAVE INFO==");
                        sw.WriteLine("Profile name : {0}", profileName);
                        sw.WriteLine("Online name : {0}",onlineName);
                        sw.WriteLine("Profile picture : {0} (row {1} column {2})", profile, (int)profile / 7, profile % 7);
                        sw.WriteLine("Online picture : {0} (row {1} column {2})", onlineProfile, (int)onlineProfile / 7, onlineProfile % 7);
                        sw.WriteLine("==TEAM==");
                        for (var i = 0; i < 16; i++)
                        {
                            sw.WriteLine("Player {0}: {1}", i + 1, playerNames[team[i]]);
                        }
                        sw.WriteLine("==PLAYERS==");
                        var index = 0;
                        foreach (var player in players)
                        {
                            sw.WriteLine("={0}=", playerNames[index]);
                            sw.WriteLine("STATS :");
                            sw.WriteLine("\t- Kick : {0}", player.kick);
                            sw.WriteLine("\t- Body : {0}", player.body);
                            sw.WriteLine("\t- Control : {0}", player.control);
                            sw.WriteLine("\t- Guard : {0}", player.guard);
                            sw.WriteLine("\t- Speed : {0}", player.speed);
                            sw.WriteLine("\t- Catch : {0}", player._catch);
                            sw.WriteLine("MOVES :");
                            sw.WriteLine("\t- Level 1 Shoot : {0}", wazaNames[player.lv1]);
                            sw.WriteLine("\t- Level 2 Shoot : {0}", wazaNames[player.lv2]);
                            sw.WriteLine("\t- Level 3 Shoot : {0}", wazaNames[player.lv3]);
                            sw.WriteLine("\t- SP Shoot : {0}", wazaNames[player.sp]);
                            sw.WriteLine("\t- Level 1 Catch : {0}", wazaNames[player.lv1gk]);
                            sw.WriteLine("\t- Level 2 Catch : {0}", wazaNames[player.lv2gk]);
                            sw.WriteLine("\t- Level 3 Catch : {0}", wazaNames[player.lv3gk]);
                            sw.WriteLine("\t- Dribble : {0}", wazaNames[player.dribble]);
                            sw.WriteLine("\t- Defense : {0}", wazaNames[player.defense]);
                            index += 1;
                        }

                    }
                }
            }
        }

        private void txtOnlineName_TextChanged(object sender, EventArgs e)
        {
            onlineName = txtOnlineName.Text;
        }

        private void nudProfile_ValueChanged(object sender, EventArgs e)
        {
            profile = (uint)nudProfile.Value;
        }

        private void nudProfileOnline_ValueChanged(object sender, EventArgs e)
        {
            onlineProfile = (uint)nudProfileOnline.Value;
        }

        private void toolTip1_Popup_1(object sender, PopupEventArgs e)
        {

        }

        private void nudCreationTime_ValueChanged(object sender, EventArgs e)
        {
            creationTime = (uint)nudCreationTime.Value;
        }

        private void nudCreationDate_ValueChanged(object sender, EventArgs e)
        {
            creationDate = (uint)nudCreationDate.Value;
        }

        private void dtpCreation_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nudMinutes_ValueChanged(object sender, EventArgs e)
        {
            minutesPlayed = (uint)nudMinutes.Value * 0x1c200;
        }

        private void nudHours_ValueChanged(object sender, EventArgs e)
        {
            hoursPlayed = (uint)nudHours.Value;
        }

        private void txtProfileName_TextChanged(object sender, EventArgs e)
        {
            profileName = txtProfileName.Text;
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void lstTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTeam.SelectedIndex != -1)
                cmbTeam.SelectedIndex = team[lstTeam.SelectedIndex];
        }

        private void cmbTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            team[lstTeam.SelectedIndex] = (short)cmbTeam.SelectedIndex;
            lstTeam.Items[lstTeam.SelectedIndex] = playerNames[cmbTeam.SelectedIndex];
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var player = players[lstPlayers.SelectedIndex];


            player.lv1 = Convert.ToInt16(txtLV1.Text, 16);
            player.lv2 = Convert.ToInt16(txtLV2.Text, 16);
            player.lv3 = Convert.ToInt16(txtLV3.Text, 16);
            player.lv1gk = Convert.ToInt16(txtCatch1.Text, 16);
            player.lv2gk = Convert.ToInt16(txtCatch2.Text, 16);
            player.lv3gk = Convert.ToInt16(txtCatch3.Text, 16);
            player.dribble = Convert.ToInt16(txtDribble.Text, 16);
            player.defense = Convert.ToInt16(txtDefense.Text, 16);
            player.sp = Convert.ToInt16(txtSP.Text, 16);

        }



        private void lstPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var player = players[lstPlayers.SelectedIndex];

            nudKick.Value = player.kick;
            nudBody.Value = player.body;
            nudControl.Value = player.control;
            nudGuard.Value = player.guard;
            nudCatch.Value = player._catch;
            nudSpeed.Value = player.speed;
            nudTP.Value = player.tp;

            txtLV1.Text = Convert.ToString(player.lv1, 16);
            txtLV2.Text = Convert.ToString(player.lv2, 16);
            txtLV3.Text = Convert.ToString(player.lv3, 16);
            txtSP.Text = Convert.ToString(player.sp, 16);
            txtDefense.Text = Convert.ToString(player.defense, 16);
            txtDribble.Text = Convert.ToString(player.dribble, 16);
            txtCatch1.Text = Convert.ToString(player.lv1gk, 16);
            txtCatch2.Text = Convert.ToString(player.lv2gk, 16);
            txtCatch3.Text = Convert.ToString(player.lv3gk, 16);


        }
    }
}
