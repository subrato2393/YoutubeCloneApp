using Microsoft.AspNetCore.Http;
using System;

namespace YoutubeClone.Foundation.BusinessObjects
{
    public class Video
    {
        public virtual Guid Id { get; set; }
        public virtual string VideoTitle { get; set; }
        public virtual string VideoName { get; set; }
        public virtual IFormFile VideoFile { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime PublishDate { get; set; }
    }
}
