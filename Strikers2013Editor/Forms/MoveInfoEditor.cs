using Strikers2013Editor.Common;
using Strikers2013Editor.IO;
using Strikers2013Editor.Logic;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Strikers2013Editor.Forms
{
    public partial class MoveInfoEditor : Form
    {
        private byte[] data;
        private MoveInfo[] moves;
        public MoveInfoEditor()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Move Animation Info (40079) (*.bin)|*.bin|All files (*.*)|*.*";
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    data = File.ReadAllBytes(ofd.FileName);
                    ParseMoveInfoFile(data);
                    cmbMove.Enabled = true;
                    saveToolStripMenuItem.Enabled = true;
                    cmbMove.Items.AddRange(Names.GetTextFile("Strikers2013Editor.Common.wazaNames.txt"));
                    var playerNames = Names.GetTextFile("Strikers2013Editor.Common.playerNames.txt");
                    cmbStadium.Items.AddRange(Names.GetTextFile("Strikers2013Editor.Common.stadiumNames.txt"));
                    cmbUser.Items.AddRange(playerNames);
                    cmbOpp1.Items.AddRange(playerNames);
                    cmbOpp2.Items.AddRange(playerNames);
                    cmbOpp3.Items.AddRange(playerNames);
                    var uniformNames = Names.GetTextFile("Strikers2013Editor.Common.emblemNames.txt");
                    cmbOppUniform.Items.AddRange(uniformNames);
                    cmbUserUniform.Items.AddRange(uniformNames);
                    groupBox1.Enabled = true;
                    groupBox2.Enabled = true;
                    groupBox3.Enabled = true;
                    groupBox4.Enabled = true;
                    groupBox5.Enabled = true;


                    cmbMoveType.Items.AddRange(new string[] { "Shoot", "Dribbling", "Defense", "Catch" });
                }
            }
        }

        private void ParseMoveInfoFile(byte[] move)
        {
            using (var br = new BeBinaryReader(new MemoryStream(move)))
            {
                br.BaseStream.Position = 0x336F4;
                moves = new MoveInfo[0x1DD];
                for (int i = 0; i < 0x1DD; i++) moves[i] = new MoveInfo(br);
            }

        }


        private void cmbMove_SelectedIndexChanged(object sender, EventArgs e)
        {
            var move = moves[cmbMove.SelectedIndex];
            cmbStadium.SelectedIndex = move.Stadium;
            nudThumb.Value = move.PreviewImage;
            cmbUserUniform.SelectedIndex = move.UserUniform;
            cmbOppUniform.SelectedIndex = move.OpponentUniform;
            cmbUser.SelectedIndex = move.User;
            cmbOpp1.SelectedIndex = move.Opponent1;
            cmbOpp2.SelectedIndex = move.Opponent2;
            cmbOpp3.SelectedIndex = move.Opponent3;
            nudNameMain.Value = move.Name;
            nudNameMainCopy.Value = move.NameCopy;
            nudSorting.Value = move.SortingName;
            nudBall.Value = move.BallEffect;
            nudBallTail.Value = move.BallTailEffect;
            nudScene1.Value = move.SceneEffect;
            nudScene2.Value = move.SceneEffect2;
            nudField1.Value = move.FieldEffect;
            nudField2.Value = move.FieldEffect2;
            nudStartFrame.Value = move.SkipStart;
            nudEndFrame.Value = move.SkipEnd;
            cmbMoveType.SelectedIndex = (int)move.MoveType;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var move = moves[cmbMove.SelectedIndex];
            move.Stadium = cmbStadium.SelectedIndex;
            move.PreviewImage = (int)nudThumb.Value;
            move.UserUniform = (short)cmbUserUniform.SelectedIndex;
            move.OpponentUniform = (short)cmbOppUniform.SelectedIndex;
            move.User = (short)cmbUser.SelectedIndex;
            move.Opponent1 = (short)cmbOpp1.SelectedIndex;
            move.Opponent2 = (short)cmbOpp2.SelectedIndex;
            move.Opponent3 = (short)cmbOpp3.SelectedIndex;
            move.Name = (int)nudNameMain.Value;
            move.NameCopy = (int)nudNameMainCopy.Value;
            move.SortingName = (int)nudSorting.Value;
            move.BallEffect = (int)nudBall.Value;
            move.BallTailEffect = (int)nudBallTail.Value;
            move.SceneEffect = (int)nudScene1.Value;
            move.SceneEffect2 = (int)nudScene2.Value;
            move.FieldEffect = (int)nudField1.Value;
            move.FieldEffect2 = (int)nudField2.Value;
            move.SkipStart = (int)nudStartFrame.Value;
            move.SkipEnd = (int)nudEndFrame.Value;
            move.MoveType = (Movetype)cmbMoveType.SelectedIndex;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Move Animation Info (40079) (*.bin)|*.bin|All files (*.*)|*.*";
                sfd.DefaultExt = ".bin";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var filename = sfd.FileName;
                    var file = File.Open(filename, FileMode.Create);
                    using (var bw = new BeBinaryWriter(file))
                    {
                        bw.Write(data);
                        bw.BaseStream.Position = 0x336F4;
                        foreach (var move in moves)
                        {
                            move.Write(bw);
                        }
                    }
                    MessageBox.Show("Succesfully saved.", "Done");
                }
            }
        }
    }
}
