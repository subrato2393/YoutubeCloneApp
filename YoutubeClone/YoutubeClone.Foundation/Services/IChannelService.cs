using System;
using System.Collections.Generic;
using ChannelBO = YoutubeClone.Foundation.BusinessObjects.Channel;
using VideoBO = YoutubeClone.Foundation.BusinessObjects.Video;

namespace YoutubeClone.Foundation.Services
{
    public interface IChannelService
    {
        void AddChannelInfo(ChannelBO channel);
        void UploadVideoToFolder(VideoBO video);
        IList<ChannelBO> GetAllChannel();
        ChannelBO GetChannelById(Guid channelId);
        IList<VideoBO> GetAllVideos();
        VideoBO GetVideoById(Guid id);
    }
}