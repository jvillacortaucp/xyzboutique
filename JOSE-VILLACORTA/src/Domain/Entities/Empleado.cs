namespace xyzboutique.Domain.Entities;

public class Empleado : BaseAuditableEntity
{
    public string? Nombre { get; set; }

    public string? CodigoTrabajador { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Telefono { get; set; }

    public string? Puesto { get; set; }

}
