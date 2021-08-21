using Autofac;
using System;
using System.Collections;
using System.Collections.Generic;
using YoutubeClone.Foundation.Services;
using YoutubeClone.Membership.Entities;
using CommentBO = YoutubeClone.Foundation.BusinessObjects.Comments;

namespace YoutubeClone.Models
{
    public class CommentsModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid VideoId { get; set; }
        public string UserName { get; set; }
        public IList<CommentBO> CommentList {get; set;}
        public CommentBO Comment {get; set;}

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

        public void GetCurrentComment()
        {
            var commentBo =  _feedbackService.GetComment();
            Id = commentBo.Id;
            Description = commentBo.Description;
            VideoId = commentBo.VideoId;
            UserName = commentBo.User.UserName;
        }

        public void GetAllComments(Guid id, string name)
        {
            CommentList = _feedbackService.GetAllComments(id, name);
        }
    }
}
