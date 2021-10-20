using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.Recipes;
using CookBookApp.ApplicationServices.API.ErrorHandling;
using CookBookApp.DataAccess.CQRS;
using CookBookApp.DataAccess.CQRS.Queries.Recipe;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Handlers.Recipe
{
    public class GetRandomRecipeHandler : IRequestHandler<GetRandomRecipeRequest, GetRandomRecipeResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetRandomRecipeHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetRandomRecipeResponse> Handle(GetRandomRecipeRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRole == null)
            {
                return new GetRandomRecipeResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotAuthenticated)
                };
            }
            var query = new GetRandomRecipeQuery();
            var randomRecipe = this.queryExecutor.Execute(query).Result;

            return new GetRandomRecipeResponse()
            {
                Data = this.mapper.Map<Domain.Models.Recipe>(randomRecipe)
            };
        }
    }
}
