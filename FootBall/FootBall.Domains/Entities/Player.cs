using System.Collections.Generic;
using FootBall.Domains.Entities.Base;
using FootBall.Domains.Enums;

namespace FootBall.Domains.Entities
{
    public class Player : Entity
    {
        public virtual int VkId { get; set; }
        public virtual string Name { get; set; }
        public virtual int Priority { get; set; }
        public virtual EPlayerStatus Status { get; set; }
        public virtual ICollection<Match> Matches { get; set; }

        public Player()
        {
            Status = new EPlayerStatus();
        }
    }
}