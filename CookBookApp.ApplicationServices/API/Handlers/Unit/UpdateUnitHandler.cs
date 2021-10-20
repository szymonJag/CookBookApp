using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.Units;
using CookBookApp.ApplicationServices.API.ErrorHandling;
using CookBookApp.DataAccess.CQRS;
using CookBookApp.DataAccess.CQRS.Commands.Unit;
using CookBookApp.DataAccess.CQRS.Queries.Unit;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Handlers.Unit
{
    public class UpdateUnitHandler : IRequestHandler<UpdateUnitRequest, UpdateUnitResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public UpdateUnitHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }
        public async Task<UpdateUnitResponse> Handle(UpdateUnitRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRole != "admin")
            {
                return new UpdateUnitResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetUnitByIdQuery()
            {
                UnitId = request.Id
            };

            var unitToUpdate = this.queryExecutor.Execute(query).Result;

            if (unitToUpdate == null)
            {
                return new UpdateUnitResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }

            unitToUpdate = this.mapper.Map<DataAccess.Entities.Unit>(request);

            var command = new UpdateUnitCommand()
            {
                Parameter = unitToUpdate
            };

            var update = this.commandExecutor.Execute(command);

            return new UpdateUnitResponse()
            {
                Data = this.mapper.Map<Domain.Models.Unit>(update)
            };
        }
    }
}
