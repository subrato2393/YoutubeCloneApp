using System;
using YoutubeClone.Membership.Entities;

namespace YoutubeClone.Foundation.Entities
{
    public class Likes
    {
        public virtual Guid Id { get; set; }
        public virtual int LikesCount { get; set; }
        public virtual Video Video { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
