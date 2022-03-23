using Assetservice.Data;
using Assetservice.Dtos;
using Assetservice.Models;
using AssetService.SyncDataServices.HTTP;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assetservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IAssetRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;

        public AssetController(
            IAssetRepository repository, 
            IMapper mapper, 
            ICommandDataClient commandDataClient)
        {
            _repository = repository;
            _mapper = mapper;
            _commandDataClient = commandDataClient;
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
        public async Task<ActionResult<AssetReadDto>> CreateAsset(AssetCreateDto assetCreateDto)
        {
            var assetModel = _mapper.Map<Asset>(assetCreateDto);
            _repository.CreateAsset(assetModel);
            _repository.SaveChanges();

            var assetReadDto = _mapper.Map<AssetReadDto>(assetModel);

            try
            {
                await _commandDataClient.SendAssetToCommand(assetReadDto);
            }
            catch (Exception e)
            {
                Console.WriteLine($"--> Could not send synchronously: {e.Message}");
            }

            return CreatedAtRoute(nameof(GetAssetById), new { Id = assetReadDto.Id}, assetReadDto);
        }
    }
}
