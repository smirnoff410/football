using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using AutoMapper;
using FootBall.Contacts.Dto.Player;
using FootBall.Domains.Entities;
using FootBall.Infrastructure.Translators.ObjectTranslator.ModelToDto;

namespace FootBall.Infrastructure.Translators
{
    public class TranslatorFactory : ITranslatorFactory
    {
        protected IMapper Mapper;

        protected MapperConfiguration MapperConfiguration;

        private readonly List<TranslatorData> _translators;

        public TranslatorFactory(IComponentContext componentContext)
        {
            _translators = new List<TranslatorData>();
        }

        public void Initialize()
        {
            MapperConfiguration = new MapperConfiguration(Configure);
            Mapper = MapperConfiguration.CreateMapper();
        }

        public void Configure(IProfileExpression configurationExpression)
        {
            AddTranslator<Player, PlayerDto, PlayerToPlayerDtoTranslator>(configurationExpression);
        }

        public void AddTranslator<TSource, TDestination, TTranslatorType>(IProfileExpression expression) where TTranslatorType : class, ITranslator<TSource, TDestination>
        {
            var translator = new Translator<TSource, TDestination>(new Lazy<IMapper>(() => Mapper), expression);
            translator.Configure();
            _translators.Add(new TranslatorData
            {
                Destination = typeof(TDestination),
                Source = typeof(TSource),
                Translator = translator
            });
        }

        public ITranslator<TSource, TDestination> GetTranslator<TSource, TDestination>()
        {
            return (ITranslator<TSource, TDestination>)_translators.FirstOrDefault(c =>
                    c.Destination == typeof(TDestination) &&
                    c.Source == typeof(TSource))
                ?.Translator;
        }
    }
}