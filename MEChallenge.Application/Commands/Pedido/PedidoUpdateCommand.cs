using MEChallenge.Application.Core;
using MEChallenge.Application.Domain.Models;
using MediatR;
using System.Collections.Generic;

namespace MEChallenge.Application.Commands.Pedido
{
    public class PedidoUpdateCommand : IRequest<Response>
    {
        public int IdPedido { get; set; }
        public List<ItemMO> Itens { get; set; }
    }
}
