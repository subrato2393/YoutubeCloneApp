using YoutubeClone.Foundation.Entities;
using ChannelBO = YoutubeClone.Foundation.BusinessObjects.Channel;

namespace YoutubeClone.Foundation.Services
{
    public interface IChannelService
    {
        void AddChannelInfo(ChannelBO channel);
        void AddVideoInfoIntoDatabase(Video video);
    }
}