using Autofac;
using System;
using System.Collections;
using System.Collections.Generic;
using YoutubeClone.Foundation.Services;
using CommentBO = YoutubeClone.Foundation.BusinessObjects.Comments;

namespace YoutubeClone.Models
{
    public class CommentsModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid VideoId { get; set; }
        public IList<CommentBO> CommentList {get; set;}

        private readonly IFeedbackService _feedbackService;
        public CommentsModel(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }
        public CommentsModel()
        {
            _feedbackService = Startup.AutofacContainer.Resolve<IFeedbackService>();
        }
        public void AddCommentIntoDatabase(string userName)
        {
            _feedbackService.AddComments(new CommentBO()
            {
                Description = Description,
                Id = Id,
                VideoId = VideoId,
                UserName = userName
            });
        }
        public void GetAllComments(Guid id, string name)
        {
            CommentList = _feedbackService.GetAllComments(id, name);
        }
    }
}
