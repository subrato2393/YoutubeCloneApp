﻿using FluentNHibernate.Mapping;
using YoutubeClone.Foundation.Entities;

namespace YoutubeClone.Foundation.Database.Mapping
{
    public class SubscriberMap : ClassMap<Subscriber>
    {
        public SubscriberMap()
        {
            Id(x => x.Id).Column("Id").GeneratedBy.GuidNative();
            //Map(x => x.Name);
            //Map(x => x.Email);
            References(x => x.ApplicationUser);
            References(x => x.Channel);
        }
    }
}
