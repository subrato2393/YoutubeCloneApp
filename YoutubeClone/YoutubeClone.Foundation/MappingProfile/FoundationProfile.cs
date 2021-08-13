using AutoMapper;
using System.Collections.Generic;
using YoutubeClone.Foundation.BusinessObjects;
using YoutubeClone.Foundation.Entities;
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
            CreateMap<EO.Video, BO.Video>();
            CreateMap<VideoViewCount,Views>();
            CreateMap<Views, VideoViewCount>();
            CreateMap<BO.Likes, EO.Likes>();
            CreateMap<EO.Comments, BO.Comments>();
        }
    }
}
