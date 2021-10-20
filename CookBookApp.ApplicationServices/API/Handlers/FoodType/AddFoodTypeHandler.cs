using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.FoodTypes;
using CookBookApp.ApplicationServices.API.ErrorHandling;
using CookBookApp.DataAccess.CQRS;
using CookBookApp.DataAccess.CQRS.Commands.FoodType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Handlers.FoodType
{
    public class AddFoodTypeHandler : IRequestHandler<AddFoodTypeRequest, AddFoodTypeResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddFoodTypeHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<AddFoodTypeResponse> Handle(AddFoodTypeRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRole != "admin")
            {
                return new AddFoodTypeResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.Unauthorized)
                };
            }

            var command = new AddFoodTypeCommand()
            {
                Parameter = this.mapper.Map<DataAccess.Entities.FoodType>(request)
            };

            var addedFoodType = this.commandExecutor.Execute(command).Result;

            return new AddFoodTypeResponse()
            {
                Data = this.mapper.Map<Domain.Models.FoodType>(addedFoodType)
            };
        }
    }
}
