using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Strikers2013Editor.IO;

namespace Strikers2013Editor.Logic
{
    struct Player
    {
        public byte[] stats;
        // 0  -> TP
        // 1  -> Max TP
        // 2  -> Kick
        // 3  -> Max Kick
        // 4  -> Catch
        // 5  -> Max Catch
        // 6  -> Body
        // 7  -> Max Body
        // 8  -> Guard
        // 9  -> Max Guard
        // 10 -> Control
        // 11 -> Max Control
        // 12 -> Speed
        // 13 -> Max Speed

        public short[] waza;
        // 0  -> LV1
        // 1  -> LV2
        // 2  -> LV3
        // 3  -> undef
        // 4  -> SP
        // 5  -> undef
        // 6  -> undef
        // 7  -> undef
        // 8  -> Dribble
        // 9  -> undef
        // 10 -> undef
        // 11 -> undef
        // 12 -> Defense
        // 13 -> Catch 1
        // 14 -> Catch 2
        // 15 -> undef
        // 16 -> Catch 3

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
            SP = br.ReadInt16();
            unk2 = br.ReadInt16();
            unk3 = br.ReadInt16();
            unk4 = br.ReadInt16();
            Dribble = br.ReadInt16();
            unk5 = br.ReadInt16();
            unk6 = br.ReadInt16();
            unk7 = br.ReadInt16();
            Defense = br.ReadInt16();
            Catch1 = br.ReadInt16();
            Catch2 = br.ReadInt16();
            unk8 = br.ReadInt16();
            Catch3 = br.ReadInt16();
        }
        
        public void Write(BeBinaryWriter bw)
        {
            bw.Write(Lv1);
            bw.Write(Lv2);
            bw.Write(Lv3);
            bw.Write(unk1);
            bw.Write(SP);
            bw.Write(unk2);
            bw.Write(unk3);
            bw.Write(unk4);
            bw.Write(Dribble);
            bw.Write(unk5);
            bw.Write(unk6);
            bw.Write(unk7);
            bw.Write(Defense);
            bw.Write(Catch1);
            bw.Write(Catch2);
            bw.Write(unk8);
            bw.Write(Catch3);
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
        public int Emblem;
        public int Manager;
        public int Coach;
        public string Name;

        public TeamPlayer[] Players;

        public Team(BeBinaryReader br) 
        {
            Kit = br.ReadInt32();
            Emblem = br.ReadInt32();
            Manager = br.ReadInt32();
            Coach = br.ReadInt32();
            Players = new TeamPlayer[16];
            Name = "";

            for (var i = 0; i < 16; i++)
                Players[i] = new TeamPlayer(br);
        }

        public void Write(BeBinaryWriter bw) 
        {
            bw.Write(Kit);
            bw.Write(Emblem);
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
