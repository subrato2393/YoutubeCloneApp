using Autofac;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
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
        public bool IsScribedUser { get; set; } 
        public int VideoViewCount { get; set; } 
        public int SubscriberCount { get; set; } 
        public int LikesCount { get; set; }
        public int DislikesCount { get; set; } 
        public bool IsLikedBefore { get; set; }
        public bool IsDislikedBefore { get; set; }
        public string UserName { get; set; }
        public IList<Comments> CommentList { get; set; }

        private readonly IChannelService  _channelService;
        private readonly IFeedbackService  _feedbackService;

        public VideoViewModel(IChannelService channelService,
            IFeedbackService feedbackService)
        {
            _channelService = channelService;
            _feedbackService = feedbackService;
        }

        public VideoViewModel()
        {
            _channelService = Startup.AutofacContainer.Resolve<IChannelService>();
            _feedbackService = Startup.AutofacContainer.Resolve<IFeedbackService>();
        }

        public void GetVideoById(Guid id,string userName)
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

            IsScribedUser = _feedbackService.IsUserSubscribeBefore(ChannelId, userName);
        }
        public void GetVideoViewCount(Guid id)
        {
            VideoViewCount = _feedbackService.GetVideoViewCountFromDatabase(id);
        }

        public void GetSubscriberCount()
        {
            SubscriberCount = _feedbackService.GetAllSubscriberCount(ChannelId);
        }
        public void GetVideoLikesCount(Guid id)
        {
            LikesCount = _feedbackService.GetLikesCount(id);
        }
        public void GetVideoDisLikesCount(Guid id)
        {
            DislikesCount = _feedbackService.GetDislikesCount(id);
        }
        public void IsLikedVideoBefore(Guid id, string name)
        {
            IsLikedBefore = _feedbackService.IsLiked(id, name);
        }  
        public void IsDislikedVideoBefore(Guid id, string name)
        {
            IsDislikedBefore = _feedbackService.IsDisliked(id, name);
        }

        public void GetAllComments(Guid id,string name)
        {
            CommentList = _feedbackService.GetAllComments(id,name);
        }
    }
}

