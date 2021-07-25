using NHibernate;
using YoutubeClone.DataAccessLayer;
using YoutubeClone.Foundation.Entities;

namespace YoutubeClone.Foundation.Repositories
{
    public class VideoRepository : Repository<Video>, IVideoRepository
    {
        public VideoRepository(ISession session)
            : base(session)
        {

        }
    }
}
