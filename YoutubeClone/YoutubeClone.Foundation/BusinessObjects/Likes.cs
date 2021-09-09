using System;

namespace YoutubeClone.Foundation.BusinessObjects
{
    public class Likes
    {
        public Guid Id { get; set; }
        public int LikesCount { get; set; }  
        public Guid VideoId { get; set; }
        public string UserName { get; set; }
    }
}
