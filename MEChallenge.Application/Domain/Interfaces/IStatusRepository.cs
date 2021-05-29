using MEChallenge.Application.Core.Responses.Status;
using MEChallenge.Application.Queries.Status;
using System.Threading.Tasks;

namespace MEChallenge.Application.Domain.Interfaces
{
    public interface IStatusRepository
    {
        Task<StatusResponse> GetStatus(StatusQuery qry);
    }
}
