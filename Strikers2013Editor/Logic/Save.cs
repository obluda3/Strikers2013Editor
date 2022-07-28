using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.Text;
using Strikers2013Editor.IO;
using System.IO;

namespace Strikers2013Editor.Logic
{
    class Save
    {
        Encoding sjis = Encoding.GetEncoding("sjis");
        public string filename;

        public Team Team;
        public Player[] Players = new Player[412];

        public string ProfileName, OnlineName;
        public uint Profile, OnlineProfile, BaseOffset, MinutesPlayed, HoursPlayed, InazumaPoints, CreationDate, CreationTime;

        private const int STATS_OFFSET = 0xad74;
        private const int WAZA_OFFSET = 0x640ac;
        private const int TEAM_OFFSET = 0x63F5c;
        private const int PROFILE_OFFSET = 0x67762;
        private const int ONLINE_PROFILE = 0x1d8;
        private const int PROFILENAME_OFFSET = 0x200;
        private const int TEAM_EMBLEM_OFFSET = 0x67768;
        private const int INAZUMA_POINT_OFFSET = 0x1DC;

        public byte[] StringTo16LongArray(string text)
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

        public Save(string name, int slot)
        {
            filename = name;
            BaseOffset = (uint)(0x2590 + slot * 0x68548);
            var file = File.OpenRead(filename);
            using (var br = new BeBinaryReader(file))
            {
                br.BaseStream.Position = ONLINE_PROFILE;
                OnlineName = sjis.GetString(br.ReadBytes(16));
                OnlineProfile = br.ReadUInt32();

                br.BaseStream.Position = BaseOffset + 8;
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
                    player.Stats = new SavePlayerParam(br);

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
                bw.BaseStream.Position = ONLINE_PROFILE;
                bw.Write(StringTo16LongArray(OnlineName));
                bw.Write(OnlineProfile);

                bw.BaseStream.Position = BaseOffset + 8;
                bw.Write(CreationDate);
                bw.Write(CreationTime);
                bw.Write(HoursPlayed);
                bw.Write(MinutesPlayed);

                bw.BaseStream.Position = BaseOffset + INAZUMA_POINT_OFFSET;
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
    }
}
