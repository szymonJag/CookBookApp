using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain;
using CookBookApp.ApplicationServices.API.ErrorHandling;
using CookBookApp.DataAccess;
using CookBookApp.DataAccess.CQRS;
using CookBookApp.DataAccess.CQRS.Queries.Ingredient;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Handlers
{
    public class GetIngredientsHandler : IRequestHandler<GetIngredientsRequest, GetIngredientsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetIngredientsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetIngredientsResponse> Handle(GetIngredientsRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRole == null)
            {
                return new GetIngredientsResponse()
                {
                    Error = new ErrorModel(ErrorType.NotAuthenticated)
                };
            }

            var query = new GetIngredientsQuery();
            var ingredientsFromDb = this.queryExecutor.Execute(query).Result;

            if (ingredientsFromDb == null)
            {
                return new GetIngredientsResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            return new GetIngredientsResponse()
            {
                Data = this.mapper.Map<List<Domain.Models.Ingredient>>(ingredientsFromDb)
            };
        }
    }
}
