using System;
using YoutubeClone.Membership.Entities;

namespace YoutubeClone.Foundation.BusinessObjects
{
    public class Comments
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid VideoId { get; set; } 
        public string UserName { get; set; }
        public int LikeCount { get; set; }
        public bool IsUserLikedCommentBefore { get; set; }
        public string CommentReplyDescription { get; set; }  
        public ApplicationUser User { get; set; }
        public CommentsLike CommentsLike { get; set; }
        public CommentsReplyBO CommentsReplyBO { get; set; }
    }
}
