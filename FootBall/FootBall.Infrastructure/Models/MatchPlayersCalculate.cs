using System.Collections.Generic;
using System.Linq;
using FootBall.Contacts.Dto.Match;
using FootBall.Domains.Entities;

namespace FootBall.Infrastructure.Models
{
    public class MatchPlayersCalculate : IMatchPlayersCalculate
    {
        public StopMatchResponseDto GetTeam(ICollection<Player> players, int playersCount)
        {
            var team = new StopMatchResponseDto
            {
                MainPlayers = new List<string>(),
                StockPlayers = new List<string>()
            };
            var maxPriority = players.Max(c => c.Priority);
            while (maxPriority != 0 && playersCount != 0)
            {
                var priority = maxPriority;
                var maxPlayersPriority = players.Where(c => c.Priority == priority).ToList();

                if (maxPlayersPriority.Count > 10)
                {
                    maxPlayersPriority.RemoveRange(10, maxPlayersPriority.Count - 10);
                }

                var playersName = maxPlayersPriority.Select(c => c.Name).ToList();

                playersCount -= playersName.Count;

                foreach (var player in maxPlayersPriority)
                {
                    players.Remove(player);
                }
                team.MainPlayers.AddRange(playersName);

                maxPriority--;
            }
            if (playersCount >= 0)
                team.StockPlayers.AddRange(players.Select(c => c.Name));

            return team;
        }
    }
}