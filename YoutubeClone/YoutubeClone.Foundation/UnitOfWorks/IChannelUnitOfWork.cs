using YoutubeClone.DataAccessLayer;
using YoutubeClone.Foundation.Repositories;

namespace YoutubeClone.Foundation.UnitOfWorks
{
    public interface IChannelUnitOfWork : IUnitOfWork
    {
        IChannelRepository ChannelRepository { get; set; }
        IVideoRepository VideoRepository { get; set; }
        ISubscriberRepository SubscriberRepository { get; set; }
        IViewRepository ViewRepository { get; set; }
        ILikeRepository LikeRepository { get; set; }
        IDislikeRepository DislikeRepository { get; set; }
        ICommentRepository CommentRepository { get; set;} 
    }
}