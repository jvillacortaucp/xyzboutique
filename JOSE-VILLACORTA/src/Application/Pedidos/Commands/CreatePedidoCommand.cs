using xyzboutique.Application.Common.Interfaces;
using xyzboutique.Application.Mappers;
using xyzboutique.Web.Models;

namespace xyzboutique.Application.Pedidos.Commands;

public class CreatePedidoCommand(PedidoRequestDto request) : BasePedidoCommand<int>(request);

public class CreatePedidoCommandHandler(IApplicationDbContext context) 
    : IRequestHandler<CreatePedidoCommand, int>
{   
    public async Task<int> Handle(CreatePedidoCommand request, CancellationToken cancellationToken)
    {
        var pedido = PedidosMapper.MapToEntity(request);
        context.Pedidos.Add(pedido);
        await context.SaveChangesAsync(cancellationToken);
        return pedido.Id;
    }

    public class CreatePedidoCommandValidator : BasePedidoCommandValidator<CreatePedidoCommand, int>
    {
        public CreatePedidoCommandValidator() : base() => RuleFor(command => command.Request.NumeroDePedido).GreaterThan(0);
    }
}
