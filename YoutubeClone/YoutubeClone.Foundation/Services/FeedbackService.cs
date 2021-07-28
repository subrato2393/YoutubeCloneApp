using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using YoutubeClone.Foundation.Entities;
using YoutubeClone.Foundation.UnitOfWorks;
using YoutubeClone.Membership.Entities;

namespace YoutubeClone.Foundation.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IChannelUnitOfWork _channelUnitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public FeedbackService(IChannelUnitOfWork channelUnitOfWork,
            UserManager<ApplicationUser> userManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _channelUnitOfWork = channelUnitOfWork;
            _mapper = mapper;
        }

        public async Task AddSubscriptionIntoDatabase(Guid channelId, string userName)
        {
            var channel = _channelUnitOfWork.ChannelRepository.GetById(channelId);
            var user = await _userManager.FindByEmailAsync(userName);

            var subscriber = new Subscriber()
            {
                ApplicationUser = user,
                Channel = channel
            };

            _channelUnitOfWork.BeginTransaction();
            _channelUnitOfWork.SubscriberRepository.Add(subscriber);
            _channelUnitOfWork.Commit();
        }
    }
}
