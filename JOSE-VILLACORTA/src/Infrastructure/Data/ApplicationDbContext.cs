using System.Reflection;
using xyzboutique.Application.Common.Interfaces;
using xyzboutique.Domain.Entities;
using xyzboutique.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace xyzboutique.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<TodoList> TodoLists => Set<TodoList>();

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();

    public DbSet<Empleado> Empleados => Set<Empleado>();

    public DbSet<Producto> Productos => Set<Producto>();

    public DbSet<Pedido> Pedidos => Set<Pedido>();

    public DbSet<DetallePedido> DetallePedidos => Set<DetallePedido>();

    public DbSet<TipoProducto> TipoProductos => Set<TipoProducto>();

    public DbSet<UnidadDeMedida> UnidadesDeMedida => Set<UnidadDeMedida>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
