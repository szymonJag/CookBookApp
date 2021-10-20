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
    public class DeleteIngredientHandler : IRequestHandler<DeleteIngredientRequest, DeleteIngredientResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public DeleteIngredientHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }
        public async Task<DeleteIngredientResponse> Handle(DeleteIngredientRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRole != "admin")
            {
                return new DeleteIngredientResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetIngredientByIdQuery()
            {
                IngredientId = request.IngredientId
            };
            var ingredientFromDb = this.queryExecutor.Execute(query);

            if (ingredientFromDb == null)
            {
                return new DeleteIngredientResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }

            var command = new DeleteIngredientCommand()
            {
                Parameter = ingredientFromDb.Result
            };

            var deletedIngredient = this.commandExecutor.Execute(command).Result;

            return new DeleteIngredientResponse()
            {
                Data = this.mapper.Map<Domain.Models.Ingredient>(deletedIngredient)
            };
        }
    }
}
