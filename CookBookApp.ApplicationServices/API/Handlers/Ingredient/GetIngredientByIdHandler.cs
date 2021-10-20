using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.Ingredients;
using CookBookApp.DataAccess.CQRS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CookBookApp.DataAccess.CQRS.Queries.Ingredient;
using CookBookApp.ApplicationServices.API.ErrorHandling;

namespace CookBookApp.ApplicationServices.API.Handlers.Ingredients
{
    public class GetIngredientByIdHandler : IRequestHandler<GetIngredientByIdRequest, GetIngredientByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetIngredientByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetIngredientByIdResponse> Handle(GetIngredientByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRole != "admin")
            {
                return new GetIngredientByIdResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.Unauthorized)
                };
            }
            var query = new GetIngredientByIdQuery()
            {
                IngredientId = request.IngredientId
            };
            var ingredientFromDb = this.queryExecutor.Execute(query).Result;

            if (ingredientFromDb == null)
            {
                return new GetIngredientByIdResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }

            return new GetIngredientByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.Ingredient>(ingredientFromDb)
            };
        }
    }
}
