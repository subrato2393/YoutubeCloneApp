using System;
using System.Collections.Generic;
using System.Text;

namespace YoutubeClone.Foundation.BusinessObjects
{
    public class Comments
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid VideoId { get; set; }
    }
}
