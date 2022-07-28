using System;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using Strikers2013Editor.IO;
using Strikers2013Editor.Common;
using Strikers2013Editor.Logic;
namespace Strikers2013Editor.Forms
{
    public partial class TeamEditor : Form
    {
        private TeamFile _teamFile;
        private TeamDef _team;
        private string[] PlayerNames;
        private string[] MoveNames;
        private string[] FormationNames;
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
                    cmbTeam.Items.AddRange(Enumerable.Range(1, 4).Select(x => $"Team {x}").ToArray());
                    cmbTeam.SelectedIndex = 0;
                    
                }
            }
        }

        private void cmbTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMember.Items.Clear();
            var index = cmbTeam.SelectedIndex;
            _team = _teamFile.Teams[index];

            for (var i = 0; i < _team.Players.Count; i++)
            {
                var text = $"Player {i + 1} - {PlayerNames[_team.Players[i].PlayerId]}";
                cmbMember.Items.Add(text);
                cmbPartner.Items.Add(text);
            }
            txtName.Text = _team.Name;
            cmbFormation.SelectedIndex = _team.Formation;
            cmbManager.SelectedIndex = _team.Manager;
            cmbCoach.SelectedIndex = _team.Coach;
            nudStrength.Value = _team.Strength;
        }

        private void cmbMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            var player = _team.Players[cmbMember.SelectedIndex];
            cmbPlayer.SelectedIndex = player.PlayerId;
            nudPortrait.Value = player.MainPortrait;
            nudLeftPortrait.Value = player.LeftPortrait;
            nudRightPortrait.Value = player.RightPortrait;

            var stats = _teamFile.Stats[cmbMember.SelectedIndex];
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

        private void cmbPartner_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = cmbMember.SelectedIndex * 16 + cmbPartner.SelectedIndex;
            nudFriendValue.Value = _teamFile.KizunaData[index];
        }
    }
}
