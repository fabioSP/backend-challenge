using MEChallenge.Application.Commands.Pedido;
using MEChallenge.Application.Core;
using MEChallenge.Application.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MEChallenge.Application.Handlers.Pedidos
{
    public class AddPedidoHandler : IRequestHandler<PedidoAddCommand, Response>
    {
        private readonly IPedidoRepository _repository;

        public AddPedidoHandler(IPedidoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(PedidoAddCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _repository.Add(request);

                return new Response(result);
            }
            catch (Exception ex)
            {
                return new Response(ex.Message);
            }
        }
    }
}
