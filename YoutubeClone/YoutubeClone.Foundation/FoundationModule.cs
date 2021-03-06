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

            builder.RegisterType<VideoRepository>().As<IVideoRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<FeedbackService>().As<IFeedbackService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SubscriberRepository>().As<ISubscriberRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ViewRepository>().As<IViewRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<LikeRepository>().As<ILikeRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DislikeRepository>().As<IDislikeRepository>()
                .InstancePerLifetimeScope();
           
            builder.RegisterType<CommentRepository>().As<ICommentRepository>()
                .InstancePerLifetimeScope();
           
            builder.RegisterType<CommentLikeRepository>().As<ICommentLikeRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CommentsReplyRepository>().As<ICommentReplyRepository>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
