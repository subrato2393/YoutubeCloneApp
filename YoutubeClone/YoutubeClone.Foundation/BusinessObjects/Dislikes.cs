using System;
using System.Collections.Generic;
using System.Text;

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
