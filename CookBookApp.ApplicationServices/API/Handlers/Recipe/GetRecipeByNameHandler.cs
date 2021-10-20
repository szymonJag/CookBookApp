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
    public class GetRecipeByNameHandler : IRequestHandler<GetRecipeByNameRequest, GetRecipeByNameResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetRecipeByNameHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetRecipeByNameResponse> Handle(GetRecipeByNameRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticatedUserName == null)
            {
                return new GetRecipeByNameResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotAuthenticated)
                };
            }

            var query = new GetRecipeByNameQuery()
            {
                RecipeName = request.RecipeName
            };
            var recipe = this.queryExecutor.Execute(query).Result;

            return new GetRecipeByNameResponse()
            {
                Data = this.mapper.Map<Domain.Models.Recipe>(recipe)
            };
        }
    }
}
