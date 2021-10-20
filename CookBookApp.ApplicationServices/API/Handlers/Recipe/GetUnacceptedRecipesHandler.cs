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
    public class GetUnacceptedRecipesHandler : IRequestHandler<GetUnacceptedRecipesRequest, GetUnacceptedRecipesResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetUnacceptedRecipesHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetUnacceptedRecipesResponse> Handle(GetUnacceptedRecipesRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRole != "admin")
            {
                return new GetUnacceptedRecipesResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetUnacceptedRecipesQuery();
            var unacceptedRecipes = this.queryExecutor.Execute(query).Result;

            return new GetUnacceptedRecipesResponse()
            {
                Data = this.mapper.Map<List<Domain.Models.Recipe>>(unacceptedRecipes)
            };
        }
    }
}
