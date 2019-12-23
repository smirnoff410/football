using FootBall.Domains.Entities;
using FootBall.Domains.Repository.Base;

namespace FootBall.Infrastructure.Repositories.IRepositories
{
    public interface IPlayerRepository : IRepository<Player>
    {
        Player GetPlayerByVkId(int id);
    }
}