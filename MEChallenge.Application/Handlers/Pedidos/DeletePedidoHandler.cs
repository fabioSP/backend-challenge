using MEChallenge.Application.Commands.Pedido;
using MEChallenge.Application.Core;
using MEChallenge.Application.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MEChallenge.Application.Handlers.Pedidos
{
    public class DeletePedidoHandler : IRequestHandler<PedidoDeleteCommand, Response>
    {
        private readonly IPedidoRepository _repository;

        public DeletePedidoHandler(IPedidoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(PedidoDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _repository.Delete(request);

                return new Response(result);
            }
            catch (Exception ex)
            {
                return new Response(ex.Message);
            }
        }
    }
}
