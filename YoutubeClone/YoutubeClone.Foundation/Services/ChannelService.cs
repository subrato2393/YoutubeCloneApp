using YoutubeClone.Entities;
using YoutubeClone.Foundation.UnitOfWorks;

namespace YoutubeClone.Foundation.Services 
{
    public class ChannelService : IChannelService
    {
        private readonly IChannelUnitOfWork _channelUnitOfWork;

        public ChannelService(IChannelUnitOfWork channelUnitOfWork)
        {
            _channelUnitOfWork = channelUnitOfWork;
        }
        public void AddChannelInfo(Channel channel)
        {
            _channelUnitOfWork.ChannelRepository.Add(channel);

            _channelUnitOfWork.Commit();
        }
    }
}
