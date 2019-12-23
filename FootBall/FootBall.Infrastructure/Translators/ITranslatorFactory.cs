using AutoMapper;

namespace FootBall.Infrastructure.Translators
{
    public interface ITranslatorFactory
    {
        void Initialize();
        void AddTranslator<TSource, TDestination, TTranslatorType>(IProfileExpression expression) where TTranslatorType : class, ITranslator<TSource, TDestination>;
        ITranslator<TSource, TDestination> GetTranslator<TSource, TDestination>();
    }
}