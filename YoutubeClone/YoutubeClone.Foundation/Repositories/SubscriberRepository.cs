using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;
using YoutubeClone.DataAccessLayer;
using YoutubeClone.Foundation.Entities;

namespace YoutubeClone.Foundation.Repositories
{
    public class SubscriberRepository : Repository<Subscriber>, ISubscriberRepository
    {
        public SubscriberRepository(ISession session)
            : base(session)
        {

        }
    }
}
