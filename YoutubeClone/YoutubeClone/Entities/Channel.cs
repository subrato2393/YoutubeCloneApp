using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YoutubeClone.Entities
{
    public class Channel
    {
        public virtual Guid Id { get; set; }  
        public virtual string Name { get; set; } 
    }
}
