using Assetservice.Data;
using AssetService.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace AssetService.Controllers
{
    [Route("api/asset/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAssetRepository _repository;
        private readonly IMapper _mapper;

        public UserController(
            IAssetRepository repository,
            IMapper mapper,
            IConfiguration configuration)
        {
            _configuration = configuration;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserReadDto>> GetUsers()
        {
            var users = _repository.GetAllUsers();
            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(users));
        }
    }
}
