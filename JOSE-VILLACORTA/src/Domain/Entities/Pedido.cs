namespace xyzboutique.Domain.Entities;

public class Pedido : BaseAuditableEntity
{
    public int? NumeroDePedido { get; set; }

    public List<DetallePedido>? ListaDeProductos { get; set; }

    public DateTime? FechaDePedido { get; set; }

    public DateTime? FechaDeRecepcion { get; set; }

    public DateTime? FechaDeDespacho { get; set; }

    public DateTime? FechaDeEntrega { get; set; }

    public Empleado? Vendedor { get; set; }

    public Empleado? Repartidor { get; set; }

    public int? Estado { get; set; }

    public int? VendedorId { get; set; }

    public int? RepartidorId { get; set; }

}
