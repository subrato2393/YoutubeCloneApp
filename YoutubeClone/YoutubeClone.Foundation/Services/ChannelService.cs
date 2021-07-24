using ChannelBO = YoutubeClone.Foundation.BusinessObjects.Channel;
using ChannelEO = YoutubeClone.Foundation.Entities.Channel;
using YoutubeClone.Foundation.UnitOfWorks;
using AutoMapper;
using System;

namespace YoutubeClone.Foundation.Services 
{
    public class ChannelService : IChannelService
    {
        private readonly IChannelUnitOfWork _channelUnitOfWork;
        private readonly IMapper _mapper; 

        public ChannelService(IChannelUnitOfWork channelUnitOfWork,
            IMapper mapper)
        {
            _channelUnitOfWork = channelUnitOfWork;
            _mapper = mapper;
        }

        public void AddChannelInfo(ChannelBO channelBo)
        {
            if (channelBo != null)
            {
                var channelEO = _mapper.Map<ChannelEO>(channelBo);

                _channelUnitOfWork.BeginTransaction();

                _channelUnitOfWork.ChannelRepository.Add(channelEO);

                _channelUnitOfWork.Commit();
            }
            else
            {
                throw new InvalidOperationException("Channel info must be provide");
            }
        }
    }
}
