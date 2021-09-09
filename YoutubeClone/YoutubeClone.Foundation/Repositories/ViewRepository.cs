using NHibernate;
using YoutubeClone.DataAccessLayer;
using YoutubeClone.Foundation.Entities;

namespace YoutubeClone.Foundation.Repositories
{
    public class ViewRepository : Repository<Views>, IViewRepository
    {
        public ViewRepository(ISession session)
            : base(session)
        {

        }    
    }
}
