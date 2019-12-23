using System.Linq;
using FootBall.Domains.Entities;
using FootBall.Infrastructure.Repositories.Base;
using FootBall.Infrastructure.Repositories.IRepositories;
using FootBall.Infrastructure.Services.Session;

namespace FootBall.Infrastructure.Repositories
{
    public class PlayerRepository : RepositoryBase<Player>, IPlayerRepository
    {
        public PlayerRepository(ISessionProvider sessionProvider) : base(sessionProvider)
        {
        }

        public Player GetPlayerByVkId(int id)
        {
            return Session.Query<Player>().First(c => c.VkId == id);
        }
    }
}