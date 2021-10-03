using System;

namespace YoutubeClone.Foundation.BusinessObjects
{
    public class CommentsLike 
    {
        public Guid Id { get; set; }
        public int LikesCount { get; set; }
        public Guid CommentId { get; set; }
        public string UserName { get; set; }
    }
}
