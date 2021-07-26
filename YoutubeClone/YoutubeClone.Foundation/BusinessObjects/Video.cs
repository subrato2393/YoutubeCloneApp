using Microsoft.AspNetCore.Http;
using System;

namespace YoutubeClone.Foundation.BusinessObjects
{
    public class Video
    {
        public  Guid Id { get; set; }
        public string VideoTitle { get; set; }
        public string VideoName { get; set; }
        public IFormFile VideoFile { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public Guid ChannelId { get; set; } 
    }
}
