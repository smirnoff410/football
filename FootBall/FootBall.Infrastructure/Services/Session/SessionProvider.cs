using NHibernate;

namespace FootBall.Infrastructure.Services.Session
{
    public class SessionProvider : ISessionProvider
    {
        private readonly ISessionFactory _sessionFactory;

        public SessionProvider(WebSessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory.Init();
        }
        public void OpenSession()
        {
            Session = _sessionFactory.OpenSession();
        }

        public ISession Session { get; private set; }

        public void CloseSession()
        {
            Session.Close();
        }
    }
}