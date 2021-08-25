using NHibernate;
using YoutubeClone.DataAccessLayer;
using YoutubeClone.Foundation.Repositories;

namespace YoutubeClone.Foundation.UnitOfWorks
{
    public class ChannelUnitOfWork : UnitOfWork, IChannelUnitOfWork
    {
        public IChannelRepository ChannelRepository { get; set; }
        public IVideoRepository VideoRepository { get; set; }
        public ISubscriberRepository SubscriberRepository { get; set; }
        public IViewRepository ViewRepository { get; set; }
        public ILikeRepository LikeRepository { get; set; }
        public IDislikeRepository DislikeRepository { get; set; }
        public ICommentRepository CommentRepository { get; set; }
        public ICommentLikeRepository CommentLikeRepository { get; set; }
        public ChannelUnitOfWork(IChannelRepository channelRepository,
            IVideoRepository videoRepository,
            ISubscriberRepository subscriberRepository,
            IViewRepository viewRepository,
            ILikeRepository likeRepository,
            IDislikeRepository dislikeRepository,
            ICommentRepository commentRepository,
            ICommentLikeRepository commentLikeRepository,
            ISession session)
            : base(session)
        {
            ChannelRepository = channelRepository;
            VideoRepository = videoRepository;
            SubscriberRepository = subscriberRepository;
            ViewRepository = viewRepository;
            LikeRepository = likeRepository;
            DislikeRepository = dislikeRepository;
            CommentRepository = commentRepository;
            CommentLikeRepository = commentLikeRepository;
        }
    }
}
