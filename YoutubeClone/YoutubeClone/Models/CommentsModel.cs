using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YoutubeClone.Models
{
    public class CommentsModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid VideoId { get; set; }
    }
}
