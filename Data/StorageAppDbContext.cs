using Microsoft.EntityFrameworkCore;
using SonicUniverse.Entities;

namespace SonicUniverse.Data
{
    public class StorageAppDbContext : DbContext 
    {
        public DbSet<Characters> characters => Set<Characters>();
        public DbSet<Organization> organizations => Set<Organization>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        }
    }
}
