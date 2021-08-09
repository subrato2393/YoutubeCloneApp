using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;
using YoutubeClone.DataAccessLayer;
using YoutubeClone.Foundation.Entities;

namespace YoutubeClone.Foundation.Repositories
{
    public class LikeRepository : Repository<Likes>, ILikeRepository
    {
        public LikeRepository(ISession session)
            : base(session)
        {

        }
    }
}
