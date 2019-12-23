using System;
using FootBall.Domains.Entities.Base;

namespace FootBall.Infrastructure.Extensions
{
    public static class EntityExtension
    {
        public static Entity MarkAsNew(this Entity entity)
        {
            entity.IsDeleted = false;
            entity.Timestamp = DateTime.Now;
            return entity;
        }

        public static Entity MarkAsModified(this Entity entity)
        {
            entity.Timestamp = DateTime.Now;
            return entity;
        }

        public static Entity MarkAsDeleted(this Entity entity)
        {
            entity.IsDeleted = true;
            entity.Timestamp = DateTime.Now;
            return entity;
        }
    }
}