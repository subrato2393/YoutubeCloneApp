using Autofac;
using System;
using System.ComponentModel.DataAnnotations;
using YoutubeClone.Foundation.Services;
using ChannelBO = YoutubeClone.Foundation.BusinessObjects.Channel;


namespace YoutubeClone.Areas.Admin.Models
{
    public class ChannelModel
    {
        [Required]
        [Display(Name = "Name")]
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

        public void AddChannelInformation()
        {
            _channelService.AddChannelInfo(new ChannelBO()
            {
                CreateDate = DateTime.Now,
                Name = Name
            });
        }
    }
}
