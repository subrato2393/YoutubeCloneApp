using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoutubeClone.Foundation.BusinessObjects;
using YoutubeClone.Foundation.Entities;
using YoutubeClone.Foundation.UnitOfWorks;
using YoutubeClone.Membership.Entities;
using Subscriber = YoutubeClone.Foundation.Entities.Subscriber;

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

        public bool IsUserSubscribeBefore(Guid channelId, string userName)
        {
            var subscribers = _channelUnitOfWork.SubscriberRepository.GetAll();
            var subscribeUsers = subscribers.Where(x => x.Channel.Id == channelId && x.ApplicationUser.Email == userName).ToList();

            return subscribeUsers.Count > 0;
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

        public void AddVideoViewCountInfo(VideoViewCount videoViewCount)
        {
            var viewsEntity = _mapper.Map<Views>(videoViewCount);

            _channelUnitOfWork.BeginTransaction();
            _channelUnitOfWork.ViewRepository.Add(viewsEntity);
            _channelUnitOfWork.Commit();
        }

        public int GetVideoViewCountFromDatabase(Guid id)
        {
            var views = _channelUnitOfWork.ViewRepository.GetAll();
            var count = views.Where(x => x.Video.Id == id).Count();
            return count;
        }

        public IList<VideoViewCount> GetAllVideoView()  
        {
            var videoView = _channelUnitOfWork.ViewRepository.GetAll();
            
            var videoViewBo = _mapper.Map<IList<VideoViewCount>>(videoView);
           
            return videoViewBo;
        }

        public int GetAllSubscriberCount(Guid channelId)
        {
            var subscribers = _channelUnitOfWork.SubscriberRepository.GetAll();
            var count = subscribers.Where(x => x.Channel.Id == channelId).Count();
            return count;
        }
    }
}
