using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoutubeClone.Entities;

namespace YoutubeClone.Database.Mapping
{
    public class ChannelMap : ClassMap<Channel>
    {
        public ChannelMap()
        {
            Id(x => x.Id)
           .Column("Id")
           .GeneratedBy.GuidNative();
            Map(x => x.Name);
        }
    }
}
