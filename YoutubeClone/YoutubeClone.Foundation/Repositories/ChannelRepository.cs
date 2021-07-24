using NHibernate;
using YoutubeClone.DataAccessLayer;
using YoutubeClone.Foundation.Entities;

namespace YoutubeClone.Foundation.Repositories
{
    public class ChannelRepository : Repository<Channel>, IChannelRepository
    {
        public ChannelRepository(ISession session)
            : base(session)
        {

        }
    }
}
