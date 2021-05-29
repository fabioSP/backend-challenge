using MEChallenge.Application.Core;
using MEChallenge.Application.Domain.Interfaces;
using MEChallenge.Application.Queries.Pedidos;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MEChallenge.Application.Handlers.Pedidos
{
    public class ListPedidoHandler : IRequestHandler<PedidoListQuery, Response>
    {
        private readonly IPedidoRepository _repository;

        public ListPedidoHandler(IPedidoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(PedidoListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _repository.List();

                return new Response(result);
            }
            catch(Exception ex)
            {
                return new Response(ex.Message);
            }
        }
    }
}
