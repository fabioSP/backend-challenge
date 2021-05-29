using MEChallenge.Application.Core;
using MediatR;

namespace MEChallenge.Application.Queries.Pedidos
{
    public class PedidoGetByIdQuery : IRequest<Response>
    {
        public PedidoGetByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
