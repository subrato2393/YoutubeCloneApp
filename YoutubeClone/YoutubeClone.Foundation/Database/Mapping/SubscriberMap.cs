using FluentNHibernate.Mapping;
using YoutubeClone.Foundation.Entities;

namespace YoutubeClone.Foundation.Database.Mapping
{
    public class SubscriberMap : ClassMap<Subscriber>
    {
        public SubscriberMap()
        {
            Id(x => x.Id).Column("Id").GeneratedBy.GuidNative();
            References(x => x.ApplicationUser);
            References(x => x.Channel);
        }
    }
}
