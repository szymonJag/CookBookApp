using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.FoodTypes;
using CookBookApp.ApplicationServices.API.ErrorHandling;
using CookBookApp.DataAccess.CQRS;
using CookBookApp.DataAccess.CQRS.Commands.FoodType;
using CookBookApp.DataAccess.CQRS.Queries.FoodType;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Handlers.FoodType
{
    public class DeleteFoodTypeHandler : IRequestHandler<DeleteFoodTypeRequest, DeleteFoodTypeResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public DeleteFoodTypeHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }
        public async Task<DeleteFoodTypeResponse> Handle(DeleteFoodTypeRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRole != "admin")
            {
                return new DeleteFoodTypeResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetFoodTypeByIdQuery()
            {
                FoodTypeId = request.FoodTypeId
            };
            var foodTypeToDelete = this.queryExecutor.Execute(query).Result;

            if (foodTypeToDelete == null)
            {
                return new DeleteFoodTypeResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }

            var command = new DeleteFoodTypeCommand()
            {
                Parameter = foodTypeToDelete
            };
            var deletedFoodType = this.commandExecutor.Execute(command).Result;

            return new DeleteFoodTypeResponse()
            {
                Data = this.mapper.Map<Domain.Models.FoodType>(deletedFoodType)
            };
        }
    }
}
