using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Be.IO;
namespace Strikers2013Editor
{
    public partial class MoveEditor : Form
    {
        string path = "";
        MemoryStream ms;
        Move[] moves;
        public MoveEditor()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Move file (0/20.bin) (*.bin)|*.bin|All files (*.*)|*.*";
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    ms = new MemoryStream(File.ReadAllBytes(ofd.FileName));
                    listBox1.Enabled = true;
                    tabControl1.Enabled = true;
                    ParseMoveFile();
                    cmbTier.Items.AddRange(new string[] { "Lv.1", "Lv.2", "Lv.3", "SP" });
                    cmbElement.Items.AddRange(new string[] { "Wind", "Wood", "Fire", "Earth", "Void","???","???","???" }) ;
                    cmbStatus.Items.AddRange(new string[] { "Normal", "Long", "Block","Chain","5","6", });


                }
            }
        }

        private void ParseMoveFile()
        {
            var assembly = Assembly.GetExecutingAssembly();
            string[] moveNames;
            using (var movenamesfile = assembly.GetManifestResourceStream("Strikers2013Editor.wazaNames.txt"))
            {
                using (StreamReader sr = new StreamReader(movenamesfile))
                {
                    var moveNamesList = new List<string>();
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        moveNamesList.Add(line);
                    }
                    
                    moveNames = moveNamesList.ToArray();
                }
            }

            using(var br = new BeBinaryReader(ms))
            {
                br.BaseStream.Position += 24;
                var moveCount = br.ReadInt32();
                moves = new Move[moveCount];
                for(var i = 0; i < moveCount; i++)
                {
                    moves[i] = new Move();
                    moves[i].name = moveNames[i];
                    var wazaInfo = new short[70];
                    for(var _i = 0; _i < 70; _i++)
                    {
                       wazaInfo[_i] = br.ReadInt16();
                    }
                    moves[i].wazaInfo = wazaInfo;
                    listBox1.Items.Add(moves[i].name);
                }
            }
            

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var wazainfo = moves[listBox1.SelectedIndex].wazaInfo;

            cmbTier.SelectedIndex = wazainfo[0];
            nudPower.Value = wazainfo[1];
            nudPowerMax.Value = wazainfo[2];
            nudTP.Value = wazainfo[3];
            cmbElement.SelectedIndex = wazainfo[4];
            cmbStatus.SelectedIndex = wazainfo[5];
            nudCoop.Value = wazainfo[10];




        }
    }
}
