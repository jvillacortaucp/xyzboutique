using System.Net;
using System.Xml.Linq;
using xyzboutique.Application.Common.Interfaces;
using xyzboutique.Application.Mappers;
using xyzboutique.Domain.Entities;
using xyzboutique.Domain.Enums;
using xyzboutique.Web.Models;

namespace xyzboutique.Application.Pedidos.Commands;

public class UpdateEstadoPedidoCommand : IRequest
{
    public int IdPedido { get; set; }
    public int Estado { get; set; }
}

public class UpdateEstadoPedidoCommandHandler(IApplicationDbContext context)
    : IRequestHandler<UpdateEstadoPedidoCommand>
{
    public async Task Handle(UpdateEstadoPedidoCommand request, CancellationToken cancellationToken)
    {
        var pedidoActual = context.Pedidos
            .FirstOrDefault(of => of.Id == request.IdPedido);
        if (pedidoActual == null)
            throw new NotFoundException("Id", "OfertaLaboral");        

        if(pedidoActual.Estado > request.Estado )
            throw new HttpRequestException("No se puede cambiar el estado a un estado menor");

        pedidoActual.Estado = request.Estado;    
        UpdateEstadoPedidoContext(pedidoActual);     
        await context.SaveChangesAsync(cancellationToken);
    }

    private void UpdateEstadoPedidoContext(Pedido pedido)
    {
        var hoy = DateTime.Now;
        switch (pedido.Estado)
        {
            case (int)EnumEstadoPedido.Por_Atender:
                pedido.FechaDePedido = hoy;
                break;
            case (int)EnumEstadoPedido.En_Proceso:
                pedido.FechaDeRecepcion = hoy;
                break;
            case (int)EnumEstadoPedido.En_Delivery:
                pedido.FechaDeDespacho = hoy;
                break;
            case (int)EnumEstadoPedido.Recibido:
                pedido.FechaDeEntrega = hoy;
                break;
        }
        context.Pedidos.Update(pedido);
    }
}

public class UpdateOfferStatusCommandValidator : AbstractValidator<UpdateEstadoPedidoCommand>
{
    public UpdateOfferStatusCommandValidator() : base()
    {
        RuleFor(v => v.Estado).GreaterThanOrEqualTo(0).NotNull();
        RuleFor(v => v.Estado).LessThan(5).NotNull();
    }
}
