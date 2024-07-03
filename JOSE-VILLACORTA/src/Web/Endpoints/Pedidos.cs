using xyzboutique.Application.Pedidos.Commands;

namespace xyzboutique.Web.Endpoints;

public class Pedidos : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapPost(CreatePedido)
            .MapPatch(UpdateEstadoPedido, "{id}");            
    }

    public async Task<IResult> UpdateEstadoPedido(ISender sender, int id, UpdateEstadoPedidoCommand command)
    {
        if (id != command.IdPedido) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<int> CreatePedido(ISender sender, CreatePedidoCommand command)
    {
        return await sender.Send(command);
    }

    

}
