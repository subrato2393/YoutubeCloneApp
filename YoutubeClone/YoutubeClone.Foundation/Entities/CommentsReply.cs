using System;
using YoutubeClone.Membership.Entities;

namespace YoutubeClone.Foundation.Entities
{
    public class CommentsReply
    {
        public virtual Guid Id { get; set; }
        public virtual string Description { get; set; } 
        public virtual Comments Comments { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
