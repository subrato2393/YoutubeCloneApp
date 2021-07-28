using System;
using System.Threading.Tasks;

namespace YoutubeClone.Foundation.Services
{
    public interface IFeedbackService
    {
        Task AddSubscriptionIntoDatabase(Guid channelId, string userName);
    }
}