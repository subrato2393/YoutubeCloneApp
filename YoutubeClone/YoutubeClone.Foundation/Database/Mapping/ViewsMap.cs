using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using YoutubeClone.Foundation.Entities;

namespace YoutubeClone.Foundation.Database.Mapping
{
    public class ViewsMap : ClassMap<Views>
    {
        public ViewsMap()
        {
            //  Id(x => x.Id).GeneratedBy.Identity();
            Id(x => x.Id).Column("Id").GeneratedBy.GuidNative();
            Map(x => x.ViewCount);
            References(x => x.Video);
        }
    }
}
