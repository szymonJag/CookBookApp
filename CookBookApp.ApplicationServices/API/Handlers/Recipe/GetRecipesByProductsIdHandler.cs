using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.Recipes;
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
    public class GetRecipesByProductsIdHandler : IRequestHandler<GetRecipesByProductsIdRequest, GetRecipesByProductsIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetRecipesByProductsIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetRecipesByProductsIdResponse> Handle(GetRecipesByProductsIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetRecipesByProductsIdQuery()
            {
                ProductsId = request.ProductsId
            };

            var listOfSearchedRecipes = this.queryExecutor.Execute(query).Result;

            return new GetRecipesByProductsIdResponse()
            {
                Data = this.mapper.Map<List<Domain.Models.Recipe>>(listOfSearchedRecipes)
            };
        }
    }
}
