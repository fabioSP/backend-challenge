using MEChallenge.Application.Core;
using MediatR;

namespace MEChallenge.Application.Queries.Pedidos
{
    public class PedidoListQuery : IRequest<Response>
    {
        public PedidoListQuery()
        { }
    }
}
