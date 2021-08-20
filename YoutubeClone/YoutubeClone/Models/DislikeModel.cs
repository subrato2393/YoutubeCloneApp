using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoutubeClone.Foundation.Services;
using DislikeBO = YoutubeClone.Foundation.BusinessObjects.Dislikes;

namespace YoutubeClone.Models
{
    public class DislikeModel
    {
        public Guid Id { get; set; }
        public int LikeCount { get; set; }
        public Guid VideoId { get; set; } 
        public bool IsDislikedBefore { get; set; }
        public bool IsLikedBefore { get; set; }  
        public int DislikesCount { get; set; }

        private readonly IFeedbackService _feedbackService;
        public DislikeModel(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }
        public DislikeModel() 
        {
            _feedbackService = Startup.AutofacContainer.Resolve<IFeedbackService>();
        }
        public void GetVideoDisLikesCount(Guid id)
        {
            DislikesCount = _feedbackService.GetDislikesCount(id);
        }

        internal void IsUserDislikedVideoBefore(Guid videoId, string name)
        {
            IsLikedBefore = _feedbackService.IsLiked(videoId, name);
           
            IsDislikedBefore = _feedbackService.IsDisliked(videoId, name);

            if (IsLikedBefore)
            {
                _feedbackService.DeleteLike(videoId, name);
            }
            if (IsDislikedBefore)
            {
                _feedbackService.DeleteDislike(videoId, name);
            }
            else
            {
                _feedbackService.AddVideoDislike(new DislikeBO()
                {
                    DislikesCount = 1,
                    VideoId = videoId,
                    UserName = name
                });
            }
        }

    }
}
