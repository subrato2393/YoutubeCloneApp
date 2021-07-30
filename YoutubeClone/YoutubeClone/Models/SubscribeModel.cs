using Autofac;
using System;
using YoutubeClone.Foundation.BusinessObjects;
using YoutubeClone.Foundation.Services;
using YoutubeClone.Membership.Entities;

namespace YoutubeClone.Models
{
    public class SubscribeModel
    {
        public virtual Guid Id { get; set; }
        public  Channel Channel { get; set; }
        public  ApplicationUser ApplicationUser { get; set; }
        public bool IsScribedUser { get; set; }

        private readonly IFeedbackService _feedbackService;

        public SubscribeModel()
        {
            _feedbackService = Startup.AutofacContainer.Resolve<IFeedbackService>();
        }

        public SubscribeModel(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        public void AddSubscriptionInfo(Guid channelId, string userName)
        {
            IsScribedUser = _feedbackService.IsUserSubscribeBefore(channelId, userName);
         
            if (!IsScribedUser)
            {
                _feedbackService.AddSubscriptionIntoDatabase(channelId, userName);
            }
        }
    }
}
