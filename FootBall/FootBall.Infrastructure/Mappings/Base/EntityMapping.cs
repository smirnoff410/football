using FootBall.Domains.Entities.Base;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace FootBall.Infrastructure.Mappings.Base
{
    public class EntityMapping<T> : ClassMapping<T> where T : Entity
    {
        public EntityMapping()
        {
            Id(x => x.Id, mapper => mapper.Generator(new GuidGeneratorDef()));
            Property(x => x.IsDeleted);
            Property(x => x.Timestamp);
        }
    }
}