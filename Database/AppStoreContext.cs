using Microsoft.EntityFrameworkCore;
using ThienAspWebApi.Models;

namespace ThienAspWebApi.Database
{
    public class AppStoreContext : DbContext
    {
        public AppStoreContext(DbContextOptions<AppStoreContext> options) : base(options)
        {
        }

        public DbSet<Category>? Categories { get; set; }
        public DbSet<TypeCate>? TypeCates { get; set; }
        public DbSet<Product>? Products { get; set; }


    }
}
