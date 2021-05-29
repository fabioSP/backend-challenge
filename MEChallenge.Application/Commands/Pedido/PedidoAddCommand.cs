using MEChallenge.Application.Core;
using MEChallenge.Application.Domain.Models;
using MediatR;
using System.Collections.Generic;

namespace MEChallenge.Application.Commands.Pedido
{
    public class PedidoAddCommand : IRequest<Response>
    {
        public List<ItemMO> Itens { get; set; }
    }
}
