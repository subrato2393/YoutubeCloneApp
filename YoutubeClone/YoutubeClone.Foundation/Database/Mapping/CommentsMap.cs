using FluentNHibernate.Mapping;
using YoutubeClone.Foundation.Entities;

namespace YoutubeClone.Foundation.Database.Mapping
{
    public class CommentsMap : ClassMap<Comments>
    {
        public CommentsMap() 
        {
            Id(x => x.Id).Column("Id").GeneratedBy.GuidNative();
            Map(x => x.Description);
            References(x => x.Video);
            References(x => x.User);
            HasMany(x => x.CommentsLikes).Cascade.AllDeleteOrphan();
        }
    }
}
