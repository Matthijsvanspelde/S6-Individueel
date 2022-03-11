using Assetservice.Data;
using Assetservice.Dtos;
using Assetservice.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Assetservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IAssetRepository _repository;
        private readonly IMapper _mapper;
        public AssetController(IAssetRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AssetReadDto>> GetAssets() 
        {
            var assets = _repository.GetAllAssets();
            return Ok(_mapper.Map<IEnumerable<AssetReadDto>>(assets));
        }

        [HttpGet("{id}",  Name="GetAssetById")]
        public ActionResult<AssetReadDto> GetAssetById(int id)
        {
            var asset = _repository.GetAssetById(id);
            if (asset != null)
            {
                return Ok(_mapper.Map<AssetReadDto>(asset));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<AssetReadDto> CreateAsset(AssetCreateDto assetCreateDto)
        {
            var assetModel = _mapper.Map<Asset>(assetCreateDto);
            _repository.CreateAsset(assetModel);
            _repository.SaveChanges();

            var assetReadDto = _mapper.Map<AssetReadDto>(assetModel);
            return CreatedAtRoute(nameof(GetAssetById), new { Id = assetReadDto.Id}, assetReadDto);
        }
    }
}
