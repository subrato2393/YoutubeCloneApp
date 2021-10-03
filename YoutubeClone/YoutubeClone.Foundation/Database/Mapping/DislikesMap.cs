using FluentNHibernate.Mapping;
using YoutubeClone.Foundation.Entities;

namespace YoutubeClone.Foundation.Database.Mapping
{
    public class DislikesMap : ClassMap<Dislikes>
    {
        public DislikesMap() 
        {
            Id(x => x.Id).Column("Id").GeneratedBy.GuidNative();
            Map(x => x.DislikesCounts);
            References(x => x.Video);
            References(x => x.User);
        }
    }
}
