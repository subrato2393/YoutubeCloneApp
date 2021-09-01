using Autofac;
using System;
using System.Collections.Generic;
using YoutubeClone.Foundation.BusinessObjects;
using YoutubeClone.Foundation.Services;

namespace YoutubeClone.Models
{
    public class VideoListModel
    {
        public IList<Video> Videos { get; set;}
        public IList<VideoViewCount> VideoViewCounts { get; set; }

        private readonly IChannelService _channelService;
        private readonly IFeedbackService _feedbackService; 

        public VideoListModel(IChannelService channelService,
            IFeedbackService feedbackService)
        {
            _channelService = channelService;
            _feedbackService = feedbackService;
        }

        public VideoListModel()
        {
            _channelService = Startup.AutofacContainer.Resolve<IChannelService>();
            _feedbackService = Startup.AutofacContainer.Resolve<IFeedbackService>();
        }

        public void GetVideoList()
        {
            Videos = _channelService.GetAllVideos();
        }

        public void GetVideoViewCount()
        {
            VideoViewCounts = _feedbackService.GetAllVideoView();
        }
    }
} 
