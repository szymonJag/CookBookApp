using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.RecipeFoodType;
using CookBookApp.ApplicationServices.API.ErrorHandling;
using CookBookApp.DataAccess.CQRS;
using CookBookApp.DataAccess.CQRS.Commands.RecipeFoodType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Handlers.RecipeFoodType
{
    public class AddRecipeFoodTypeHandler : IRequestHandler<AddRecipeFoodTypeRequest, AddRecipeFoodTypeResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddRecipeFoodTypeHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<AddRecipeFoodTypeResponse> Handle(AddRecipeFoodTypeRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRole != "admin")
            {
                return new AddRecipeFoodTypeResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.Unauthorized)
                };
            }

            var recipeFoodType = this.mapper.Map<DataAccess.Entities.RecipeFoodType>(request);
            var command = new AddRecipeFoodTypeCommand()
            {
                Parameter = recipeFoodType
            };
            var addedRecipeFoodType = this.commandExecutor.Execute(command).Result;

            return new AddRecipeFoodTypeResponse()
            {
                Data = this.mapper.Map<Domain.Models.RecipeFoodType>(addedRecipeFoodType)
            };
        }
    }
}
