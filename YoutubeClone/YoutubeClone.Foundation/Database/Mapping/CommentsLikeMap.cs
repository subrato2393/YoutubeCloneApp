using FluentNHibernate.Mapping;
using YoutubeClone.Foundation.Entities;

namespace YoutubeClone.Foundation.Database.Mapping
{
    public class CommentsLikeMap : ClassMap<CommentsLike>
    {
        public CommentsLikeMap()
        {
            Id(x => x.Id).Column("Id").GeneratedBy.GuidNative();
            Map(x => x.LikesCount);
            References(x => x.User);
            References(x => x.Comments);
        }
    }
}
