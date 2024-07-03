using xyzboutique.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace xyzboutique.Infrastructure.Data.Configurations;

public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder
            .HasMany(p => p.ListaDeProductos);

        builder.HasOne(p => p.Vendedor);

        builder.HasOne(p => p.Repartidor);

        //builder
        //    .Property("VendedorId").HasColumnName("IdEmpleados");
        //builder
        //    .Property("RepartidorId").HasColumnName("IdEmpleados");
    }
}
