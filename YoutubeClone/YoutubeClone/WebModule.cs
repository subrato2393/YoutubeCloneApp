using Autofac;
using YoutubeClone.Areas.Admin.Models;
using YoutubeClone.Foundation.Services;
using YoutubeClone.Models;

namespace YoutubeClone
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ChannelService>().As<IChannelService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ChannelModel>().AsSelf();

            builder.RegisterType<RegisterModel>().AsSelf();

            builder.RegisterType<VideoViewModel>().AsSelf();

            builder.RegisterType<SubscribeModel>().AsSelf();
            
            builder.RegisterType<VideoListModel>().AsSelf();

            base.Load(builder);
        }
    }
}
