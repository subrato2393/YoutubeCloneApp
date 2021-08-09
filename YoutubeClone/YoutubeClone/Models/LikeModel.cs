using Autofac;
using System;
using YoutubeClone.Foundation.Services;
using LikeBO = YoutubeClone.Foundation.BusinessObjects.Likes;

namespace YoutubeClone.Models
{
    public class LikeModel
    {
        public Guid Id { get; set; }
        public int LikeCount { get; set; }
        public Guid VideoId { get; set; }

        private readonly IFeedbackService _feedbackService;
        public LikeModel(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        public void GetLikeCount(Guid videoId)
        {
            //  LikeCount = _feedbackService.GetAllLikeCount(videoId);
            LikeCount =10;
        }

        public LikeModel()
        {
            _feedbackService = Startup.AutofacContainer.Resolve<IFeedbackService>();
        }
        public void AddLikeInfo(Guid videoId)
        {
            _feedbackService.AddVideoLike(new LikeBO()
            {
                LikesCount = 1,
                VideoId = videoId
            });
        }
    }
}
