using FootBall.Domains.Entities;
using FootBall.Infrastructure.Mappings.Base;

namespace FootBall.Infrastructure.Mappings
{
    public class MatchMapping : EntityMapping<Match>
    {
        public MatchMapping()
        {
            Property(c => c.Number);
            Property(c => c.PlayersCount);
            Bag(c => c.Players, k =>
            {

            },
                m => m.ManyToMany());
        }
    }
}