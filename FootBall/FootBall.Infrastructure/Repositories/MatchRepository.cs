using FootBall.Domains.Entities;
using FootBall.Infrastructure.Repositories.Base;
using FootBall.Infrastructure.Repositories.IRepositories;
using FootBall.Infrastructure.Services.Session;

namespace FootBall.Infrastructure.Repositories
{
    public class MatchRepository : RepositoryBase<Match>, IMatchRepository
    {
        public MatchRepository(ISessionProvider sessionProvider) : base(sessionProvider)
        {
        }
    }
}