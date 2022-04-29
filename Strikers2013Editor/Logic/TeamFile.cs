using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Strikers2013Editor.IO;

namespace Strikers2013Editor.Logic
{
    static class TeamFile
    {
        public static void Load(BeBinaryReader br, Save save)
        {
            save.Team = new Team(br);
            save.Team.Emblem = br.ReadInt16();
            save.Team.Name = br.ReadString();
            for (int i = 0; i < 16; i++)
            {
                var player = new Player();
                player.MoveList = new MoveList(br);
                player.Stats = new Stats(br);
                var teamPlayer = save.Team.Players[i];
                var id = teamPlayer.Id;
                save.Players[id] = player;
            }
        }

        public static void Save(BeBinaryWriter bw, Save save)
        {
            save.Team.Write(bw);
            bw.Write(save.Team.Emblem);
            bw.Write(save.Team.Name);
            for (int i = 0; i < 16; i++)
            {
                var teamPlayer = save.Team.Players[i];
                var id = teamPlayer.Id;
                var player = save.Players[id];
                player.MoveList.Write(bw);
                player.Stats.Write(bw);
            }
        }
    }
}
