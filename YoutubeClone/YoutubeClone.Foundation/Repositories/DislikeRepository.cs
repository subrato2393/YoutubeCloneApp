using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;
using YoutubeClone.DataAccessLayer;
using YoutubeClone.Foundation.Entities;

namespace YoutubeClone.Foundation.Repositories
{
    public class DislikeRepository : Repository<Dislikes>, IDislikeRepository
    {
        public DislikeRepository(ISession session)
            : base(session)
        {

        }
    }
}
