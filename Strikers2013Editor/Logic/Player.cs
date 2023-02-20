using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Strikers2013Editor.IO;

namespace Strikers2013Editor.Logic
{
    class Player
    {
        public SavePlayerParam Stats;
        public MoveList MoveList;

        public static Dictionary<int, int> Kakusei = new Dictionary<int, int> { { 1, 3 }, { 4, 2 }, { 7, 2 }, { 10, 2 }, { 12, 2 }, { 15, 2 }, { 17, 2 }, { 19, 2 }, { 21, 2 }, { 29, 2 }, { 31, 2 }, { 34, 2 }, { 38, 2 }, { 26, 2 }, { 23, 3 }, { 37, 2 }, { 60, 2 }, { 64, 2 }, { 67, 2 }, { 68, 2 }, { 69, 2 }, { 71, 2 }, { 72, 2 }, { 73, 2 }, { 74, 2 }, { 75, 2 }, { 77, 2 }, { 78, 2 }, { 79, 2 }, { 80, 2 }, { 81, 2 }, { 82, 2 }, { 83, 2 }, { 84, 2 }, { 85, 2 }, { 87, 2 }, { 89, 2 }, { 2, 3 }, { 8, 2 }, { 30, 2 }, { 32, 2 }, { 35, 2 }, { 39, 2 }, { 41, 2 }, { 43, 2 }, { 45, 2 }, { 47, 2 }, { 49, 2 }, { 50, 2 }, { 51, 2 }, { 24, 2 }, { 63, 2 }, { 92, 2 }, { 93, 2 }, { 94, 2 }, { 95, 2 }, { 96, 2 }, { 97, 2 }, { 98, 2 }, { 99, 2 }, { 100, 2 }, { 101, 2 }, { 102, 2 }, { 103, 2 }, { 104, 2 }, { 105, 2 }, { 57, 2 }, { 106, 2 }, { 107, 2 }, { 108, 2 }, { 109, 2 }, { 110, 2 }, { 111, 2 }, { 113, 2 }, { 114, 2 }, { 115, 2 }, { 116, 2 }, { 117, 2 }, { 6, 2 }, { 11, 2 }, { 14, 2 }, { 16, 2 }, { 18, 2 }, { 20, 2 }, { 22, 2 }, { 119, 2 }, { 121, 2 }, { 123, 2 }, { 28, 2 }, { 3, 3 }, { 5, 2 }, { 9, 2 }, { 13, 2 }, { 36, 2 }, { 42, 2 }, { 44, 2 }, { 46, 2 }, { 48, 2 }, { 52, 2 }, { 53, 2 }, { 55, 2 }, { 58, 2 }, { 59, 2 }, { 62, 2 }, { 27, 2 }, { 56, 2 }, { 25, 2 }, { 65, 2 }, { 70, 2 }, { 76, 2 }, { 86, 2 }, { 90, 2 }, { 91, 2 }, { 112, 2 }, { 124, 2 }, { 125, 2 }, { 126, 2 }, { 127, 2 }, { 128, 2 }, { 129, 2 }, { 130, 2 }, { 131, 2 }, { 132, 2 }, { 33, 2 }, { 40, 2 }, { 88, 2 }, { 134, 2 }, { 135, 2 }, { 136, 2 }, { 137, 2 }, { 138, 2 }, { 139, 2 }, { 143, 2 }, { 144, 2 }, { 145, 2 }, { 190, 2 }, { 191, 2 }, { 393, 2 }, { 394, 2 }, { 146, 2 }, { 147, 2 }, { 148, 2 }, { 149, 2 }, { 150, 2 }, { 151, 2 }, { 152, 2 }, { 153, 2 }, { 154, 2 }, { 155, 2 }, { 156, 2 }, { 173, 2 }, { 174, 2 }, { 175, 2 }, { 176, 2 }, { 177, 2 }, { 178, 2 }, { 179, 2 }, { 180, 2 }, { 181, 2 }, { 182, 2 }, { 183, 2 }, { 157, 2 }, { 158, 2 }, { 159, 2 }, { 160, 2 }, { 161, 2 }, { 162, 2 }, { 163, 2 }, { 164, 2 }, { 165, 2 }, { 166, 2 }, { 167, 2 }, { 168, 2 }, { 169, 2 }, { 170, 2 }, { 171, 2 }, { 172, 2 }, { 192, 3 }, { 193, 3 }, { 208, 3 }, { 209, 3 }, { 211, 2 }, { 212, 2 }, { 213, 2 }, { 214, 2 }, { 215, 2 }, { 216, 2 }, { 218, 2 }, { 219, 3 }, { 395, 2 }, { 396, 2 }, { 194, 3 }, { 220, 2 }, { 259, 3 }, { 254, 2 }, { 255, 2 }, { 256, 2 }, { 257, 2 }, { 258, 3 }, { 260, 2 }, { 261, 3 }, { 262, 3 }, { 263, 3 }, { 264, 3 }, { 133, 2 }, { 142, 2 }, { 224, 2 }, { 225, 2 }, { 226, 2 }, { 227, 2 }, { 228, 2 }, { 229, 2 }, { 230, 2 }, { 232, 2 }, { 233, 2 }, { 234, 2 }, { 235, 2 }, { 236, 2 }, { 237, 2 }, { 231, 2 }, { 141, 2 }, { 238, 2 }, { 239, 2 }, { 240, 2 }, { 241, 2 }, { 242, 2 }, { 243, 2 }, { 244, 2 }, { 245, 2 }, { 246, 2 }, { 247, 2 }, { 248, 2 }, { 249, 2 }, { 250, 2 }, { 140, 2 }, { 400, 2 }, { 399, 2 }, { 402, 2 }, { 272, 2 }, { 273, 2 }, { 274, 2 }, { 275, 2 }, { 276, 2 }, { 277, 2 }, { 401, 2 }, { 403, 2 }, { 301, 3 }, { 309, 2 }, { 310, 2 }, { 311, 2 }, { 312, 2 }, { 313, 2 }, { 314, 2 }, { 315, 2 }, { 316, 2 }, { 317, 2 }, { 318, 2 }, { 377, 2 }, { 378, 2 }, { 389, 2 }, { 319, 3 }, { 320, 3 }, { 321, 3 }, { 322, 2 }, { 323, 2 }, { 324, 2 }, { 325, 2 }, { 326, 2 }, { 327, 2 }, { 328, 2 }, { 329, 2 }, { 330, 2 }, { 331, 2 }, { 253, 3 }, { 332, 3 }, { 333, 3 }, { 335, 3 }, { 336, 3 }, { 337, 3 }, { 252, 3 }, { 340, 2 }, { 217, 2 }, { 334, 3 }, { 339, 3 }, { 251, 3 }, { 341, 3 }, { 342, 3 }, { 343, 3 }, { 344, 3 }, { 345, 3 }, { 346, 2 }, { 347, 3 }, { 348, 2 }, { 349, 2 }, { 375, 3 }, { 376, 3 }, { 350, 3 }, { 351, 2 }, { 352, 2 }, { 353, 2 }, { 354, 2 }, { 355, 2 }, { 357, 2 }, { 358, 2 }, { 359, 2 }, { 360, 2 }, { 356, 2 }, { 366, 2 }, { 411, 2 }, { 362, 2 }, { 363, 2 }, { 365, 2 }, { 367, 2 }, { 368, 2 }, { 369, 2 }, { 370, 2 }, { 371, 2 }, { 372, 2 }, { 373, 2 }, { 374, 2 }, { 184, 2 }, { 207, 2 }, { 54, 2 }, { 61, 2 }, { 66, 2 }, { 118, 2 }, { 120, 2 }, { 122, 2 }, { 185, 2 }, { 186, 2 }, { 187, 2 }, { 188, 2 }, { 189, 2 }, { 206, 2 }, { 398, 2 }, { 397, 2 }, { 404, 2 }, { 303, 3 }, { 307, 3 }, { 266, 2 }, { 306, 3 }, { 221, 2 }, { 222, 2 }, { 223, 2 }, { 265, 2 }, { 270, 2 }, { 302, 3 }, { 304, 3 }, { 305, 2 }, { 308, 2 }, { 338, 2 }, { 364, 2 }, { 379, 2 }, { 392, 2 }, { 380, 2 }, { 381, 2 }, { 382, 2 }, { 383, 2 }, { 384, 2 }, { 385, 2 }, { 386, 2 }, { 391, 2 }, { 390, 2 }, { 387, 2 }, { 388, 2  };
    }
    class MoveList
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
    class SavePlayerParam
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
        public int Kakusei;
        public int XP;
        public short MoveUnk;
        public short MoveKakusei2;
        public short MoveKakusei2_2;
        public short MoveKakusei2_3;
        public short MoveKakusei3;
        public short MoveKakusei3_2;
        public short MoveKakusei3_3;
        public short Unk2;

        public SavePlayerParam(BeBinaryReader br)
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
            Unk = br.ReadBytes(0xE);
            Kakusei = br.ReadInt32();
            XP = br.ReadInt32();
            MoveUnk = br.ReadInt16();
            MoveKakusei2 = br.ReadInt16();
            MoveKakusei2_2 = br.ReadInt16();
            MoveKakusei2_3 = br.ReadInt16();
            MoveKakusei3 = br.ReadInt16();
            MoveKakusei3_2 = br.ReadInt16();
            MoveKakusei3_3 = br.ReadInt16();
            Unk2 = br.ReadInt16();
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
            bw.Write(Kakusei);
            bw.Write(XP);
            bw.Write(MoveUnk);
            bw.Write(MoveKakusei2);
            bw.Write(MoveKakusei2_2);
            bw.Write(MoveKakusei2_3);
            bw.Write(MoveKakusei3);
            bw.Write(MoveKakusei3_2);
            bw.Write(MoveKakusei3_3);
            bw.Write(Unk2);
        }
    }

    class Team 
    {
        public int Kit;
        public int Formation;
        public int Manager;
        public short Emblem;
        public int Coach;
        public string Name;

        public SaveTeamPlayer[] Players;

        public Team(BeBinaryReader br) 
        {
            br.BaseStream.Position += 2;
            Kit = br.ReadInt16();
            Formation = br.ReadInt32();
            Manager = br.ReadInt32();
            Coach = br.ReadInt32();
            Emblem = 0; //Placeholder
            Players = new SaveTeamPlayer[16];
            Name = "";

            for (var i = 0; i < 16; i++)
                Players[i] = new SaveTeamPlayer(br);
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
    class SaveTeamPlayer 
    {
        
        public int Id;
        public int KitNumber;
        public int FormationIndex;
        public int ClubroomKit;
        public int Flag; // & 0x2000 => key player

        public SaveTeamPlayer(BeBinaryReader br) 
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
