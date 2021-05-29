using MEChallenge.Application.Core;
using MediatR;

namespace MEChallenge.Application.Commands.Pedido
{
    public class PedidoDeleteCommand : IRequest<Response>
    {
        public int IdPedido { get; set; }
    }
}
