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
    public class ChangeUserRoleHandler : IRequestHandler<ChangeUserRoleRequest, ChangeUserRoleResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public ChangeUserRoleHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }
        public async Task<ChangeUserRoleResponse> Handle(ChangeUserRoleRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserByIdQuery()
            {
                UserId = request.UserId
            };
            var user = await this.queryExecutor.Execute(query);

            if (user == null)
            {
                return new ChangeUserRoleResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }

            //id of admin = 1 | id of user = 2
            user.UserRoleId = user.UserRoleId == 1 ? user.UserRoleId = 2 : user.UserRoleId = 1;

            var command = new UpdateUserCommand()
            {
                Parameter = user
            };

            var updatedUser = await this.commandExecutor.Execute(command);

            return new ChangeUserRoleResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.User>(updatedUser)
            };
        }
    }
}
