using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.RecipeFoodType;
using CookBookApp.ApplicationServices.API.ErrorHandling;
using CookBookApp.DataAccess.CQRS;
using CookBookApp.DataAccess.CQRS.Commands.RecipeFoodType;
using CookBookApp.DataAccess.CQRS.Queries.RecipeFoodType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Handlers.RecipeFoodType
{
    public class DeleteRecipeFoodTypeHandler : IRequestHandler<DeleteRecipeFoodTypeRequest, DeleteRecipeFoodTypeResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public DeleteRecipeFoodTypeHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }
        public async Task<DeleteRecipeFoodTypeResponse> Handle(DeleteRecipeFoodTypeRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRole != "admin")
            {
                return new DeleteRecipeFoodTypeResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.Unauthorized)
                };
            }
            var query = new GetRecipeFoodTypeByIdQuery()
            {
                RecipeFoodTypeId = request.RecipeFoodTypeId
            };
            var recipeFoodType = this.queryExecutor.Execute(query).Result;

            if (recipeFoodType == null)
            {
                return new DeleteRecipeFoodTypeResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }

            var command = new DeleteRecipeFoodTypeCommand()
            {
                Parameter = recipeFoodType
            };

            var deletedRecipeFoodType = this.commandExecutor.Execute(command).Result;

            return new DeleteRecipeFoodTypeResponse()
            {
                Data = this.mapper.Map<Domain.Models.RecipeFoodType>(deletedRecipeFoodType)
            };
        }
    }
}
