using System;
using System.Threading.Tasks;
using YoutubeClone.Membership.Entities;

namespace YoutubeClone.Foundation.Entities
{
    public class Subscriber
    {
        public virtual Guid Id { get; set; }
        //public virtual string Name { get; set; } 
        //public virtual string Email { get; set; } 
        public virtual Channel  Channel{ get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
