using Autofac;
using System;
using YoutubeClone.Foundation.Services;
using CommentsLikeBO=YoutubeClone.Foundation.BusinessObjects.CommentsLike;

namespace YoutubeClone.Models
{
    public class CommentsLikeModel
    { 
        public Guid Id { get; set; }
        public int LikeCount { get; set; }
        public Guid CommentId { get; set; }
        public bool IsLikedBefore { get; set; }
        public bool IsDislikeBefore { get; set; }
       
        private readonly IFeedbackService _feedbackService;
        
        public CommentsLikeModel(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        public CommentsLikeModel()
        {
            _feedbackService = Startup.AutofacContainer.Resolve<IFeedbackService>();
        }

        public void IsUserLikedBefore(Guid commentId,string name)
        {
            IsLikedBefore = _feedbackService.IsCommentLiked(commentId, name);
        }

        public void GetCommentLikeCount(Guid commentId)
        {
            LikeCount = _feedbackService.GetCommentsLikesCount(commentId);
        }
         
        public void IsUserLikedCommentBefore(Guid commentId, string name)
        { 
           // IsDislikeBefore = _feedbackService.IsCommentDisliked(commentId, name);

            IsLikedBefore = _feedbackService.IsCommentLiked(commentId, name);

            if (IsDislikeBefore)
            {
               // _feedbackService.DeleteCommentDislike(commentId, name);
            }
            if (IsLikedBefore)
            {
                _feedbackService.DeleteCommentLike(commentId, name);
            }
            else
            {
                _feedbackService.AddCommetsLike(new CommentsLikeBO()
                {
                    LikesCount = 1,
                    CommentId = commentId,
                    UserName = name
                });
            }
        }
    }
}
