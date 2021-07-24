using System;
using System.Collections.Generic;

namespace YoutubeClone.Foundation.Entities
{
    public class Channel
    {
        public virtual Guid Id { get; set; }  
        public virtual string Name { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual IList<Video> Videos { get; set; }
        public virtual IList<Subscriber> Subscribers { get; set; }
    }
}
