using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace YoutubeClone.Foundation.BusinessObjects
{
    public class VideoViewChart
    {  
        public DateTime ViewDate { get; set; }
        public int ViewCount { get; set; }
        public Guid ChannelId { get; set; }
        public List<SelectListItem> Channels { get; set; }
        public string ChannelName { get; set; }
    }
}
