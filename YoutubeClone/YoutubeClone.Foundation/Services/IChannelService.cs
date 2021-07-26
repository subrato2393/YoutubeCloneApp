using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChannelBO = YoutubeClone.Foundation.BusinessObjects.Channel;
using VideoBO = YoutubeClone.Foundation.BusinessObjects.Video;

namespace YoutubeClone.Foundation.Services
{
    public interface IChannelService
    {
        void AddChannelInfo(ChannelBO channel);
        void AddVideoInfoIntoDatabase(VideoBO video);
        Task UploadVideoToFolder(VideoBO video);
        IList<ChannelBO> GetAllChannel();
        ChannelBO GetChannelById(Guid channelId);
        IList<VideoBO> GetAllVideos();
    }
}