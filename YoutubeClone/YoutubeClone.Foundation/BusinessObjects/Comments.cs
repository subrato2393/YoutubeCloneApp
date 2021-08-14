using System;
using System.Collections.Generic;
using System.Text;
using YoutubeClone.Membership.Entities;

namespace YoutubeClone.Foundation.BusinessObjects
{
    public class Comments
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid VideoId { get; set; }
        public string UserName { get; set; }
        public ApplicationUser User { get; set; }
    }
}
