using System.Collections.Generic;
using FootBall.Contacts.Dto.Match;
using FootBall.Domains.Entities;

namespace FootBall.Infrastructure.Models
{
    public interface IMatchPlayersCalculate
    {
        StopMatchResponseDto GetTeam(ICollection<Player> players, int playersCount);
    }
}