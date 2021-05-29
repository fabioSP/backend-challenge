using System.Collections.Generic;

namespace MEChallenge.Application.Core.Responses.Status
{
    public class StatusResponse
    {
        public StatusResponse(string pedido, List<string> status)
        {
            Pedido = pedido;
            Status = status;
        }

        public string Pedido { get; set; }
        public List<string> Status { get; set; }
    }
}
