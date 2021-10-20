using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain;
using CookBookApp.ApplicationServices.API.ErrorHandling;
using CookBookApp.DataAccess.CQRS;
using CookBookApp.DataAccess.CQRS.Queries;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Handlers
{
    public class GetUnitsHandler : IRequestHandler<GetUnitsRequest, GetUnitsResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetUnitsHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetUnitsResponse> Handle(GetUnitsRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRole == null)
            {
                return new GetUnitsResponse()
                {
                    Error = new ErrorModel(ErrorType.NotAuthenticated)
                };
            }

            var query = new GetUnitsQuery();
            var units = queryExecutor.Execute(query).Result;

            if (units == null)
            {
                return new GetUnitsResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            return new GetUnitsResponse()
            {
                Data = this.mapper.Map<List<Domain.Models.Unit>>(units).ToList()
            };

        }
    }
}
