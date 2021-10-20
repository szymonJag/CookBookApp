using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.UserRoles;
using CookBookApp.ApplicationServices.API.ErrorHandling;
using CookBookApp.DataAccess.CQRS;
using CookBookApp.DataAccess.CQRS.Commands.UserRole;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Handlers.UserRole
{
    public class AddUserRolesHandler : IRequestHandler<AddUserRolesRequest, AddUserRolesResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddUserRolesHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<AddUserRolesResponse> Handle(AddUserRolesRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRole != "admin")
            {
                return new AddUserRolesResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.Unauthorized)
                };
            }
            
            var userFromRequest = this.mapper.Map<DataAccess.Entities.UserRole>(request);
            var command = new AddUserRolesCommand()
            {
                Parameter = userFromRequest
            };
            var userAddedToDb = this.commandExecutor.Execute(command).Result;

            return new AddUserRolesResponse()
            {
                Data = this.mapper.Map<Domain.Models.UserRole>(userAddedToDb)
            };
        }
    }
}
