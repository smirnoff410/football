using System.Linq;
using FootBall.Domains.Entities.Base;
using FootBall.Domains.Repository.Base;
using FootBall.Infrastructure.Services.Session;
using NHibernate;

namespace FootBall.Infrastructure.Repositories.Base
{
    public class RepositoryBase<T> : IRepository<T> where T : Entity
    {
        private readonly ISessionProvider _sessionProvider;
        protected ISession Session => _sessionProvider.Session;
        public RepositoryBase(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        public void Delete(T entity)
        {
            Session.Clear();
            Session.Delete(entity);
            Session.Flush();
        }

        public T GetById(int id)
        {
            return Session.Get<T>(id);
        }

        public IQueryable<T> List()
        {
            return Session.Query<T>();
        }

        public void Save(T entity)
        {
            Session.Clear();
            Session.SaveOrUpdate(entity);
            Session.Flush();
        }
    }
}