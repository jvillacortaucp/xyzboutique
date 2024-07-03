namespace xyzboutique.Domain.Entities;

public class Producto : BaseAuditableEntity
{
    public string? SKU { get; set; }

    public string? Nombre { get; set; }

    public TipoProducto? Tipo { get; set; }

    public string? Etiquetas { get; set; }

    public double? Precio { get; set; }

    public UnidadDeMedida? UnidadDeMedida { get; set; }




}
