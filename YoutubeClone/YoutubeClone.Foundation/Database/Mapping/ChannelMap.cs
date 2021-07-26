using FluentNHibernate.Mapping;
using YoutubeClone.Foundation.Entities;

namespace YoutubeClone.Foundation.Database.Mapping
{
    public class ChannelMap : ClassMap<Channel>
    {
        public ChannelMap()
        {
            Id(x => x.Id).Column("Id").GeneratedBy.GuidNative();
            Map(x => x.Name);
            Map(x => x.CreateDate);
            HasMany(x => x.Videos).Cascade.AllDeleteOrphan();
            HasMany(x => x.Subscribers).Cascade.AllDeleteOrphan();
        }
    }
}
