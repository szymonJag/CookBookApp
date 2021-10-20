using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.Units;
using CookBookApp.ApplicationServices.API.ErrorHandling;
using CookBookApp.DataAccess.CQRS;
using CookBookApp.DataAccess.CQRS.Commands.Unit;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Handlers.Unit
{
    public class AddUnitHandler : IRequestHandler<AddUnitRequest, AddUnitResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddUnitHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<AddUnitResponse> Handle(AddUnitRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRole != "admin")
            {
                return new AddUnitResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.Unauthorized)
                };
            }

            var unitToDb = this.mapper.Map<DataAccess.Entities.Unit>(request);
            var command = new AddUnitCommand()
            {
                Parameter = unitToDb
            };
            var productFromDb = await this.commandExecutor.Execute(command);

            if (productFromDb == null)
            {
                return new AddUnitResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.ValidationError)
                };
            }

            return new AddUnitResponse()
            {
                Data = this.mapper.Map<Domain.Models.Unit>(productFromDb)
            };
        }
    }
}
