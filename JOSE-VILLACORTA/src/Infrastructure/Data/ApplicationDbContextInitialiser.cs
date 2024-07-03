using System.Runtime.InteropServices;
using xyzboutique.Domain.Constants;
using xyzboutique.Domain.Entities;
using xyzboutique.Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace xyzboutique.Infrastructure.Data;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }
}

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        var administratorRole = new IdentityRole(Roles.Administrator);

        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }

        // Default users
        var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "Administrator1!");
            if (!string.IsNullOrWhiteSpace(administratorRole.Name))
            {
                await _userManager.AddToRolesAsync(administrator, new [] { administratorRole.Name });
            }
        }

        // vendedor roles
        var vendedorRole = new IdentityRole(Roles.Vendedor);

        if (_roleManager.Roles.All(r => r.Name != vendedorRole.Name))
        {
            await _roleManager.CreateAsync(vendedorRole);
        }

        // vendedor users
        var vendedor = new ApplicationUser { UserName = "vendedor@localhost", Email = "vendedor@localhost" };

        if (_userManager.Users.All(u => u.UserName != vendedor.UserName))
        {
            await _userManager.CreateAsync(vendedor, "Vendedor1!");
            if (!string.IsNullOrWhiteSpace(vendedorRole.Name))
            {
                await _userManager.AddToRolesAsync(vendedor, new[] { vendedorRole.Name });
            }
        }

        // repartidor roles
        var repartidorRole = new IdentityRole(Roles.Repartidor);

        if (_roleManager.Roles.All(r => r.Name != repartidorRole.Name))
        {
            await _roleManager.CreateAsync(repartidorRole);
        }

        // repartidor users
        var repartidor = new ApplicationUser { UserName = "repartidor@localhost", Email = "repartidor@localhost" };

        if (_userManager.Users.All(u => u.UserName != repartidor.UserName))
        {
            await _userManager.CreateAsync(repartidor, "Repartidor1!");
            if (!string.IsNullOrWhiteSpace(repartidorRole.Name))
            {
                await _userManager.AddToRolesAsync(repartidor, new[] { repartidorRole.Name });
            }
        }

        // Default data
        // Seed, if necessary
        if (!_context.TodoLists.Any())
        {
            _context.TodoLists.Add(new TodoList
            {
                Title = "Todo List",
                Items =
                {
                    new TodoItem { Title = "Make a todo list 📃" },
                    new TodoItem { Title = "Check off the first item ✅" },
                    new TodoItem { Title = "Realise you've already done two things on the list! 🤯"},
                    new TodoItem { Title = "Reward yourself with a nice, long nap 🏆" },
                }
            });

            await _context.SaveChangesAsync();
        }

        if (!_context.Empleados.Any())
        {
            _context.Empleados.Add(new Empleado
            {
                Nombre = "Vendedor",
                CodigoTrabajador = "123456",
                CorreoElectronico = "vendedor@localhost",
                Telefono = "1234567890",
                Puesto = "Vendedor"
            });
            _context.Empleados.Add(new Empleado
            {
                Nombre = "Repartidor",
                CodigoTrabajador = "234567",
                CorreoElectronico = "repartidor@localhost",
                Telefono = "2345678901",
                Puesto = "Repartidor"
            });

            await _context.SaveChangesAsync();
        }

        if (!_context.Productos.Any())
        {
            _context.TipoProductos.Add(new TipoProducto
            {
                Nombre = "Abarrotes"
            });

            _context.UnidadesDeMedida.Add(new UnidadDeMedida
            {
                Nombre = "Unidad",
                Descripcion = "Unidad",
                Abreviatura = "Und"
            });

            _context.Productos.Add(new Producto
            {
                SKU = "12345678",
                Nombre = "Arroz",
                Tipo = _context.TipoProductos.FirstOrDefault(),
                Etiquetas = "Arroz,granos,nacional",
                Precio = 25.00,
                UnidadDeMedida = _context.UnidadesDeMedida.FirstOrDefault()
            });

            await _context.SaveChangesAsync();
        }
    }
}
