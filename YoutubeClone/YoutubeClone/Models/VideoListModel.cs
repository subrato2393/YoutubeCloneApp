using Autofac;
using System.Collections.Generic;
using YoutubeClone.Foundation.BusinessObjects;
using YoutubeClone.Foundation.Services;

namespace YoutubeClone.Models
{
    public class VideoListModel
    {
        public IList<Video> Videos { get; set; }

        private readonly IChannelService _channelService;

        public VideoListModel(IChannelService channelService)
        {
            _channelService = channelService;
        }

        public VideoListModel()
        {
            _channelService = Startup.AutofacContainer.Resolve<IChannelService>();
        }

        public void GetVideoList()
        {
            Videos = _channelService.GetAllVideos();
        }
    }
}
