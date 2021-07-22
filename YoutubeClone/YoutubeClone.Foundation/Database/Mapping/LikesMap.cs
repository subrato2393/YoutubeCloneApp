using FluentNHibernate.Mapping;
using YoutubeClone.Foundation.Entities;

namespace YoutubeClone.Foundation.Database.Mapping
{
    public class LikesMap : ClassMap<Likes>
    {
        public LikesMap()
        {
            Id(x => x.Id).Column("Id").GeneratedBy.GuidNative();
            Map(x => x.LikesCount);
            References(x => x.Video);
        }
    }
}
