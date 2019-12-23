using System.Collections.Generic;

namespace FootBall.Contacts.Dto.Match
{
    public class StopMatchResponseDto
    {
        public IEnumerable<string> MainPlayers { get; set; }
        public IEnumerable<string> StockPlayers { get; set; }
    }
}