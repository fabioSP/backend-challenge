using MEChallenge.Application.Core.Responses.Status;
using MEChallenge.Application.Domain.Enums;
using MEChallenge.Application.Domain.Interfaces;
using MEChallenge.Application.Persistence;
using MEChallenge.Application.Queries.Status;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MEChallenge.Application.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly Context _context;

        public StatusRepository(Context context)
        {
            _context = context;
        }

        public async Task<StatusResponse> GetStatus(StatusQuery qry)
        {
            int pedidoId;
            var status = new List<string>();
            if (!Int32.TryParse(qry.Pedido, out pedidoId))
            {
                status.Add(StatusEnum.CODIGO_PEDIDO_INVALIDO.ToString());
                return new StatusResponse(qry.Pedido, status);
            }

            var pedido = await _context.Pedido.Where(p => p.Id == pedidoId).ToListAsync();
            var produtosVal = await _context.Produto.Where(p => pedido.Select(a => a.IdProduto).Contains(p.Id)).Select(p => p.PrecoUnitario).SumAsync();

            var retornos = new List<dynamic>();

            if (pedido.Count == 0) status.Add(StatusEnum.CODIGO_PEDIDO_INVALIDO.ToString());
            if (pedido.Count > 0 && qry.Status == "REPROVADO") status.Add(StatusEnum.REPROVADO.ToString());
            if (pedido.Count > 0 && qry.ItensAprovados == pedido.Count && produtosVal == qry.ValorAprovado && qry.Status == "APROVADO") status.Add(StatusEnum.APROVADO.ToString());
            if (pedido.Count > 0 && qry.ValorAprovado < produtosVal && qry.Status == "APROVADO") status.Add(StatusEnum.APROVADO_VALOR_A_MENOR.ToString());
            if (pedido.Count > 0 && qry.ItensAprovados < pedido.Count && qry.Status == "APROVADO") status.Add(StatusEnum.APROVADO_QTD_A_MENOR.ToString());
            if (pedido.Count > 0 && qry.ValorAprovado > produtosVal && qry.Status == "APROVADO") status.Add(StatusEnum.APROVADO_VALOR_A_MAIOR.ToString());
            if (pedido.Count > 0 && qry.ItensAprovados > pedido.Count && qry.Status == "APROVADO") status.Add(StatusEnum.APROVADO_QTD_A_MAIOR.ToString());

            return new StatusResponse(qry.Pedido, status);
        }
    }
}
