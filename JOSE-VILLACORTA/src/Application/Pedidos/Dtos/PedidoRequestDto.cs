using xyzboutique.Application.Pedidos.Dtos;

namespace xyzboutique.Web.Models;

public class PedidoRequestDto
{
    public int? Id { get; set; }

    public int? NumeroDePedido { get; set; }

    public List<DetallePedidoDto>? ListaDeProductos { get; set; }

    public DateTime? FechaDePedido { get; set; }

    public DateTime? FechaDeRecepcion { get; set; }

    public DateTime? FechaDeDespacho { get; set; }

    public DateTime? FechaDeEntrega { get; set; }

    public int? VendedorId { get; set; }

    public int? RepartidorId { get; set; }

    public int? Estado { get; set; }

}
