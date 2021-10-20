using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    class Guild
    {
        public List<Player> roster { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            if (roster.Count < Capacity)
            {
                roster.Add(player);
            }            
        }

        public bool RemovePlayer(string name)
        {
            if (roster.Any(x => x.Name == name))
            {
                roster.Remove(roster.FirstOrDefault(x => x.Name == name));
                return true;
            }

            return false;
        }

        public void PromotePlayer(string name)
        {
            if (roster.Any(x => x.Name == name))
            {
                var player = roster.Find(x => x.Name == name);
                if (player.Rank != "Member")
                {
                    player.Rank = "Member";
                }
            }
        }

        public void DemotePlayer(string name)
        {
            if (roster.Any(x => x.Name == name))
            {
                var player = roster.Find(x => x.Name == name);
                if (player.Rank != "Trial")
                {
                    player.Rank = "Trial";
                }
            }
        }

        public Player[] KickPlayersByClass(string @class)
        {
            Player[] targetPlayers = roster.Where(x => x.Class == @class).ToArray();

            foreach (var target in targetPlayers)
            {
                roster.Remove(target);
            }

            return targetPlayers;
        }

        public int Count => roster.Count;

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");
            foreach (var player in roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
