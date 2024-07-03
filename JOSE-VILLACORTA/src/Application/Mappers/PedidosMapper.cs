using xyzboutique.Application.Pedidos.Commands;
using xyzboutique.Application.Pedidos.Dtos;
using xyzboutique.Domain.Entities;

namespace xyzboutique.Application.Mappers;
public static class PedidosMapper
{
    public static Pedido MapToEntity<T>(BasePedidoCommand<T> pedido){
        Pedido p = new Pedido()
        {
            NumeroDePedido = pedido.Request.NumeroDePedido,
            ListaDeProductos = pedido.Request.ListaDeProductos?.Select(
                detallePedido => new DetallePedido()
                {
                    ProductoId = detallePedido.ProductoId,
                    Cantidad = detallePedido.Cantidad
                }).ToList(),
            FechaDePedido = pedido.Request.FechaDePedido,
            FechaDeRecepcion = pedido.Request.FechaDeRecepcion,
            FechaDeDespacho = pedido.Request.FechaDeDespacho,
            FechaDeEntrega = pedido.Request.FechaDeEntrega,
            RepartidorId = pedido.Request.RepartidorId,
            VendedorId = pedido.Request.VendedorId,
            Estado = pedido.Request.Estado
        }; 
        return p;
    }
       

    
}
