using Autofac;
using Microsoft.AspNetCore.Http;
using System;
using YoutubeClone.Foundation.BusinessObjects;
using YoutubeClone.Foundation.Services;

namespace YoutubeClone.Models
{
    public class VideoViewModel
    {
        public Guid Id { get; set; }
        public string VideoTitle { get; set; }
        public string VideoName { get; set; }
        public IFormFile VideoFile { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public Channel Channel { get; set; }
        public string ChannelName { get; set; }
        public Guid ChannelId { get; set; }

        private readonly IChannelService _channelService;

        public VideoViewModel(IChannelService channelService)
        {
            _channelService = channelService;
        }

        public VideoViewModel()
        {
            _channelService = Startup.AutofacContainer.Resolve<IChannelService>();
        }

        public void GetVideoById(Guid id)
        {
            var video = _channelService.GetVideoById(id);
            
            ChannelName = video.ChannelName;
            Id = video.Id;
            VideoTitle = video.VideoTitle;
            VideoName = video.VideoName;
            VideoFile = video.VideoFile;
            Description = video.Description;
            PublishDate = video.PublishDate;
            Channel = video.Channel;
            ChannelName = video.ChannelName;
            ChannelId = video.ChannelId;
        }
    }
}

