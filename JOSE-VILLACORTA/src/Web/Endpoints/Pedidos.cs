using xyzboutique.Application.Pedidos.Commands;
using xyzboutique.Application.TodoLists.Commands.UpdateTodoList;

namespace xyzboutique.Web.Endpoints;

public class Pedidos : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapPost(CreatePedido);
    }

    public async Task<int> CreatePedido(ISender sender, CreatePedidoCommand command)
    {
        return await sender.Send(command);
    }

    

    
}
