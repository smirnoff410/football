using Autofac;
using FootBall.Domains.Entities;
using FootBall.Domains.Repository.Base;
using FootBall.Infrastructure.Repositories;
using FootBall.Infrastructure.Repositories.IRepositories;
using FootBall.Infrastructure.Services.Session;
using FootBall.Infrastructure.Translators;

namespace FootBall.Infrastructure.Config
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MatchRepository>().As<IMatchRepository>().SingleInstance();
            builder.Register(c => c.Resolve<IMatchRepository>()).As<IRepository<Match>>().SingleInstance();

            builder.RegisterType<PlayerRepository>().As<IPlayerRepository>().SingleInstance();
            builder.Register(c => c.Resolve<IPlayerRepository>()).As<IRepository<Player>>().SingleInstance();


            builder.RegisterType<TranslatorFactory>().As<ITranslatorFactory>().SingleInstance()
                .OnActivating(c => c.Instance.Initialize());

            builder.RegisterType<WebSessionFactory>().AsSelf().SingleInstance();


            builder.RegisterType<SessionProvider>().As<ISessionProvider>().SingleInstance();
        }
    }
}