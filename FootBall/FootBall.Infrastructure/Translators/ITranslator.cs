namespace FootBall.Infrastructure.Translators
{
    public interface ITranslator<in TSource, TDestination> : ITranslator
    {
        TDestination Translate(TSource source);
        void Update(TSource source, TDestination destination);
    }

    public interface ITranslator
    {
        void Configure();
        object Translate(object source);
        void Update(object source, object destination);
    }
}