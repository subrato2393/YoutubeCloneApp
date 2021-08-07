using System;
using System.Collections.Generic;
using System.Text;

namespace YoutubeClone.Foundation.BusinessObjects
{
    public class VideoViewCount
    {
        public Guid Id { get; set; } 
        public int ViewCount { get; set; } 
        public Video Video { get; set; }
        public DateTime ViewDate { get; set; } 
    }
}
