using System;
using System.Collections.Generic;
using System.Text;
using YoutubeClone.Membership.Entities;

namespace YoutubeClone.Foundation.BusinessObjects
{
    public class Subscriber
    {
        public Guid Id { get; set; }
        public Channel Channel { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
