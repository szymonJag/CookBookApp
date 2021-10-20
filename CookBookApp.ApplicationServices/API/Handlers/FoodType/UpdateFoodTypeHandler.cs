using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.FoodTypes;
using CookBookApp.ApplicationServices.API.ErrorHandling;
using CookBookApp.DataAccess.CQRS;
using CookBookApp.DataAccess.CQRS.Commands.FoodType;
using CookBookApp.DataAccess.CQRS.Queries.FoodType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Handlers.FoodType
{
    public class UpdateFoodTypeHandler : IRequestHandler<UpdateFoodTypeRequest, UpdateFoodTypeResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public UpdateFoodTypeHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }
        public async Task<UpdateFoodTypeResponse> Handle(UpdateFoodTypeRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRole != "admin")
            {
                return new UpdateFoodTypeResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetFoodTypeByIdQuery()
            {
                FoodTypeId = request.FoodTypeId
            };
            var foodType = this.queryExecutor.Execute(query).Result;

            if (foodType == null)
            {
                return new UpdateFoodTypeResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }

            foodType = this.mapper.Map<DataAccess.Entities.FoodType>(request);

            var command = new UpdateFoodTypeCommand()
            {
                Parameter = foodType
            };
            var updatedFoodType = this.commandExecutor.Execute(command).Result;

            return new UpdateFoodTypeResponse()
            {
                Data = this.mapper.Map<Domain.Models.FoodType>(updatedFoodType)
            };
        }
    }
}
