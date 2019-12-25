using System.Collections.Generic;
using FootBall.Domains.Entities.Base;

namespace FootBall.Domains.Entities
{
    public class Match : Entity
    {
        public virtual ICollection<Player> Players { get; set; }
        public virtual int PlayersCount { get; set; }
    }
}