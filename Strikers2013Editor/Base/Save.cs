using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Strikers2013Editor.IO;
using System.IO;

namespace Strikers2013Editor.Base
{
    class Save
    {
        Encoding sjis = Encoding.GetEncoding("sjis");
        public string filename;

        public short[] team = new short[16];
        public Player[] players = new Player[412];

        public string profileName, onlineName;
        public string[] playerNames, wazaNames;
        public uint profile, onlineProfile, baseOffset, minutesPlayed, hoursPlayed, inazumaPoints, creationDate, creationTime;
        public int slot;

        private const int STATS_OFFSET = 0xad74;
        private const int WAZA_OFFSET = 0x640a4;
        private const int TEAM_OFFSET = 0x63f66;
        private const int PROFILE_OFFSET = 0x6775a;
        private const int ONLINE_PROFILE = 0x1d8;
        private const int PROFILENAME_OFFSET = 0x1f8;

        public Save(string name)
        {
            filename = name;
        }

        public void ParseSaveFile()
        {
            using (var br = new BeBinaryReader(File.OpenRead(filename)))
            {
                br.BaseStream.Position = ONLINE_PROFILE;
                onlineName = sjis.GetString(br.ReadBytes(16));
                onlineProfile = br.ReadUInt32();

                br.BaseStream.Position = baseOffset;

                creationDate = br.ReadUInt32();
                creationTime = br.ReadUInt32();
                hoursPlayed = br.ReadUInt32();
                minutesPlayed = br.ReadUInt32();



                br.BaseStream.Position = baseOffset + 0x1d4;
                inazumaPoints = br.ReadUInt32();

                br.BaseStream.Position = baseOffset + PROFILENAME_OFFSET;
                profileName = sjis.GetString(br.ReadBytes(16));

                for (var i = 0; i < 412; i++)
                {
                    // STATS
                    var player = new Player();
                    br.BaseStream.Position = baseOffset + STATS_OFFSET + i * 0x3c;
                    player.stats = br.ReadBytes(0x3c);

                    // WAZA
                    br.BaseStream.Position = baseOffset + WAZA_OFFSET + i * 0x22;
                    player.waza = br.ReadMultipleShort(17).ToArray();

                    players[i] = player;
                }
                for (var i = 0; i < 16; i++)
                {
                    br.BaseStream.Position = baseOffset + TEAM_OFFSET + 0x14 * i;
                    team[i] = br.ReadInt16();
                }
                br.BaseStream.Position = baseOffset + PROFILE_OFFSET;
                profile = br.ReadUInt32();
            }
        }

        public void ApplyEdits(Stream output)
        {
            var saveData = File.ReadAllBytes(filename);

            using (var bw = new BeBinaryWriter(output))
            {
                bw.Write(saveData);
                bw.BaseStream.Position = 0x1d8;
                bw.Write(StringTo16LongArray(onlineName));
                bw.Write(onlineProfile);

                bw.BaseStream.Position = baseOffset;
                bw.Write(creationDate);
                bw.Write(creationTime);
                bw.Write(hoursPlayed);
                bw.Write(minutesPlayed);

                bw.BaseStream.Position = baseOffset + 0x1d4;
                bw.Write(inazumaPoints);

                bw.BaseStream.Position = baseOffset + PROFILENAME_OFFSET;
                bw.Write(StringTo16LongArray(profileName));

                for (var i = 0; i < 412; i++)
                {
                    var player = players[i];
                    // STATS
                    bw.BaseStream.Position = baseOffset + STATS_OFFSET + i * 0x3c;
                    bw.Write(player.stats);

                    // WAZA
                    bw.BaseStream.Position = baseOffset + WAZA_OFFSET + i * 0x22;
                    foreach (var waza in player.waza)
                        bw.Write(waza);

                }
                for (var i = 0; i < 16; i++)
                {
                    bw.BaseStream.Position = baseOffset + TEAM_OFFSET + 0x14 * i;
                    bw.Write(team[i]);
                }
                bw.BaseStream.Position = baseOffset + PROFILE_OFFSET;
                bw.Write(profile);

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
