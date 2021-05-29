using MEChallenge.Application.Commands.Pedido;
using MEChallenge.Application.Queries.Pedidos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MEChallenge.Application.Domain.Interfaces
{
    public interface IPedidoRepository
    {
        Task<List<dynamic>> List();
        Task<dynamic> GetById(PedidoGetByIdQuery qry);
        Task<int> Add(PedidoAddCommand cmd);
        Task<int> Update(PedidoUpdateCommand cmd);
        Task<int> Delete(PedidoDeleteCommand cmd);
    }
}
