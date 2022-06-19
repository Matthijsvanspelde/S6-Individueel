using Assetservice.Data;
using Assetservice.Dtos;
using Assetservice.Models;
using AssetService.SyncDataServices.HTTP;
using AutoMapper;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assetservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAssetRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;

        public AssetController(
            IAssetRepository repository, 
            IMapper mapper, 
            ICommandDataClient commandDataClient,
            IConfiguration configuration)
        {
            _configuration = configuration;
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

        [Route("download/{id}")]
        [HttpGet]
        public async Task<ActionResult<AssetReadDto>> DownloadAssetById(int id)
        {
            //var asset = _repository.GetAssetById(id);
            //if (asset != null)
            //{
                var container = new BlobContainerClient(_configuration.GetConnectionString("AzureConnectionString"), "assetcontainer");
                var blob = container.GetBlobClient("animaties.zip");
                if (await blob.ExistsAsync())
                {
                    var a = await blob.DownloadAsync();
                    return File(a.Value.Content, a.Value.ContentType, "animaties.zip");
                }
            //}
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<AssetReadDto>> CreateAsset([FromForm] AssetCreateDto assetCreateDto)
        {
            
            var assetModel = _mapper.Map<Asset>(assetCreateDto);
            assetModel.UserId = 4;
            assetModel.User = _repository.GetUserById(4);
            _repository.CreateAsset(assetModel);
            _repository.SaveChanges();

            var assetReadDto = _mapper.Map<AssetReadDto>(assetModel);


            var file = assetCreateDto.File;


            if (file.Length > 0)
            {
                var container = new BlobContainerClient(_configuration.GetConnectionString("AzureConnectionString"), "assetcontainer");
                var createResponse = await container.CreateIfNotExistsAsync();
                if (createResponse != null && createResponse.GetRawResponse().Status == 201)
                    await container.SetAccessPolicyAsync(Azure.Storage.Blobs.Models.PublicAccessType.Blob);
                var blob = container.GetBlobClient(file.FileName);
                await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
                using (var fileStream = file.OpenReadStream())
                {
                    await blob.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = file.ContentType });
                }
            }

            await UploadCoverImageToAzureAsync(assetCreateDto.CoverImage);

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

        private async Task UploadCoverImageToAzureAsync(IFormFile image) 
        {
            if (image.Length > 0)
            {
                var container = new BlobContainerClient(_configuration.GetConnectionString("AzureConnectionString"), "imagecontainer");
                var createResponse = await container.CreateIfNotExistsAsync();
                if (createResponse != null && createResponse.GetRawResponse().Status == 201)
                    await container.SetAccessPolicyAsync(Azure.Storage.Blobs.Models.PublicAccessType.Blob);
                var blob = container.GetBlobClient(image.FileName);
                await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
                using (var fileStream = image.OpenReadStream())
                {
                    await blob.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = image.ContentType });
                }
            }
        }
    }
}
