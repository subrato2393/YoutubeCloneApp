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
            Map(x => x.FileName);
            Map(x => x.PublishDate);
            Map(x => x.VideoTitle);
            HasMany(x => x.Views).Cascade.All();
            HasMany(x => x.Likes).Cascade.All();
        }
    }
}
