using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BO = YoutubeClone.Foundation.BusinessObjects;
using MO = YoutubeClone.Areas.Admin.Models;

namespace YoutubeClone.MappingProfile
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<BO.VideoViewChart,MO.ChartModel>();
        }
    }
}
