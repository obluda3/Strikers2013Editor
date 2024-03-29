﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Strikers2013Editor.IO;
using Strikers2013Editor.Common;

namespace Strikers2013Editor.Logic
{
    class Move
    {
        public ushort[] wazaInfo = new ushort[70];

        public Tier Tier;
        public ushort BasePower;
        public ushort MaxPower;
        public ushort Tp;
        public Element Element;
        public Status Status;
        public ushort OutputRange;
        public ushort OutputRangeAssist;
        public ushort EffectRange;
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
        public PowerUpIndicator PowerUpIndicator;
        public ushort InvocationAnimationTimer;
        public ushort Unk39;

        public Move() { }
        public Move(BeBinaryReader br)
        {
            Tier = (Tier)br.ReadUInt16();
            BasePower = br.ReadUInt16();
            MaxPower = br.ReadUInt16();
            Tp = br.ReadUInt16();
            Element = (Element)br.ReadUInt16();
            Status = (Status)br.ReadUInt16();
            OutputRange = br.ReadUInt16();
            OutputRangeAssist = br.ReadUInt16();
            EffectRange = br.ReadUInt16();
            Unk4 = br.ReadUInt16();
            CoopPartnersCount = br.ReadUInt16();
            Unka = br.ReadUInt16();
            Unkb = br.ReadUInt16();
            Users = br.ReadMultipleUShort(10).ToArray();
            Partners = br.ReadMultipleUShort(10).ToArray();
            Unk5 = br.ReadUInt16();
            Unk6 = br.ReadUInt16();
            Unk7 = br.ReadUInt16();
            Unk8 = br.ReadUInt16();
            Unk9 = br.ReadUInt16();
            Unk10 = br.ReadUInt16();
            TextDescription = br.ReadUInt16();
            Unk12 = br.ReadUInt16();
            Unk13 = br.ReadUInt16();
            Unk14 = br.ReadUInt16();
            TextUser = br.ReadUInt16();
            Unk16 = br.ReadUInt16();
            Unk17 = br.ReadUInt16();
            Unk18 = br.ReadUInt16();
            Unk19 = br.ReadUInt16();
            Unk20 = br.ReadUInt16();
            Unk21 = br.ReadUInt16();
            Unk22 = br.ReadUInt16();
            Unk23 = br.ReadUInt16();
            Unk24 = br.ReadUInt16();
            Unk25 = br.ReadUInt16();
            Unk26 = br.ReadUInt16();
            Unk27 = br.ReadUInt16();
            Unk28 = br.ReadUInt16();
            Unk29 = br.ReadUInt16();
            Unk30 = br.ReadUInt16();
            Unk31 = br.ReadUInt16();
            Unk32 = br.ReadUInt16();
            Unk33 = br.ReadUInt16();
            Unk34 = br.ReadUInt16();
            Unk35 = br.ReadUInt16();
            Unk36 = br.ReadUInt16();
            Unk37 = br.ReadUInt16();
            Unk38 = br.ReadUInt16();
            PowerUpIndicator = (PowerUpIndicator) br.ReadUInt16();
            InvocationAnimationTimer = br.ReadUInt16();
            Unk39 = br.ReadUInt16();
        }

        public void Write(BeBinaryWriter bw)
        {
            bw.Write((ushort)Tier);
            bw.Write(BasePower);
            bw.Write(MaxPower);
            bw.Write(Tp);
            bw.Write((ushort)Element);
            bw.Write((ushort)Status);
            bw.Write(OutputRange);
            bw.Write(OutputRangeAssist);
            bw.Write(EffectRange);
            bw.Write(Unk4);
            bw.Write(CoopPartnersCount);
            bw.Write(Unka);
            bw.Write(Unkb);
            bw.Write(Users);
            bw.Write(Partners);
            bw.Write(Unk5);
            bw.Write(Unk6);
            bw.Write(Unk7);
            bw.Write(Unk8);
            bw.Write(Unk9);
            bw.Write(Unk10);
            bw.Write(TextDescription);
            bw.Write(Unk12);
            bw.Write(Unk13);
            bw.Write(Unk14);
            bw.Write(TextUser);
            bw.Write(Unk16);
            bw.Write(Unk17);
            bw.Write(Unk18);
            bw.Write(Unk19);
            bw.Write(Unk20);
            bw.Write(Unk21);
            bw.Write(Unk22);
            bw.Write(Unk23);
            bw.Write(Unk24);
            bw.Write(Unk25);
            bw.Write(Unk26);
            bw.Write(Unk27);
            bw.Write(Unk28);
            bw.Write(Unk29);
            bw.Write(Unk30);
            bw.Write(Unk31);
            bw.Write(Unk32);
            bw.Write(Unk33);
            bw.Write(Unk34);
            bw.Write(Unk35);
            bw.Write(Unk36);
            bw.Write(Unk37);
            bw.Write(Unk38);
            bw.Write((ushort)PowerUpIndicator);
            bw.Write(InvocationAnimationTimer);
            bw.Write(Unk39);
        }
    }
}
