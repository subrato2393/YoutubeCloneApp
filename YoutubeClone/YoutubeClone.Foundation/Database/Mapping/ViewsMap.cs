using FluentNHibernate.Mapping;
using YoutubeClone.Foundation.Entities;

namespace YoutubeClone.Foundation.Database.Mapping
{
    public class ViewsMap : ClassMap<Views>
    {
        public ViewsMap()
        {
            Id(x => x.Id).Column("Id").GeneratedBy.GuidNative();
            Map(x => x.ViewCount);
            Map(x => x.ViewDate).CustomSqlType("date");
            References(x => x.Video);
        }
    }
}
