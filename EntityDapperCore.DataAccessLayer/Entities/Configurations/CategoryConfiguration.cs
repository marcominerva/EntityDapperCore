using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityDapperCore.DataAccessLayer.Entities.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.Property(e => e.Id).HasColumnName("CategoryId");
            builder.Property(e => e.Name).HasColumnName("CategoryName");
        }
    }
}
