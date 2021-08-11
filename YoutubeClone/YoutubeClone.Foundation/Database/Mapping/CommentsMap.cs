using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using YoutubeClone.Foundation.Entities;

namespace YoutubeClone.Foundation.Database.Mapping
{
    public class CommentsMap : ClassMap<Comments>
    {
        public CommentsMap() 
        {
            Id(x => x.Id).Column("Id").GeneratedBy.GuidNative();
            Map(x => x.Description);
            References(x => x.Video);
        }
    }
}
