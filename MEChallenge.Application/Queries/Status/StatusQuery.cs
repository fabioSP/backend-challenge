using MEChallenge.Application.Core;
using MediatR;

namespace MEChallenge.Application.Queries.Status
{
    public class StatusQuery : IRequest<Response>
    {
        public string Status { get; set; }
        public int ItensAprovados { get; set; }
        public double ValorAprovado { get; set; }
        public string Pedido { get; set; }
    }
}
