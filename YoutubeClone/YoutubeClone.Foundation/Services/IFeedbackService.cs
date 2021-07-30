using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YoutubeClone.Foundation.BusinessObjects;

namespace YoutubeClone.Foundation.Services
{
    public interface IFeedbackService
    {
        Task AddSubscriptionIntoDatabase(Guid channelId, string userName);
        bool IsUserSubscribeBefore(Guid channelId, string userName);
        void AddVideoViewCountInfo(VideoViewCount videoViewCount);
        int GetVideoViewCountFromDatabase(Guid id);
        IList<VideoViewCount> GetAllVideoView();
    }
}
