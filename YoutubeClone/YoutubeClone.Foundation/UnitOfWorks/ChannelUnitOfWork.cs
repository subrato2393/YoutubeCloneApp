using NHibernate;
using YoutubeClone.DataAccessLayer;
using YoutubeClone.Foundation.Repositories;

namespace YoutubeClone.Foundation.UnitOfWorks
{
    public class ChannelUnitOfWork : UnitOfWork, IChannelUnitOfWork
    {
        public IChannelRepository ChannelRepository { get; set; }
        public IVideoRepository VideoRepository { get; set; }
        public ChannelUnitOfWork(IChannelRepository channelRepository,
            IVideoRepository videoRepository,
            ISession session)
            : base(session)
        {
            ChannelRepository = channelRepository;
            VideoRepository = videoRepository;
        }
    }
}
