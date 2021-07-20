﻿using Autofac;
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

            base.Load(builder);
        }
    }
}
