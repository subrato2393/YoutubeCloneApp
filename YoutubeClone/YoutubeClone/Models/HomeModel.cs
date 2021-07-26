using Autofac;
using System;
using System.Collections.Generic;
using YoutubeClone.Foundation.Services;
using VideoBO=  YoutubeClone.Foundation.BusinessObjects.Video;

namespace YoutubeClone.Models
{
    public class HomeModel
    {

        private readonly IChannelService _channelService;
        public HomeModel(IChannelService channelService)
        {
            _channelService = channelService;
        }
        public HomeModel()
        {
            _channelService = Startup.AutofacContainer.Resolve<IChannelService>();
        }
        public IList<VideoBO> GetVideoList()
        {
           return _channelService.GetAllVideos();
        }
    }
}
