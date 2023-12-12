using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Basketball
{
    public class Team
    {
        List<Player> players;
        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            players = new List<Player>();
        }

        public string Name { get; private set; }
        public int OpenPositions { get; private set; }
        public char Group { get; private set; }
        public IReadOnlyCollection<Player> Players => this.players;

        public int Count => this.Players.Count;
        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";
            }
            else if (OpenPositions == 0)
            {
                return "There are no more open positions.";
            }
            else if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }
            else
            {
                players.Add(player);
                OpenPositions--;
                return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";

            }

        }
        public bool RemovePlayer(string name)
        {
            var targetPlayer = this.Players.FirstOrDefault(x => x.Name == name);
            if (targetPlayer == null)
            {
                return false;
            }
            this.OpenPositions++;
            this.players.Remove(targetPlayer);
            return true;
        }
        public int RemovePlayerByPosition(string position)
        {
            int count = 0;
            while (Players.FirstOrDefault(x => x.Position == position) != null)
            {
                var targetPlayer = Players.FirstOrDefault(x => x.Position == position);
                players.Remove(targetPlayer);
                count++;
                OpenPositions++;
            }
            return count;
        }
        public Player RetirePlayer(string name)
        {
            var targetPlayer = this.Players.FirstOrDefault(x => x.Name == name);
            if (targetPlayer == null)
            {
                return null;
            }
            targetPlayer.Retired = true;
            return targetPlayer;
        }
        public List<Player> AwardPlayers(int games)
        {
            List<Player> list = new List<Player>();
            foreach (Player player in players.Where(x => x.Games >= games))
            {
                list.Add(player);
            }
            return list;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Active players competing for Team {Name} from Group {Group}:");
            foreach (Player player in players)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString();
        }
    }
}
