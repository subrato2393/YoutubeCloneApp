using System;
using System.Collections.Generic;
using System.Text;
using YoutubeClone.Membership.Entities;

namespace YoutubeClone.Foundation.Entities
{
    public class CommentsLike
    { 
        public virtual Guid Id { get; set; }
        public virtual int LikesCount { get; set; }
        public virtual Comments Comments { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
