using Autofac;
using System;
using YoutubeClone.Foundation.Services;
using YoutubeClone.Membership.Entities;
using LikeBO = YoutubeClone.Foundation.BusinessObjects.Likes;

namespace YoutubeClone.Models
{
    public class LikeModel
    {
        public Guid Id { get; set; }
        public int LikeCount { get; set; }
        public Guid VideoId { get; set; }
        public bool IsLikedBefore { get; set; }
        public bool IsDislikeBefore { get; set; }

        private readonly IFeedbackService _feedbackService;
        public LikeModel(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        public LikeModel()
        {
            _feedbackService = Startup.AutofacContainer.Resolve<IFeedbackService>();
        }
        public void GetLikeCount(Guid videoId)
        {
            //  LikeCount = _feedbackService.GetAllLikeCount(videoId);
            //LikeCount = 10;
        }
        public void GetVideoLikesCount(Guid id)
        {
            LikeCount = _feedbackService.GetLikesCount(id);
        }
        //public void IsLikedVideoBefore(Guid id, string name)
        //{
        //    IsLikedBefore = _feedbackService.IsLiked(id, name);
        //}
        public void IsUserLikedVideoBefore(Guid videoId, string name)
        {
            IsDislikeBefore = _feedbackService.IsDisliked(videoId,name);
            
            IsLikedBefore = _feedbackService.IsLiked(videoId, name);

            if (IsDislikeBefore)
            {
                _feedbackService.DeleteDislike(videoId, name);
            }
            if (IsLikedBefore)
            {
                _feedbackService.DeleteLike(videoId, name);
            }
            else
            {
                _feedbackService.AddVideoLike(new LikeBO()
                {
                    LikesCount = 1,
                    VideoId = videoId,
                    UserName = name
                });
            }
        }
    }
}
