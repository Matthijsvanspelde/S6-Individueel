using Assetservice.Dtos;
using Assetservice.Models;
using AssetService.Dtos;
using AssetService.Models;
using AutoMapper;
using System;

namespace Assetservice.Profiles
{
    public class AssetsProfile : Profile
    {
        public AssetsProfile()
        {
            CreateMap<Asset, AssetReadDto>();
            CreateMap<AssetCreateDto, Asset>()
                .ForMember(a => a.FileName, o => o.MapFrom(s => Guid.NewGuid()));
            CreateMap<User, UserReadDto>();
            CreateMap<UserPublishDto, User>()
                .ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
