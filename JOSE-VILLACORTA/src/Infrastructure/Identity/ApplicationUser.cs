using Microsoft.AspNetCore.Identity;

namespace xyzboutique.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public string? Nombre { get; set; }

    public string? CodigoTrabajador { get; set; }

    public string? Telefono { get; set; }

    public string? Puesto { get; set; }

}
