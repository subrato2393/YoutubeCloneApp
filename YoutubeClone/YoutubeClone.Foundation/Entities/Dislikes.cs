using System;
using YoutubeClone.Membership.Entities;

namespace YoutubeClone.Foundation.Entities
{
    public class Dislikes
    {
        public virtual Guid Id { get; set; }
        public virtual int DislikesCounts { get; set; } 
        public virtual Video Video { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
