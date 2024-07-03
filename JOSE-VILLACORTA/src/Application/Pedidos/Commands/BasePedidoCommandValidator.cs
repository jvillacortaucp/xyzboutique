namespace xyzboutique.Application.Pedidos.Commands;

public class BasePedidoCommandValidator<TCommand, TResult> : AbstractValidator<TCommand> where TCommand : BasePedidoCommand<TResult>
{
    public BasePedidoCommandValidator()
    {
        RuleFor(command => command.Request.ListaDeProductos)
            .NotEmpty()
            .NotNull();
        RuleFor(command => command.Request.FechaDePedido).NotNull();
    }
}
