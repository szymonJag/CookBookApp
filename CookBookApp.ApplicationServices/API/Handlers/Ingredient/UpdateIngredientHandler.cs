using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.Ingredients;
using CookBookApp.ApplicationServices.API.ErrorHandling;
using CookBookApp.DataAccess.CQRS;
using CookBookApp.DataAccess.CQRS.Commands.Ingredient;
using CookBookApp.DataAccess.CQRS.Queries.Ingredient;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Handlers.Ingredient
{
    public class UpdateIngredientHandler : IRequestHandler<UpdateIngredientRequest, UpdateIngredientResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public UpdateIngredientHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }
        public async Task<UpdateIngredientResponse> Handle(UpdateIngredientRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRole != "admin")
            {
                return new UpdateIngredientResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetIngredientByIdQuery()
            {
                IngredientId = request.Id
            };

            var ingredientFromDb = this.queryExecutor.Execute(query).Result;
            
            if (ingredientFromDb == null)
            {
                return new UpdateIngredientResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }

            ingredientFromDb = this.mapper.Map<DataAccess.Entities.Ingredient>(request);
            
            var command = new UpdateIngredientCommand()
            {
                Parameter = ingredientFromDb
            };

            var updated = this.commandExecutor.Execute(command).Result;

            return new UpdateIngredientResponse()
            {
                Data = this.mapper.Map<Domain.Models.Ingredient>(updated)
            };
        }
    }
}
