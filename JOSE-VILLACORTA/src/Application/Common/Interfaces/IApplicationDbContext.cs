using xyzboutique.Domain.Entities;

namespace xyzboutique.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<Empleado> Empleados { get; }

    DbSet<Producto> Productos { get; }

    DbSet<Pedido> Pedidos { get; }

    DbSet<TipoProducto> TipoProductos { get; }

    DbSet<UnidadDeMedida> UnidadesDeMedida { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
