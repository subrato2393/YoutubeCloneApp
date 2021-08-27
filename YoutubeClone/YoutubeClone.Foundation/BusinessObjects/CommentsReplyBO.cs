using System;
using System.Collections.Generic;
using System.Text;

namespace YoutubeClone.Foundation.BusinessObjects
{
    public class CommentsReplyBO
    {
        public Guid Id { get; set; }
        public string Description { get; set; } 
        public Guid CommentId { get; set; }
        public string UserName { get; set; }
    }
}
