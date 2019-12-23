using System;
using System.Linq;
using FootBall.Domains.Entities.Base;

namespace FootBall.Domains.Repository.Base
{
    public interface IRepository<T> where T : Entity
    {
        void Delete(T entity);
        T GetById(Guid id);
        IQueryable<T> List();
        void Save(T entity);
    }
}