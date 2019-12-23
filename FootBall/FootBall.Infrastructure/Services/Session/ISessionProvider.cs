using NHibernate;

namespace FootBall.Infrastructure.Services.Session
{
    public interface ISessionProvider
    {
        void OpenSession();
        ISession Session { get; }
        void CloseSession();
    }
}