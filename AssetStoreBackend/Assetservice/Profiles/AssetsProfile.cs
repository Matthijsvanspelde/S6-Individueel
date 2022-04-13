using Assetservice.Dtos;
using Assetservice.Models;
using AssetService.Dtos;
using AssetService.Models;
using AutoMapper;

namespace Assetservice.Profiles
{
    public class AssetsProfile : Profile
    {
        public AssetsProfile()
        {
            CreateMap<Asset, AssetReadDto>();
            CreateMap<AssetCreateDto, Asset>();
            CreateMap<User, UserReadDto>();
            CreateMap<UserPublishDto, User>()
                .ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
