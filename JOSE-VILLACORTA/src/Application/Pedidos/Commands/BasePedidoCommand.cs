using xyzboutique.Application.Common.Interfaces;
using xyzboutique.Application.Pedidos.Dtos;
using xyzboutique.Domain.Entities;
using xyzboutique.Domain.Events;
using xyzboutique.Web.Models;

namespace xyzboutique.Application.Pedidos.Commands;

public class BasePedidoCommand<TResponse>(PedidoRequestDto request) : IRequest<TResponse>
{
    public PedidoRequestDto Request { get; set; } = request;
}
