using Assetservice.Models;
using System.Collections.Generic;

namespace Assetservice.Data
{
    public interface IAssetRepository
    {
        bool SaveChanges();
        IEnumerable<Asset> GetAllAssets();
        Asset GetAssetById(int id);
        void CreateAsset(Asset asset);
    }
}
