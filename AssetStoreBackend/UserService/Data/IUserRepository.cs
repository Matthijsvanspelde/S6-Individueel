using System.Collections.Generic;
using UserService.Models;

namespace UserService.Data
{
    public interface IUserRepository
    {
        bool SaveChanges();
        IEnumerable<User> GetAllUser();
        User GetUserById(int id);
        void CreateUser(User user);
        bool AssetExists(int assetId);
    }
}
