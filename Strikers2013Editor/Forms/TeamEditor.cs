using System;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using Strikers2013Editor.IO;
using Strikers2013Editor.Common;
using Strikers2013Editor.Logic;
using System.Windows.Forms.Design;

namespace Strikers2013Editor.Forms
{
    public partial class TeamEditor : Form
    {
        private TeamFile _teamFile;
        private TeamDef _team;
        private string[] PlayerNames;
        private string[] MoveNames;
        private string[] FormationNames;
        private int curTeam;
        public TeamEditor()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Team file (*.bin)|*.bin|All files (*.*)|*.*";
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    PlayerNames = Names.GetTextFile("Strikers2013Editor.Common.playerNames.txt");
                    MoveNames = Names.GetTextFile("Strikers2013Editor.Common.wazaNames.txt");
                    FormationNames = Names.GetTextFile("Strikers2013Editor.Common.formationNames.txt");

                    var fileName = ofd.FileName;
                    var file = File.OpenRead(fileName);
                    using (var br = new BeBinaryReader(file))
                    {
                        _teamFile = new TeamFile(br);
                    }
                    cmbPlayer.Items.AddRange(PlayerNames);
                    cmbManager.Items.AddRange(PlayerNames);
                    cmbCoach.Items.AddRange(PlayerNames);
                    cmbFormation.Items.AddRange(FormationNames);

                    cmbShoot1.Items.AddRange(MoveNames);
                    cmbShoot2.Items.AddRange(MoveNames);
                    cmbShoot3.Items.AddRange(MoveNames);
                    cmbShootSP.Items.AddRange(MoveNames);
                    cmbDribble.Items.AddRange(MoveNames);
                    cmbDefense.Items.AddRange(MoveNames);
                    cmbCatch1.Items.AddRange(MoveNames);
                    cmbCatch2.Items.AddRange(MoveNames);
                    cmbCatch3.Items.AddRange(MoveNames);
                    groupBox2.Enabled = true;
                    groupBox3.Enabled = true;
                    groupBox1.Enabled = true;
                    cmbTeam.Items.AddRange(new string[] { "Unused", "Main", "Match Mode - Level 2", "Match Mode - Level 3"} );
                    cmbTeam.SelectedIndex = curTeam = 1;
                    cmbMember.SelectedIndex = 0;
                    cmbPlayer1.SelectedIndex = 0;
                    cmbPlayer2.SelectedIndex = 0;
                    saveToolStripMenuItem.Enabled = true;
                }
            }
        }

        private void cmbTeam_SelectedIndexChanged(object sender, EventArgs e)
        {         
            cmbMember.Items.Clear();
            cmbPlayer1.Items.Clear();
            cmbPlayer2.Items.Clear();
            var index = cmbTeam.SelectedIndex;
            if (_team != null)
            {
                _teamFile.Teams[curTeam] = _team;
            }
            curTeam = index;
            _team = _teamFile.Teams[index];

            for (var i = 0; i < _team.Players.Count; i++)
            {
                var text = $"Player {i + 1} - {PlayerNames[_team.Players[i].PlayerId]}";
                var otherText = $"Player {i + 1}";
                cmbMember.Items.Add(text);
                cmbPlayer1.Items.Add(otherText);
                cmbPlayer2.Items.Add(otherText);
                
            }
            cmbMember.Items.RemoveAt(_team.Players.Count - 1);
            cmbPlayer1.Items.RemoveAt(_team.Players.Count - 1);
            cmbPlayer2.Items.RemoveAt(_team.Players.Count - 1);
            txtName.Text = _team.Name;
            cmbFormation.SelectedIndex = _team.Formation;
            cmbManager.SelectedIndex = _team.Manager;
            cmbCoach.SelectedIndex = _team.Coach;
            nudStrength.Value = _team.Strength;
            cmbMember.SelectedIndex = 0;
            cmbPlayer1.SelectedIndex = 0;
            cmbPlayer2.SelectedIndex = 0;
        }

        private void cmbMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            var player = _team.Players[cmbMember.SelectedIndex];
            cmbPlayer.SelectedIndex = player.PlayerId;
            nudPortrait.Value = player.MainPortrait;
            nudLeftPortrait.Value = player.LeftPortrait;
            nudRightPortrait.Value = player.RightPortrait;
            nudKakusei.Value = player.Kakusei;
            nudFormation.Value = player.FormationIndex;

            var stats = _teamFile.Stats[player.StatsIndex];
            nudKick.Value = stats.Kick;
            nudKickMax.Value = stats.MaxKick;
            nudBody.Value = stats.Body;
            nudBodyMax.Value = stats.MaxBody;
            nudControl.Value = stats.Control;
            nudControlMax.Value = stats.MaxControl;
            nudGuard.Value = stats.Guard;
            nudGuardMax.Value = stats.MaxGuard;
            nudCatch.Value = stats.Catch;
            nudCatchMax.Value = stats.MaxCatch;
            nudSpeed.Value = stats.Speed;
            nudSpeedMax.Value = stats.MaxSpeed;
            nudTP.Value = stats.TP;
            nudTPMax.Value = stats.MaxTP;

            var moveset = player.Moves;
            cmbShoot1.SelectedIndex = moveset.Lv1;
            cmbShoot2.SelectedIndex = moveset.Lv2;
            cmbShoot3.SelectedIndex = moveset.Lv3;
            cmbShootSP.SelectedIndex = moveset.SP;
            cmbDribble.SelectedIndex = moveset.Dribble;
            cmbDefense.SelectedIndex = moveset.Defense;
            cmbCatch1.SelectedIndex = moveset.Catch1;
            cmbCatch2.SelectedIndex = moveset.Catch2;
            cmbCatch3.SelectedIndex = moveset.Catch3;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            _team.Name = txtName.Text;
        }

        private void cmbFormation_SelectedIndexChanged(object sender, EventArgs e)
        {
            _team.Formation = (short)cmbFormation.SelectedIndex;
        }

        private void cmbCoach_SelectedIndexChanged(object sender, EventArgs e)
        {
            _team.Coach = (short)cmbCoach.SelectedIndex;
        }

        private void cmbManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            _team.Manager = (short)cmbManager.SelectedIndex;
        }

        private void nudStrength_ValueChanged(object sender, EventArgs e)
        {
            _team.Strength = (short)nudStrength.Value;
        }

        private void nudFriendValue_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnApplyFriend_Click(object sender, EventArgs e)
        {
            var index = cmbPlayer1.SelectedIndex * 16 + cmbPlayer2.SelectedIndex;
            _teamFile.KizunaData[index] = (byte)nudFriendValue.Value;
        }

        private void cmbPlayer2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = cmbPlayer1.SelectedIndex * 16 + cmbPlayer2.SelectedIndex;
            if (index > 0)
                nudFriendValue.Value = _teamFile.KizunaData[index];
        }

        private void cmbPlayer1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = cmbPlayer1.SelectedIndex * 16 + cmbPlayer2.SelectedIndex;
            if (index > 0)
                nudFriendValue.Value = _teamFile.KizunaData[index];
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var player = _team.Players[cmbMember.SelectedIndex];
            player.PlayerId = (short)cmbPlayer.SelectedIndex;
            player.MainPortrait = (int)nudPortrait.Value;
            player.LeftPortrait = (int)nudLeftPortrait.Value;
            player.RightPortrait = (int)nudRightPortrait.Value;
            player.FormationIndex = (int)nudFormation.Value;
            player.Kakusei = (int)nudKakusei.Value;

            var stats = _teamFile.Stats[player.StatsIndex];
            stats.Kick = (byte)nudKick.Value;
            stats.MaxKick = (byte)nudKickMax.Value;
            stats.Body = (byte)nudBody.Value;
            stats.MaxBody = (byte)nudBodyMax.Value;
            stats.Control = (byte)nudControl.Value;
            stats.MaxControl = (byte)nudControlMax.Value;
            stats.Guard = (byte)nudGuard.Value;
            stats.MaxGuard = (byte)nudGuardMax.Value;
            stats.Catch = (byte)nudCatch.Value;
            stats.MaxCatch = (byte)nudCatchMax.Value;
            stats.Speed = (byte)nudSpeed.Value;
            stats.MaxSpeed = (byte)nudSpeedMax.Value;
            stats.TP = (byte)nudTP.Value;
            stats.MaxTP = (byte)nudTPMax.Value;
            _teamFile.Stats[player.StatsIndex] = stats;

            var moveset = player.Moves;
            moveset.Lv1 = (short)cmbShoot1.SelectedIndex;
            moveset.Lv2 = (short)cmbShoot2.SelectedIndex;
            moveset.Lv3 = (short)cmbShoot3.SelectedIndex;
            moveset.SP = (short)cmbShootSP.SelectedIndex;
            moveset.Dribble = (short)cmbDribble.SelectedIndex;
            moveset.Defense = (short)cmbDefense.SelectedIndex;
            moveset.Catch1 = (short)cmbCatch1.SelectedIndex;
            moveset.Catch2 = (short)cmbCatch2.SelectedIndex;
            moveset.Catch3 = (short)cmbCatch3.SelectedIndex;
            player.Moves = moveset;

            _team.Players[cmbMember.SelectedIndex] = player;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var copy = _team.Players.Last();
            var newPlayer = new TeamPlayer(copy);
            _team.Players.Add(newPlayer);

            var text = $"Player {_team.Players.Count} - {PlayerNames[_team.Players[_team.Players.Count].PlayerId]}";
            var otherText = $"Player {_team.Players.Count}";
            cmbMember.Items.Add(text);
            cmbPlayer1.Items.Add(otherText);
            cmbPlayer2.Items.Add(otherText);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Team File (*.bin)|*.bin|All files (*.*)|*.*";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var bw = new BeBinaryWriter(File.OpenWrite(sfd.FileName)))
                        _teamFile.Write(bw);
                    MessageBox.Show("Succesfully saved.", "Done");
                }
            }
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            // kizuna first
            for (var i = 0; i < _teamFile.KizunaData.Length; i++) _teamFile.KizunaData[i] = 100;

            for (var i = 0; i < _team.Players.Count; i++) _team.Players[i].Kakusei = Player.Kakusei[_team.Players[i].PlayerId];
        }
    }
}
