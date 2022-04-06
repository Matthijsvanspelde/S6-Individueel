using Assetservice.Models;
using AssetService.Models;
using Microsoft.EntityFrameworkCore;

namespace Assetservice.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base (opt)
        { 
        
        }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasMany(u => u.Assets)
                .WithOne(u => u.User!)
                .HasForeignKey(u => u.UserId);

            modelBuilder
                .Entity<Asset>()
                .HasOne(u => u.User)
                .WithMany(u => u.Assets)
                .HasForeignKey(u => u.UserId);
        }
    }
}
