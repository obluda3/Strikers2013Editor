﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Strikers2013Editor.IO;

namespace Strikers2013Editor.Logic
{
    struct Player
    {
        public Stats Stats;
        public MoveList MoveList;
    }
    struct MoveList
    {
        public short Lv1;
        public short Lv2;
        public short Lv3;
        public short unk1;
        public short SP;
        public short unk2;
        public short unk3;
        public short unk4;
        public short Dribble;
        public short unk5;
        public short unk6;
        public short unk7;
        public short Defense;
        public short Catch1;
        public short Catch2;
        public short unk8;
        public short Catch3;

        public MoveList(BeBinaryReader br)
        {
            Lv1 = br.ReadInt16();
            Lv2 = br.ReadInt16();
            Lv3 = br.ReadInt16();
            unk1 = br.ReadInt16();
            Dribble = br.ReadInt16();
            unk2 = br.ReadInt16();
            unk3 = br.ReadInt16();
            unk4 = br.ReadInt16();
            Defense = br.ReadInt16();
            unk5 = br.ReadInt16();
            unk6 = br.ReadInt16();
            unk7 = br.ReadInt16();
            Catch1 = br.ReadInt16();
            Catch2 = br.ReadInt16();
            Catch3 = br.ReadInt16();
            unk8 = br.ReadInt16();
            SP = br.ReadInt16();
        }
        
        public void Write(BeBinaryWriter bw)
        {
            bw.Write(Lv1);
            bw.Write(Lv2);
            bw.Write(Lv3);
            bw.Write(unk1);
            bw.Write(Dribble);
            bw.Write(unk2);
            bw.Write(unk3);
            bw.Write(unk4);
            bw.Write(Defense);
            bw.Write(unk5);
            bw.Write(unk6);
            bw.Write(unk7);
            bw.Write(Catch1);
            bw.Write(Catch2);
            bw.Write(Catch3);
            bw.Write(unk8);
            bw.Write(SP);
        }
    }
    struct Stats
    {
        // LSB :
        // AAXY BBBB
        // X => Miximax level 2
        // Y => Miximax level 1
        public int Flag;

        public int Unknown;
        public byte TP;
        public byte MaxTP;
        public byte Kick;
        public byte MaxKick;
        public byte Catch;
        public byte MaxCatch;
        public byte Body;
        public byte MaxBody;
        public byte Guard;
        public byte MaxGuard;
        public byte Control;
        public byte MaxControl;
        public byte Speed;
        public byte MaxSpeed;
        public byte[] Unk;

        public Stats(BeBinaryReader br)
        {
            var pos = br.BaseStream.Position;
            Flag = br.ReadInt32();
            Unknown = br.ReadInt32();
            TP = br.ReadByte();
            MaxTP = br.ReadByte();
            Kick = br.ReadByte();
            MaxKick = br.ReadByte();
            Catch = br.ReadByte();
            MaxCatch = br.ReadByte();
            Body = br.ReadByte();
            MaxBody = br.ReadByte();
            Guard = br.ReadByte();
            MaxGuard = br.ReadByte();
            Control = br.ReadByte();
            MaxControl = br.ReadByte();
            Speed = br.ReadByte();
            MaxSpeed = br.ReadByte();
            var length = 0x3c - (br.BaseStream.Position - pos);
            Unk = br.ReadBytes((int)length);
        }

        public void Write(BeBinaryWriter bw)
        {
            bw.Write(Flag);
            bw.Write(Unknown);
            bw.Write(TP);
            bw.Write(MaxTP);
            bw.Write(Kick);
            bw.Write(MaxKick);
            bw.Write(Catch);
            bw.Write(MaxCatch);
            bw.Write(Body);
            bw.Write(MaxBody);
            bw.Write(Guard);
            bw.Write(MaxGuard);
            bw.Write(Control);
            bw.Write(MaxControl);
            bw.Write(Speed);
            bw.Write(MaxSpeed);
            bw.Write(Unk);
        }
    }

    struct Team 
    {
        public int Kit;
        public int Formation;
        public int Manager;
        public short Emblem;
        public int Coach;
        public string Name;

        public TeamPlayer[] Players;

        public Team(BeBinaryReader br) 
        {
            br.BaseStream.Position += 2;
            Kit = br.ReadInt16();
            Formation = br.ReadInt32();
            Manager = br.ReadInt32();
            Coach = br.ReadInt32();
            Emblem = 0; //Placeholder
            Players = new TeamPlayer[16];
            Name = "";

            for (var i = 0; i < 16; i++)
                Players[i] = new TeamPlayer(br);
        }

        public void Write(BeBinaryWriter bw) 
        {
            bw.BaseStream.Position += 2;
            bw.Write((short)Kit);
            bw.Write(Formation);
            bw.Write(Manager);
            bw.Write(Coach);
            foreach (var player in Players)
                player.Write(bw);
        }
    }
    struct TeamPlayer 
    {
        
        public int Id;
        public int KitNumber;
        public int FormationIndex;
        public int ClubroomKit;
        public int Flag; // & 0x2000 => key player
        /*public TeamPlayer(BeBinaryReader br)
        {

        }*/

        public TeamPlayer(BeBinaryReader br) 
        {
            Id = br.ReadInt32();
            KitNumber = br.ReadInt32();
            FormationIndex = br.ReadInt32();
            ClubroomKit = br.ReadInt32();
            Flag = br.ReadInt32();
        }

        public void Write(BeBinaryWriter bw) 
        {
            bw.Write(Id);
            bw.Write(KitNumber);
            bw.Write(FormationIndex);
            bw.Write(ClubroomKit);
            bw.Write(Flag);
        }
    }
}
