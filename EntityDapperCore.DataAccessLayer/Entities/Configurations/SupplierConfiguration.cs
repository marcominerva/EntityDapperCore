using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityDapperCore.DataAccessLayer.Entities.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers");

            builder.Property(e => e.Id).HasColumnName("SupplierId");
        }
    }
}
