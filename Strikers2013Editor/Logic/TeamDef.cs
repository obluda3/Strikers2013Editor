using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Strikers2013Editor.IO;

namespace Strikers2013Editor.Logic
{
    class TeamFile
    {
        public List<TeamPlayerParam> Stats;
        public byte[] KizunaData;
        public TeamDef[] Teams;

        public TeamFile(BeBinaryReader br)
        {
            br.BaseStream.Position = 12;
            var teamDefsOff = br.ReadInt32();
            var teamDefCount = br.ReadInt32();
            var statsOff = br.ReadInt32();
            var statsCount = br.ReadInt32();
            var kizunaOff = br.ReadInt32();
            var kizunaCount = br.ReadInt32();

            br.BaseStream.Position = teamDefsOff;
            Teams = new TeamDef[teamDefCount-1];
            for (int i = 0; i < teamDefCount-1; i++)
            {
                int teamOff = br.ReadInt32();
                var bk = br.BaseStream.Position;
                br.BaseStream.Position = teamOff;
                var team = new TeamDef(br);
                br.BaseStream.Position = bk;
                Teams[i] = team;
            }

            br.BaseStream.Position = statsOff;
            Stats = new List<TeamPlayerParam>();
            for (int i = 0; i < statsCount; i++)
            {
                var stat = new TeamPlayerParam(br);
                Stats.Add(stat);
            }

            br.BaseStream.Position = kizunaOff;
            KizunaData = br.ReadBytes(kizunaCount * 0x10);
        }

        public void Write(BeBinaryWriter bw)
        {
            var pointersFixList = new List<int>();
            bw.Write(3); // sect count
            bw.Write(0); // pointers fix offset
            bw.Write(0x24); // start of data
            bw.Write(0); // section 1
            bw.Write(Teams.Length + 1); // section 1
            bw.Write(0x24); // section 2 (stats, fixed)
            bw.Write(Stats.Count); // section 2
            bw.Write(0); // section 3
            bw.Write(KizunaData.Length / 0x10);

            // stats section
            foreach (var stats in Stats) stats.Write(bw);

            // update offset of next section
            int kizunaSectOffs = (int)bw.BaseStream.Position;
            bw.BaseStream.Position = 0x1C;
            bw.Write(kizunaSectOffs);
            bw.BaseStream.Position = kizunaSectOffs;
            bw.Write(KizunaData);

            // team def section
            var teamDefOffsets = new List<int>();
            foreach (var teamDef in Teams)
            {
                var offset = teamDef.Write(bw);
                teamDefOffsets.Add(offset);
                pointersFixList.Add(offset);
                pointersFixList.Add(offset + 0x10);
                pointersFixList.Add(offset + 0x14);
            }
            int teamDefSectOffs = (int)bw.BaseStream.Position;
            foreach (var offset in teamDefOffsets)
            {
                pointersFixList.Add((int)bw.BaseStream.Position);
                bw.Write(offset);
            }
            bw.Write(0);
            
            var fixListOff = (int)bw.BaseStream.Position;
            bw.Write(pointersFixList.Count);
            foreach (var pointer in pointersFixList) bw.Write(pointer);

            bw.BaseStream.Position = 4;
            bw.Write(fixListOff);
            bw.BaseStream.Position += 4;
            bw.Write(teamDefSectOffs);
        }
    }
    
    class TeamDef
    {
        public List<TeamPlayer> Players;
        public byte[] UnkData;

        public string Name;
        public int TeamIndex;
        public short Formation;
        public short Coach;
        public short Manager;
        public short Strength;

        public TeamDef(BeBinaryReader br)
        {
            var startOfDef = br.BaseStream.Position;
            var nameOffset = br.ReadInt32();
            TeamIndex = br.ReadInt32();
            Formation = br.ReadInt16();
            Coach = br.ReadInt16();
            Manager = br.ReadInt16();
            Strength = br.ReadInt16();

            var playersOff = br.ReadInt32();
            var metadataOff = br.ReadInt32();

            br.BaseStream.Position = nameOffset;
            Name = br.ReadCString();
            br.BaseStream.Position = metadataOff;
            int unkLength = (int)startOfDef - metadataOff;
            UnkData = br.ReadBytes(unkLength);
            br.BaseStream.Position = playersOff;

            Players = new List<TeamPlayer>();
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                var player = new TeamPlayer(br);
                Players.Add(player);
                if (player.PlayerId == 0)
                    break;
            }
        }

        public int Write(BeBinaryWriter bw)
        {
            int firstPlayerOffset = (int)bw.BaseStream.Position;
            foreach (var player in Players) player.Write(bw);
            int metadataOffset = (int)bw.BaseStream.Position;
            bw.Write(UnkData);

            int teamDefOffset = (int)bw.BaseStream.Position;
            bw.Write(0); // placeholder
            bw.Write(0);
            bw.Write(Formation);
            bw.Write(Coach);
            bw.Write(Manager);
            bw.Write(Strength);
            bw.Write(firstPlayerOffset);
            bw.Write(metadataOffset);
            int textOffset = (int)bw.BaseStream.Position;
            bw.WriteCString(Name);
            bw.WriteAlignment(4);
            var backup = (int)bw.BaseStream.Position;
            bw.BaseStream.Position = teamDefOffset;
            bw.Write(textOffset);
            bw.BaseStream.Position = backup;

            return teamDefOffset;
        }
    }

    class TeamPlayerParam
    {
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
        public byte[] _unkF;

        public TeamPlayerParam(BeBinaryReader br)
        {
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
            _unkF = br.ReadBytes(6);
        }

        public void Write(BeBinaryWriter bw)
        {
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
            bw.Write(_unkF);
        }
    }
    class TeamPlayer
    {
        // TEAM_PLAYER 
        public short PlayerId;
        public short KitNumber;
        public int FormationIndex;
        public int StatsIndex;
        public int Kakusei;
        public int Flag;
        public int MainPortrait; // 0x14
        public int LeftPortrait;
        public int RightPortrait;
        public MoveList Moves;

        public TeamPlayer(BeBinaryReader br)
        {
            PlayerId = br.ReadInt16();
            KitNumber = br.ReadInt16();
            FormationIndex = br.ReadInt32();
            StatsIndex = br.ReadInt32();
            Kakusei = br.ReadInt32();
            Flag = br.ReadInt32();
            MainPortrait = br.ReadInt32();
            LeftPortrait = br.ReadInt32();
            RightPortrait = br.ReadInt32();
            Moves = new MoveList(br);
            br.BaseStream.Position += 2;
        }
        public void Write(BeBinaryWriter bw)
        {
            bw.Write(PlayerId);
            bw.Write(KitNumber);
            bw.Write(FormationIndex);
            bw.Write(StatsIndex);
            bw.Write(Kakusei);
            bw.Write(Flag);
            bw.Write(MainPortrait);
            bw.Write(LeftPortrait);
            bw.Write(RightPortrait);
            Moves.Write(bw);
            bw.Write((short)0);
        }

        public TeamPlayer(TeamPlayer copy)
        {
            PlayerId = copy.PlayerId;
            KitNumber = copy.KitNumber;
            FormationIndex = copy.FormationIndex;
            StatsIndex = copy.StatsIndex;
            Kakusei = copy.Kakusei;
            MainPortrait = copy.MainPortrait;
            LeftPortrait = copy.LeftPortrait;
            RightPortrait = copy.RightPortrait;
            Moves = copy.Moves;
        }

        
    }
}
