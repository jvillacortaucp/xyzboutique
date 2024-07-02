using xyzboutique.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace xyzboutique.Infrastructure.Data.Configurations;

public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.Property(t => t.SKU)
            .HasMaxLength(8)
            .IsRequired();
    }
}
