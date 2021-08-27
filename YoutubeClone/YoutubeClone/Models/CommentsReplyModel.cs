using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoutubeClone.Foundation.BusinessObjects;
using YoutubeClone.Foundation.Services;
using YoutubeClone.Membership.Entities;

namespace YoutubeClone.Models
{
    public class CommentsReplyModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid CommentId { get; set; }
        public Guid VideoId { get; set; }
        public Comments Comments { get; set; }
        public ApplicationUser User { get; set; }

        private readonly IFeedbackService _feedbackService;

        public CommentsReplyModel(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        public CommentsReplyModel()
        {
            _feedbackService = Startup.AutofacContainer.Resolve<IFeedbackService>();
        }

        public void AddCommentsReplyIntoDatabase(string userName)
        {
            _feedbackService.AddCommentsReply(new CommentsReplyBO()
            {
                CommentId =CommentId,
                Description = Description,
                Id = Id,
                UserName = userName
            });
        }
    }
}
