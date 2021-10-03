using NHibernate;
using YoutubeClone.DataAccessLayer;
using YoutubeClone.Foundation.Entities;

namespace YoutubeClone.Foundation.Repositories
{
    public class CommentLikeRepository : Repository<CommentsLike>, ICommentLikeRepository
    {
        public CommentLikeRepository(ISession session)
            : base(session)
        {

        }
    }
}
