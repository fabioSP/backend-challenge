using MEChallenge.Application.Commands.Pedido;
using MEChallenge.Application.Domain.Entities;
using MEChallenge.Application.Domain.Interfaces;
using MEChallenge.Application.Persistence;
using MEChallenge.Application.Queries.Pedidos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MEChallenge.Application.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly Context _context;

        public PedidoRepository(Context context)
        {
            _context = context;
        }

        public async Task<int> Add(PedidoAddCommand cmd)
        {
            var itens = (from i in cmd.Itens
                         join p in _context.Produto on i.Descricao equals p.Descricao
                         select new
                         {
                             IdProduto = p.Id,
                             i.PrecoUnitario,
                             i.Qtd
                         }).ToList();

            foreach (dynamic item in itens)
            {
                _context.Pedido.Add(new PedidoMO(item.IdProduto, item.Qtd));
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(PedidoDeleteCommand cmd)
        {
            var pedido = await _context.Pedido.Where(p => p.Id == cmd.IdPedido).ToListAsync();

            foreach(PedidoMO item in pedido)
            {
                _context.Pedido.Remove(item);
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<dynamic> GetById(PedidoGetByIdQuery qry)
        {
            var itens = await _context.Pedido.Where(p => p.Id == qry.Id).ToListAsync();
            var pedido = itens.Select(a => a.Id).FirstOrDefault();
            var newList = new List<dynamic>();

            foreach(PedidoMO item in itens)
            {
                var produto = await _context.Produto.Where(p => p.Id == item.IdProduto).Select(p => new { p.Descricao, p.PrecoUnitario }).FirstOrDefaultAsync();
                newList.Add(new { produto.Descricao, produto.PrecoUnitario, item.Quantidade });
            }


            return new { pedido = pedido, itens = newList };
        }

        public async Task<List<dynamic>> List()
        {
            var itens = await _context.Pedido.ToListAsync();
            var pedidos = await _context.Pedido.GroupBy(p => p.Id).Select(p => p.Key).ToListAsync();
            var list = new List<dynamic>();

            foreach (int l in pedidos)
            {
                var produtos = itens.Where(p => p.Id == l).Select(p => new { p.Id, p.Quantidade }).ToList();
                list.Add(await GetById(new PedidoGetByIdQuery(l)));
            }

            return list;
        }

        public async Task<int> Update(PedidoUpdateCommand cmd)
        {
            var pedido = await _context.Pedido.Where(p => p.Id == cmd.IdPedido).ToListAsync();
            var itens = (from i in cmd.Itens
                        join p in _context.Produto on i.Descricao equals p.Descricao
                        select new
                        {
                            IdProduto = p.Id,
                            i.PrecoUnitario,
                            i.Qtd
                        }).ToList();

            if (pedido.Count < cmd.Itens.Count)
            {
                var remove = pedido.Where(p => !itens.Select(i => i.IdProduto).Contains(p.IdProduto)).ToList();

                _context.Pedido.RemoveRange(remove);
            }

            foreach(dynamic item in itens)
            {
                PedidoMO p = new PedidoMO(cmd.IdPedido, item.IdProduto, item.Qtd);

                _context.Update(p);
            }

            return await _context.SaveChangesAsync();
        }
    }
}
