using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.Recipes;
using CookBookApp.ApplicationServices.API.ErrorHandling;
using CookBookApp.DataAccess.CQRS;
using CookBookApp.DataAccess.CQRS.Commands.Recipe;
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
    public class DeleteRecipeHandler : IRequestHandler<DeleteRecipeRequest, DeleteRecipeResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public DeleteRecipeHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }
        public async Task<DeleteRecipeResponse> Handle(DeleteRecipeRequest request, CancellationToken cancellationToken)
        {
            var query = new GetRecipeByIdQuery() { RecipeId = request.RecipeId };
            var recipeFromDb = this.queryExecutor.Execute(query).Result;

            //jezeli uzytkownik nie jest adminem albo nie jest autorem przepisu to UNAUTHORIZED
            if (request.UserRole != "admin" || recipeFromDb.Author != request.AuthenticatedUserName)
            {
                return new DeleteRecipeResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.Unauthorized)
                };
            }

            if (recipeFromDb == null)
            {
                return new DeleteRecipeResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }

            var command = new DeleteRecipeCommand()
            {
                Parameter = recipeFromDb
            };
            var recipe = this.commandExecutor.Execute(command).Result;

            return new DeleteRecipeResponse()
            {
                Data = this.mapper.Map<Domain.Models.Recipe>(recipe)
            };
        }
    }
}
