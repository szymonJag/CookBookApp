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
    public class GetRecipeByIdHandler : IRequestHandler<GetRecipeByIdRequest, GetRecipeByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetRecipeByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetRecipeByIdResponse> Handle(GetRecipeByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRole != "admin")
            {
                return new GetRecipeByIdResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetRecipeByIdQuery()
            {
                RecipeId = request.RecipeId
            };
            var recipeFromDb = this.queryExecutor.Execute(query).Result;

            if (recipeFromDb == null)
            {
                return new GetRecipeByIdResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }

            return new GetRecipeByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.Recipe>(recipeFromDb)
            };
        }
    }
}
