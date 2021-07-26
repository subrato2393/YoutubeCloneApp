using AutoMapper;
using System.Collections.Generic;
using BO = YoutubeClone.Foundation.BusinessObjects;
using EO = YoutubeClone.Foundation.Entities;

namespace YoutubeClone.Foundation.MappingProfile
{
    public class FoundationProfile : Profile
    {
        public FoundationProfile()
        {
            CreateMap<BO.Channel, EO.Channel>();
            CreateMap<EO.Channel, BO.Channel>();
            CreateMap<BO.Video, EO.Video>();
        }
    }
}
