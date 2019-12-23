using FootBall.Infrastructure.Config;
using FootBall.Infrastructure.Mappings;
using Microsoft.Extensions.Logging;
using NHibernate;
using NHibernate.Context;

namespace FootBall.Infrastructure.Services.Session
{
    public class WebSessionFactory
    {
        private readonly IConnectionString _connectionString;
        private readonly ILogger<WebSessionContext> _logger;
        private ISessionFactory _sessionFactory;


        public WebSessionFactory(IConnectionString connectionString, ILogger<WebSessionContext> logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }

        public ISessionFactory Init()
        {
            var types = typeof(MatchMapping).Assembly.GetTypes();

            _sessionFactory = SessionFactory<WebSessionContext>.CreateSessionFactory(_connectionString.ConnectionName, types, _logger);

            return _sessionFactory;
        }
    }
}