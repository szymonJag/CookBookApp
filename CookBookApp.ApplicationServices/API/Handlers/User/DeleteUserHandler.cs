using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.Users;
using CookBookApp.ApplicationServices.API.ErrorHandling;
using CookBookApp.DataAccess.CQRS;
using CookBookApp.DataAccess.CQRS.Commands.Users;
using CookBookApp.DataAccess.CQRS.Queries.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Handlers.User
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public DeleteUserHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }
        public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserByIdQuery()
            {
                UserId = request.UserId
            };
            var user = await this.queryExecutor.Execute(query);

            if (user == null)
            {
                return new DeleteUserResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }

            var command = new DeleteUserCommand()
            {
                Parameter = user
            };

            var deletedUser = await this.commandExecutor.Execute(command);

            return new DeleteUserResponse()
            {
                Data = this.mapper.Map<Domain.Models.User>(deletedUser)
            };
        }
    }
}
