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
    public class DeleteUnitHandler : IRequestHandler<DeleteUnitRequest, DeleteUnitResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public DeleteUnitHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }
        public async Task<DeleteUnitResponse> Handle(DeleteUnitRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRole != "admin")
            {
                return new DeleteUnitResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetUnitByIdQuery()
            {
                UnitId = request.UnitId
            };

            var unitFromDb = this.queryExecutor.Execute(query).Result;

            if (unitFromDb == null)
            {
                return new DeleteUnitResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }

            var command = new DeleteUnitCommand()
            {
                Parameter = unitFromDb
            };

            var deleted = this.commandExecutor.Execute(command).Result;

            return new DeleteUnitResponse()
            {
                Data = this.mapper.Map<Domain.Models.Unit>(deleted)
            };
        }
    }
}
