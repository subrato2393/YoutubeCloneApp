using System;
using YoutubeClone.Membership.Entities;

namespace YoutubeClone.Foundation.Entities
{
    public class Comments
    {
        public virtual Guid Id { get; set; }
        public virtual string Description { get; set; }
        public virtual Video Video { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
