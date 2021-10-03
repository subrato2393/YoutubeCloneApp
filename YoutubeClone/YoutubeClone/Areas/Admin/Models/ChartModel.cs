using Autofac;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using DataModelBo= YoutubeClone.Foundation.BusinessObjects.VideoViewChart;
using YoutubeClone.Foundation.Services;
using AutoMapper;

namespace YoutubeClone.Areas.Admin.Models
{
    public class ChartModel
    {
        public DateTime ViewDate { get; set; } 
        public int ViewCount { get; set; }
        public List<SelectListItem> Channels { get; set; }
        public IList<ChartModel> ChartModels { get; set; }
        public Guid ChannelId { get; set; }
        public string ChannelName { get; set; } 

        private readonly IChannelService _channelService;
        private readonly IFeedbackService _feedbackService;
        private readonly IMapper _mapper;
     
        public ChartModel(IChannelService channelService,
            IFeedbackService feedbackService,
            IMapper mapper)
        {
            _feedbackService = feedbackService;
            _channelService = channelService;
            _mapper = mapper;
        }

        public ChartModel()
        {
            _channelService = Startup.AutofacContainer.Resolve<IChannelService>();
            _feedbackService = Startup.AutofacContainer.Resolve<IFeedbackService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

        public void GetVideoViewCountSpecificDate(Guid channelId)
        {
            var dataModels = _feedbackService.GetVideoViewCountonDateForChart(channelId);
            ChartModels= _mapper.Map<IList<ChartModel>>(dataModels);
        }

        public void GetAllChannel()
        {
            var channelList = _channelService.GetAllChannel();

            var channels = (from t in channelList
                            select new SelectListItem
                            {
                                Value = t.Id.ToString(),
                                Text = t.Name,
                            }).ToList();

            Channels = channels;
        }
    }
}
