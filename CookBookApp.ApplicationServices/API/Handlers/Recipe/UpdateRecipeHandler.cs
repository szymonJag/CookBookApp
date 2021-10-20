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
    public class UpdateRecipeHandler : IRequestHandler<UpdateRecipeRequest, UpdateRecipeResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public UpdateRecipeHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<UpdateRecipeResponse> Handle(UpdateRecipeRequest request, CancellationToken cancellationToken)
        {
            var query = new GetRecipeByIdQuery()
            {
                RecipeId = request.RecipeId
            };
            var recipeToUpdate = this.queryExecutor.Execute(query).Result;

            if (recipeToUpdate == null)
            {
                return new UpdateRecipeResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }

            if (request.UserRole != "admin" || request.UserRole != recipeToUpdate.Author)
            {
                return new UpdateRecipeResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.Unauthorized)
                };
            }

            recipeToUpdate = this.mapper.Map<DataAccess.Entities.Recipe>(request);

            var command = new UpdateRecipeCommand()
            {
                Parameter = recipeToUpdate
            };

            var updated = this.commandExecutor.Execute(command).Result;

            return new UpdateRecipeResponse()
            {
                Data = this.mapper.Map<Domain.Models.Recipe>(updated)
            };
        }
    }
}
