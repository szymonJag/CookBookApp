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
    public class GetRecipesHandler : IRequestHandler<GetRecipesRequest, GetRecipesResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetRecipesHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<GetRecipesResponse> Handle(GetRecipesRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRole == null)
            {
                return new GetRecipesResponse()
                {
                    Error = new ErrorModel(ErrorType.NotAuthenticated)
                };
            }

            var query = new GetRecipesQuery();
            var recipes = queryExecutor.Execute(query).Result;

            if (recipes == null)
            {
                return new GetRecipesResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            return new GetRecipesResponse()
            {
                Data = this.mapper.Map<List<Domain.Models.Recipe>>(recipes).ToList()
            };
        }
    }
}
