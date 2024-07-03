namespace xyzboutique.Domain.Entities;

public class UnidadDeMedida : BaseAuditableEntity
{
    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Abreviatura { get; set; }
}
