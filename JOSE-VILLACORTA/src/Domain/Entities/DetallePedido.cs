namespace xyzboutique.Domain.Entities;

public class DetallePedido : BaseAuditableEntity
{
    public int? ProductoId { get; set; }

    public int? Cantidad { get; set; }

    public Producto? Producto { get; set; }

}
