using Autofac;
using NHibernate;
using YoutubeClone.Foundation.Database.Contexts;
using YoutubeClone.Foundation.Repositories;
using YoutubeClone.Foundation.Services;
using YoutubeClone.Foundation.UnitOfWorks;

namespace YoutubeClone.Foundation
{
    public class FoundationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ChannelService>().As<IChannelService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ChannelRepository>().As<IChannelRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ChannelUnitOfWork>().As<IChannelUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.Register(c => MemberContext.OpenSession()).As<ISession>()
                .InstancePerLifetimeScope();
          

            base.Load(builder);
        }
    }
}
