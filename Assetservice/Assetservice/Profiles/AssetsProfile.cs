using Assetservice.Dtos;
using Assetservice.Models;
using AutoMapper;

namespace Assetservice.Profiles
{
    public class AssetsProfile : Profile
    {
        public AssetsProfile()
        {
            CreateMap<Asset, AssetReadDto>();
            CreateMap<AssetCreateDto, Asset>();
        }
    }
}
