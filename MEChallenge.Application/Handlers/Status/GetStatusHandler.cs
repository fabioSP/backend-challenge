using MEChallenge.Application.Core;
using MEChallenge.Application.Domain.Interfaces;
using MEChallenge.Application.Queries.Status;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MEChallenge.Application.Handlers.Status
{
    public class GetStatusHandler : IRequestHandler<StatusQuery, Response>
    {
        private readonly IStatusRepository _repository;

        public GetStatusHandler(IStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(StatusQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _repository.GetStatus(request);

                return new Response(result);
            }
            catch(Exception ex)
            {
                return new Response(ex);
            }
        }
    }
}
