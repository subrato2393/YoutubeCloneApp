using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoutubeClone.Entities;
using YoutubeClone.Foundation.Services;

namespace YoutubeClone.Models
{
    public class ChannelModel
    {
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }

        private readonly IChannelService _channelService;

        public ChannelModel()
        {
            _channelService = Startup.AutofacContainer.Resolve<IChannelService>();
        }
        public ChannelModel(IChannelService channelService)
        {
            _channelService = channelService;
        }
        public void AddChannelInformation(ChannelModel model)
        {
            _channelService.AddChannelInfo(new Channel()
            {
                CreateDate = model.CreateDate,
                Name = model.Name
            });
        }
    }
}
