using System;

namespace YoutubeClone.Foundation.Entities
{
    public class Views 
    {
        public virtual Guid Id { get; set; }
        public virtual int ViewCount { get; set; }  
        public virtual Video Video { get; set; } 
        public virtual DateTime ViewDate { get; set; } 
    }
}
