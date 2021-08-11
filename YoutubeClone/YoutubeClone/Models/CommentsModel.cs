using Autofac;
using System;
using YoutubeClone.Foundation.Services;
using CommentBO = YoutubeClone.Foundation.BusinessObjects.Comments;

namespace YoutubeClone.Models
{
    public class CommentsModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid VideoId { get; set; }

        private readonly IFeedbackService _feedbackService;
        public CommentsModel(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }
        public CommentsModel()
        {
            _feedbackService = Startup.AutofacContainer.Resolve<IFeedbackService>();
        }
        public void AddCommentIntoDatabase()
        {
            _feedbackService.AddComments(new CommentBO()
            {
                Description = Description,
                Id = Id,
                VideoId = VideoId
            });
        }
    }
}
