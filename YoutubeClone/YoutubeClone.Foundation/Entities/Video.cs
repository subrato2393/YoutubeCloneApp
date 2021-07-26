using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace YoutubeClone.Foundation.Entities
{
    public class Video
    {
        public virtual Guid Id { get; set; }
        public virtual string VideoTitle { get; set; }
        public virtual string VideoName { get; set; }
        public virtual IFormFile VideoFile { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime PublishDate { get; set; }
        public virtual Channel Channel { get; set; }
        public virtual Guid ChannelId { get; set; }
        public virtual IList<Views> Views { get; set; }
        public virtual IList<Likes> Likes { get; set; }
    }
}
