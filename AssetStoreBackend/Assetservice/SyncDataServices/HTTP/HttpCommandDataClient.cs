using Assetservice.Dtos;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AssetService.SyncDataServices.HTTP
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public HttpCommandDataClient(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task SendAssetToCommand(AssetReadDto asset)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(asset),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync($"{_config["UserService"]}", httpContent);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Sync POST to UserService Ok");
            }
            else
            {
                Console.WriteLine("-- > Sync POST to UserService Error");
            }
        }
    }
}
