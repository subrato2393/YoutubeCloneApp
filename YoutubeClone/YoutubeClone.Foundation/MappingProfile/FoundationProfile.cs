using AutoMapper;
using BO = YoutubeClone.Foundation.BusinessObjects;
using EO = YoutubeClone.Foundation.Entities;

namespace YoutubeClone.Foundation.MappingProfile
{
    public class FoundationProfile : Profile
    {
        public FoundationProfile()
        {
            CreateMap<BO.Channel, EO.Channel>();
            CreateMap<BO.Video, EO.Video>();
        }
    }
}
