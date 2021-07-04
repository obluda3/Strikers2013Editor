using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Strikers2013Editor.IO;

namespace Strikers2013Editor.Logic
{
    class Move
    {
        public string name;
        public ushort[] wazaInfo = new ushort[70];

        public Tier Tier;
        public ushort BasePower;
        public ushort MaxPower;
        public ushort Tp;
        public Element Element;
        public Status Status;
        public ushort Unk1;
        public ushort Unk2;
        public ushort Unk3;
        public ushort Unk4;
        public ushort CoopPartnersCount;
        public ushort Unka;
        public ushort Unkb;
        public ushort[] Users = new ushort[10];
        public ushort[] Partners = new ushort[10];
        public ushort Unk5;
        public ushort Unk6;
        public ushort Unk7;
        public ushort Unk8;
        public ushort Unk9;
        public ushort Unk10;
        public ushort TextDescription;
        public ushort Unk12;
        public ushort Unk13;
        public ushort Unk14;
        public ushort TextUser;
        public ushort Unk16;
        public ushort Unk17;
        public ushort Unk18;
        public ushort Unk19;
        public ushort Unk20;
        public ushort Unk21;
        public ushort Unk22;
        public ushort Unk23;
        public ushort Unk24;
        public ushort Unk25;
        public ushort Unk26;
        public ushort Unk27;
        public ushort Unk28;
        public ushort Unk29;
        public ushort Unk30;
        public ushort Unk31;
        public ushort Unk32;
        public ushort Unk33;
        public ushort Unk34;
        public ushort Unk35;
        public ushort Unk36;
        public ushort Unk37;
        public ushort Unk38;
        public ushort PowerUpIndicator;
        public ushort InvocationAnimationTimer;
        public ushort Unk39;

        public Move() { }
        public Move(BeBinaryReader br)
        {

        }


    }
}
