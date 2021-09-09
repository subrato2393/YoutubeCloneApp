using System;
using YoutubeClone.Membership.Entities;

namespace YoutubeClone.Foundation.Entities
{
    public class Subscriber
    {
        public virtual Guid Id { get; set; }
        public virtual Channel  Channel{ get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
