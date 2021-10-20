using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.Ingredients;
using CookBookApp.ApplicationServices.API.ErrorHandling;
using CookBookApp.DataAccess.CQRS;
using CookBookApp.DataAccess.CQRS.Commands.Ingredient;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Handlers.Ingredient
{
    public class AddIngredientHandler : IRequestHandler<AddIngredientRequest, AddIngredientResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddIngredientHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<AddIngredientResponse> Handle(AddIngredientRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRole == null)
            {
                return new AddIngredientResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.Unauthorized)
                };
            }

            var ingredient = this.mapper.Map<DataAccess.Entities.Ingredient>(request);
            
            if (ingredient.Product.IsAcceptedByAdmin != true)
            {
                return new AddIngredientResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.UnsupportedMediaType)
                };
            }

            var command = new AddIngredientCommand()
            {
                Parameter = ingredient
            };

            var ingredientFromDb = this.commandExecutor.Execute(command).Result;

            if(ingredientFromDb == null)
            {
                return new AddIngredientResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.ValidationError)
                };
            }

            return new AddIngredientResponse()
            {
                Data = this.mapper.Map<Domain.Models.Ingredient>(ingredientFromDb)
            };
        }
    }
}
