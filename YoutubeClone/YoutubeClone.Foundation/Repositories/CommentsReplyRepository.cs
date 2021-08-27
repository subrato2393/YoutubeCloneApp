using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;
using YoutubeClone.DataAccessLayer;
using YoutubeClone.Foundation.Entities;

namespace YoutubeClone.Foundation.Repositories
{
    public class CommentsReplyRepository:Repository<CommentsReply>,ICommentReplyRepository
    {
        public CommentsReplyRepository(ISession session)
            :base(session)
        {

        }
    }
}
