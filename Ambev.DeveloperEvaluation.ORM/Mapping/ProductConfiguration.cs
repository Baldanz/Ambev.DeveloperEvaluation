using Ambev.DeveloperEvaluation.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

            builder.Property(u => u.Title).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Price).IsRequired();
            builder.Property(u => u.Description).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Category).IsRequired().HasMaxLength(20);
            builder.Property(u => u.Image).IsRequired().HasMaxLength(20);

        }
    }
}
