using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ThienAspWebApi.Models;

namespace ThienAspWebApi.Database
{

    public class AppStoreContext : IdentityDbContext<AppUser>
    {
        public AppStoreContext(DbContextOptions<AppStoreContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName!.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }
        }

        public DbSet<Category>? Categories { get; set; }
        public DbSet<TypeCate>? TypeCates { get; set; }
        public DbSet<Product>? Products { get; set; }


    }
}
