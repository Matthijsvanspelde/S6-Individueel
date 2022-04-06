using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Asset> Assets { get; set; }

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
