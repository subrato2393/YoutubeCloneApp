using Autofac;
using System;
using YoutubeClone.Foundation.BusinessObjects;
using YoutubeClone.Foundation.Services;

namespace YoutubeClone.Models
{
    public class ViewCountModel
    {
        public  Guid Id { get; set; }
        public int ViewCount { get; set; }
        public Video Video { get; set; }
        public DateTime ViewDate { get; set; } 

        private readonly IFeedbackService _feedbackService;
        private readonly IChannelService _channelService; 

        public ViewCountModel(IFeedbackService feedbackService,
            IChannelService channelService)
        {
            _feedbackService = feedbackService;
            _channelService = channelService;
        }

        public ViewCountModel()
        {
            _feedbackService = Startup.AutofacContainer.Resolve<IFeedbackService>();
            _channelService = Startup.AutofacContainer.Resolve<IChannelService>();
        }

        public void AddVideoViewInformation(Guid videoId)
        {
             var video = _channelService.GetVideoById(videoId);

            _feedbackService.AddVideoViewCountInfo(new VideoViewCount()
            {
                ViewCount = 1,
                Video = video,
                ViewDate = DateTime.Now
            });
        }
    }
}
