using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YoutubeClone.Foundation.BusinessObjects;
using LikeBO = YoutubeClone.Foundation.BusinessObjects.Likes;
using LikeEO = YoutubeClone.Foundation.Entities.Likes;

namespace YoutubeClone.Foundation.Services
{
    public interface IFeedbackService
    {
        Task AddSubscriptionIntoDatabase(Guid channelId, string userName);
        bool IsUserSubscribeBefore(Guid channelId, string userName);
        void AddVideoViewCountInfo(VideoViewCount videoViewCount);
        int GetVideoViewCountFromDatabase(Guid id);
        IList<VideoViewCount> GetAllVideoView();
        int GetAllSubscriberCount(Guid channelId);
        IList<VideoViewChart> GetVideoViewCountonDateForChart(Guid channelId);
        void AddVideoLike(LikeBO likeBO);
        int GetLikesCount(Guid id);
        // IList<DataModel> GetVideoViewCountonDateForChart();
    }
}
