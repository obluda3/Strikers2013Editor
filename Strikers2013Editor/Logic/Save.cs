using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Strikers2013Editor.IO;
using System.IO;

namespace Strikers2013Editor.Logic
{
    class Save
    {
        Encoding sjis = Encoding.GetEncoding("sjis");
        public string filename;

        public Team Team = new Team();
        public Player[] Players = new Player[412];

        public string ProfileName, OnlineName;
        public uint Profile, OnlineProfile, BaseOffset, MinutesPlayed, HoursPlayed, InazumaPoints, CreationDate, CreationTime;

        private const int STATS_OFFSET = 0xad64;
        private const int WAZA_OFFSET = 0x6409c;
        private const int TEAM_OFFSET = 0x63F4c;
        private const int PROFILE_OFFSET = 0x67752;
        private const int ONLINE_PROFILE = 0x1d8;
        private const int PROFILENAME_OFFSET = 0x1f8;
        private const int TEAM_EMBLEM_OFFSET = 0x67758;
        private const int INAZUMA_POINT_OFFSET = 0x1d4;

        public Save(string name, int slot)
        {
            filename = name;
            BaseOffset = (uint)(0x2590 + slot * 0x68548);
        }

        public void ParseSaveFile()
        {
            var file = File.OpenRead(filename);
            using (var br = new BeBinaryReader(File.OpenRead(filename)))
            {
                br.BaseStream.Position = ONLINE_PROFILE;
                OnlineName = sjis.GetString(br.ReadBytes(16));
                OnlineProfile = br.ReadUInt32();

                br.BaseStream.Position = BaseOffset;
                CreationDate = br.ReadUInt32();
                CreationTime = br.ReadUInt32();
                HoursPlayed = br.ReadUInt32();
                MinutesPlayed = br.ReadUInt32();

                br.BaseStream.Position = BaseOffset + INAZUMA_POINT_OFFSET;
                InazumaPoints = br.ReadUInt32();

                br.BaseStream.Position = BaseOffset + PROFILENAME_OFFSET;
                ProfileName = sjis.GetString(br.ReadBytes(16));


                for (var i = 0; i < 412; i++)
                {
                    // Stats
                    var player = new Player();
                    br.BaseStream.Position = BaseOffset + STATS_OFFSET + i * 0x3c;
                    player.Stats = new Stats(br);

                    // Moves
                    br.BaseStream.Position = BaseOffset + WAZA_OFFSET + i * 0x22;
                    player.MoveList = new MoveList(br);

                    Players[i] = player;
                }
                br.BaseStream.Position = BaseOffset + TEAM_OFFSET;
                Team = new Team(br);

                br.BaseStream.Position = BaseOffset + PROFILENAME_OFFSET + 18;
                Team.Name = sjis.GetString(br.ReadBytes(16));

                br.BaseStream.Position = BaseOffset + TEAM_EMBLEM_OFFSET;
                Team.Emblem = br.ReadInt16();

                br.BaseStream.Position = BaseOffset + PROFILE_OFFSET;
                Profile = br.ReadUInt32();
            }
        }

        public void ApplyEdits(string filePath)
        {
            var saveData = File.ReadAllBytes(filename);
            var file = File.Open(filePath, FileMode.Create);

            using (var bw = new BeBinaryWriter(file))
            {
                bw.Write(saveData);
                bw.BaseStream.Position = 0x1d8;
                bw.Write(StringTo16LongArray(OnlineName));
                bw.Write(OnlineProfile);

                bw.BaseStream.Position = BaseOffset;
                bw.Write(CreationDate);
                bw.Write(CreationTime);
                bw.Write(HoursPlayed);
                bw.Write(MinutesPlayed);

                bw.BaseStream.Position = BaseOffset + 0x1d4;
                bw.Write(InazumaPoints);

                bw.BaseStream.Position = BaseOffset + PROFILENAME_OFFSET;
                bw.Write(StringTo16LongArray(ProfileName));

                for (var i = 0; i < 412; i++)
                {
                    var player = Players[i];
                    // STATS
                    bw.BaseStream.Position = BaseOffset + STATS_OFFSET + i * 0x3c;
                    player.Stats.Write(bw);

                    // WAZA
                    bw.BaseStream.Position = BaseOffset + WAZA_OFFSET + i * 0x22;
                    player.MoveList.Write(bw);
                }
                bw.BaseStream.Position = BaseOffset + TEAM_OFFSET;
                Team.Write(bw);

                bw.BaseStream.Position = BaseOffset + PROFILENAME_OFFSET + 18;
                bw.Write(StringTo16LongArray(Team.Name));

                bw.BaseStream.Position = BaseOffset + TEAM_EMBLEM_OFFSET;
                bw.Write(Team.Emblem);

                bw.BaseStream.Position = BaseOffset + PROFILE_OFFSET;
                bw.Write(Profile);

            }

        }
        private byte[] StringTo16LongArray(string text)
        {
            byte[] buffer = new byte[16];
            for (var i = 0; i < 16; i++)
                buffer[i] = 0;
            var textBuffer = sjis.GetBytes(text);
            for (var i = 0; i < 16; i++)
            {
                if (i == textBuffer.Length)
                    break;
                buffer[i] = textBuffer[i];
            }
            return buffer;
        }
    }
}
