using System;

namespace YoutubeClone.Foundation.BusinessObjects
{
    public class Channel
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
