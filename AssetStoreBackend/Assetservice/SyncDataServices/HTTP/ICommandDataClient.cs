using Assetservice.Dtos;
using System.Threading.Tasks;

namespace AssetService.SyncDataServices.HTTP
{
    public interface ICommandDataClient
    {
        Task SendAssetToCommand(AssetReadDto asset);
    }
}
