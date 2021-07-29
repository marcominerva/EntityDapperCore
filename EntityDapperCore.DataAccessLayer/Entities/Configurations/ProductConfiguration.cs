using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityDapperCore.DataAccessLayer.Entities.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.Property(e => e.Id).HasColumnName("ProductId");
            builder.Property(e => e.Name).HasColumnName("ProductName");

            builder.HasOne(e => e.Category).WithMany(e => e.Products).HasForeignKey(e => e.CategoryId);
            builder.HasOne(e => e.Supplier).WithMany(e => e.Products).HasForeignKey(e => e.SupplierId);
        }
    }
}
