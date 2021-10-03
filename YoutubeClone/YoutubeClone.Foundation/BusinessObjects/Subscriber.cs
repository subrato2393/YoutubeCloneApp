using System;
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
