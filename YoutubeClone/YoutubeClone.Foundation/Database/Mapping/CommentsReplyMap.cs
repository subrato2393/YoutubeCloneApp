using FluentNHibernate.Mapping;
using YoutubeClone.Foundation.Entities;

namespace YoutubeClone.Foundation.Database.Mapping
{
    public class CommentsReplyMap: ClassMap<CommentsReply>
    {
        public CommentsReplyMap()
        {
            Id(x => x.Id).Column("Id").GeneratedBy.GuidNative();
            Map(x => x.Description);
            References(x => x.User);
            References(x => x.Comments);
        }
    }
}
