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
    }
    
    class TeamDef
    {
        public List<TeamPlayer> Players;
        public byte[] UnkData;

        public string Name;
        public int TeamIndex;
        public int Formation;
        public short Coach;
        public short Manager;
        public short Strength;

        public short _UnkA;
        public short _UnkB;
        public int _UnkC;

        public TeamDef(BeBinaryReader br)
        {
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
            _UnkA = br.ReadInt16();
            _UnkB = br.ReadInt16();
            _UnkC = br.ReadInt32();
            br.BaseStream.Position = playersOff;

            Players = new List<TeamPlayer>();
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                var player = new TeamPlayer(br);
                if (player.PlayerId == 0)
                    break;
                Players.Add(player);
            }
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
    }
    class TeamPlayer
    {
        // TEAM_PLAYER 
        public short PlayerId;
        private byte[] _unk02;
        public int MainPortrait; // 0x14
        public int LeftPortrait;
        public int RightPortrait;
        public MoveList Moves;

        public TeamPlayer(BeBinaryReader br)
        {
            PlayerId = br.ReadInt16();
            _unk02 = br.ReadBytes(0x12);
            MainPortrait = br.ReadInt32();
            LeftPortrait = br.ReadInt32();
            RightPortrait = br.ReadInt32();
            Moves = new MoveList(br);
            br.BaseStream.Position += 2;
        }
    }
}
