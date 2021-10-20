using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.Recipes;
using CookBookApp.ApplicationServices.API.ErrorHandling;
using CookBookApp.DataAccess.CQRS;
using CookBookApp.DataAccess.CQRS.Commands.Recipe;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Handlers.Recipe
{
    public class AddRecipeHandler : IRequestHandler<AddRecipeRequest, AddRecipeResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddRecipeHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<AddRecipeResponse> Handle(AddRecipeRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRole == null)
            {
                return new AddRecipeResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotAuthenticated)
                };
            }

            var recipeModel = this.mapper.Map<DataAccess.Entities.Recipe>(request);
            recipeModel.Author = request.AuthenticatedUserName;
            recipeModel.IsAcceptedByAdmin = false;

            var command = new AddRecipeCommand()
            {
                Parameter = recipeModel
            };
            var recipe = this.commandExecutor.Execute(command).Result;

            if (recipeModel == null)
            {
                return new AddRecipeResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.ValidationError)
                };
            }

            return new AddRecipeResponse()
            {
                Data = this.mapper.Map<Domain.Models.Recipe>(recipe)
            };
        }
    }
}
