using FluentNHibernate.Mapping;
using YoutubeClone.Foundation.Entities;

namespace YoutubeClone.Foundation.Database.Mapping
{
    public class VideoMap : ClassMap<Video>
    {
        public VideoMap()
        {
            Id(x => x.Id).Column("Id").GeneratedBy.GuidNative();
            Map(x => x.Description);
            Map(x => x.PublishDate);
            Map(x => x.VideoTitle);
            Map(x => x.VideoName);
            References(x => x.Channel);
            HasMany(x => x.Views).Cascade.AllDeleteOrphan();
            HasMany(x => x.Likes).Cascade.AllDeleteOrphan();
        }
    }
}
