using FootBall.Domains.Entities;
using FootBall.Infrastructure.Mappings.Base;

namespace FootBall.Infrastructure.Mappings
{
    public class PlayerMapping : EntityMapping<Player>
    {
        public PlayerMapping()
        {
            Property(c => c.VkId);
            Property(c => c.Name);
            Property(c => c.Priority);
            Property(c => c.Status);
            Bag(c => c.Matches, k =>
            {

            },
                m => m.ManyToMany());
        }
    }
}