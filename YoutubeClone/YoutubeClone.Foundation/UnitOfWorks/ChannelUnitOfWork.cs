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
        public ChannelUnitOfWork(IChannelRepository channelRepository,
            IVideoRepository videoRepository,
            ISubscriberRepository subscriberRepository,
            ISession session)
            : base(session)
        {
            ChannelRepository = channelRepository;
            VideoRepository = videoRepository;
            SubscriberRepository = subscriberRepository;
        }
    }
}
