using ChannelBO = YoutubeClone.Foundation.BusinessObjects.Channel;

namespace YoutubeClone.Foundation.Services
{
    public interface IChannelService
    {
        void AddChannelInfo(ChannelBO channel);
    }
}