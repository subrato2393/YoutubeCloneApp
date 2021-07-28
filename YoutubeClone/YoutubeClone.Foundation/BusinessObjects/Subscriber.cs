using System;
using System.Collections.Generic;
using System.Text;
using YoutubeClone.Membership.Entities;

namespace YoutubeClone.Foundation.BusinessObjects
{
    public class Subscriber
    {
        public virtual Guid Id { get; set; }
        public virtual Channel Channel { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
