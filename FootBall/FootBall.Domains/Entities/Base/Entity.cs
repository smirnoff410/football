using System;

namespace FootBall.Domains.Entities.Base
{
    public class Entity
    {
        public virtual Guid Id { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual DateTime Timestamp { get; set; }
    }
}