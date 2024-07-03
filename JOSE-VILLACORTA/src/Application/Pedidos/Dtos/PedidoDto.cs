namespace xyzboutique.Application.Pedidos.Dtos;

public class PedidoDto
{
    public int Id { get; set; }

    public int? NumeroDePedido { get; set; }

    public List<ProductoDto>? ListaDeProductos { get; set; }

    public DateTime? FechaDePedido { get; set; }

    public DateTime? FechaDeRecepcion { get; set; }

    public DateTime? FechaDeDespacho { get; set; }

    public DateTime? FechaDeEntrega { get; set; }

    public EmpleadoDto? Vendedor { get; set; }

    public EmpleadoDto? Repartidor { get; set; }

    public int? Estado { get; set; }

}
