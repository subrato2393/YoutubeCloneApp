﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YoutubeClone.Foundation.BusinessObjects;
using LikeBO = YoutubeClone.Foundation.BusinessObjects.Likes;
using LikeEO = YoutubeClone.Foundation.Entities.Likes;
using DislikeBO = YoutubeClone.Foundation.BusinessObjects.Dislikes;

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
        void AddComments(Comments comments);
        IList<VideoViewChart> GetVideoViewCountonDateForChart(Guid channelId);
        Task AddVideoLike(LikeBO likeBO);
        int GetLikesCount(Guid id);
        bool IsLiked(Guid videoId, string name);
        bool IsDisliked(Guid videoId, string name);
        void DeleteLike(Guid videoId, string name);
        void DeleteDislike(Guid videoId, string name);
        Task AddVideoDislike(DislikeBO dislikeBO);
        int GetDislikesCount(Guid id);
        IList<Comments> GetAllComments(Guid id);
    }
}
