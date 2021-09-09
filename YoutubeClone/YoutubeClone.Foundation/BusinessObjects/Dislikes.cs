using System;

namespace YoutubeClone.Foundation.BusinessObjects
{
    public class Dislikes 
    {
        public Guid Id { get; set; }
        public int DislikesCount { get; set; } 
        public Guid VideoId { get; set; }
        public string UserName { get; set; }
    }
}
