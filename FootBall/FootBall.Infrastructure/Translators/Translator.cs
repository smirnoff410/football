using System;
using AutoMapper;

namespace FootBall.Infrastructure.Translators
{
    public class Translator<TSource, TDestination> : ITranslator<TSource, TDestination>
    {
        private readonly Lazy<IMapper> _mapper;
        protected IMapper Mapper => _mapper.Value;
        protected IMappingExpression<TSource, TDestination> Mapping;

        public Translator(Lazy<IMapper> mapper, IProfileExpression expression)
        {
            _mapper = mapper;
            Mapping = expression.CreateMap<TSource, TDestination>();
        }

        public virtual void Configure()
        {
        }

        public object Translate(object source)
        {
            return Translate((TSource)source);
        }

        public void Update(object source, object destination)
        {
            Mapper.Map((TSource)source, (TDestination)destination);
        }

        public TDestination Translate(TSource source)
        {
            return Mapper.Map<TDestination>(source);
        }

        public void Update(TSource source, TDestination destination)
        {
            Mapper.Map(source, destination);
        }
    }
}