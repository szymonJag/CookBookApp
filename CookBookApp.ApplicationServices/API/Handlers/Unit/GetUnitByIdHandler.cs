using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.Units;
using CookBookApp.ApplicationServices.API.ErrorHandling;
using CookBookApp.DataAccess.CQRS;
using CookBookApp.DataAccess.CQRS.Queries.Unit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Handlers.Unit
{
    public class GetUnitByIdHandler : IRequestHandler<GetUnitByIdRequest, GetUnitByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetUnitByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetUnitByIdResponse> Handle(GetUnitByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRole != "admin")
            {
                return new GetUnitByIdResponse()
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
                return new GetUnitByIdResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }

            return new GetUnitByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.Unit>(unitFromDb)
            };
        }
    }
}
