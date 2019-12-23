using Autofac;
using FootBall.Infrastructure.Config;

namespace FootBall.Web.Config
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConnectionString>().As<IConnectionString>().SingleInstance();
        }
    }
}