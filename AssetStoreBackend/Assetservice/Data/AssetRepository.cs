using Assetservice.Models;
using AssetService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assetservice.Data
{
    public class AssetRepository : IAssetRepository
    {
        private readonly AppDbContext _context;

        public AssetRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateAsset(Asset asset)
        {
            if (asset == null)
            {
                throw new ArgumentNullException(nameof(asset));
            }
            _context.Add(asset);
        }

        public void CreateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _context.Add(user);
        }

        public bool ExternalUserExists(int externalUserId)
        {
            return _context.Users.Any(u => u.ExternalId == externalUserId);
        }

        public IEnumerable<Asset> GetAllAssets()
        {
            return _context.Assets.ToList();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public Asset GetAssetById(int id)
        {
            return _context.Assets.FirstOrDefault(a => a.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
