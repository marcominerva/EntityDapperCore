using EntityDapperCore.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityDapperCore.DataAccessLayer
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
