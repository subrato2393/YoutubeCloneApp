using NHibernate;
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
