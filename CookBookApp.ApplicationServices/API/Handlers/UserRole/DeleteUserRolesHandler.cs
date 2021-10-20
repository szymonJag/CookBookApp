using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.UserRoles;
using CookBookApp.ApplicationServices.API.ErrorHandling;
using CookBookApp.DataAccess.CQRS;
using CookBookApp.DataAccess.CQRS.Commands.UserRole;
using CookBookApp.DataAccess.CQRS.Queries.UserRole;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Handlers.UserRole
{
    public class DeleteUserRolesHandler : IRequestHandler<DeleteUserRolesRequest, DeleteUserRolesResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public DeleteUserRolesHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }
        public async Task<DeleteUserRolesResponse> Handle(DeleteUserRolesRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRole != "admin")
            {
                return new DeleteUserRolesResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetUserRolesByIdQuery()
            {
                Id = request.UserRoleId
            };
            var user = this.queryExecutor.Execute(query).Result;
            var command = new DeleteUserRolesCommand()
            {
                Parameter = user
            };
            var deletedUser = this.commandExecutor.Execute(command).Result;

            return new DeleteUserRolesResponse()
            {
                Data = this.mapper.Map<Domain.Models.UserRole>(deletedUser)
            };
        }
    }
}
