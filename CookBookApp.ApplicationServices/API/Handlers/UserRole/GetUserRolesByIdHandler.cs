using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.UserRoles;
using CookBookApp.ApplicationServices.API.ErrorHandling;
using CookBookApp.DataAccess.CQRS;
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
    public class GetUserRolesByIdHandler : IRequestHandler<GetUserRolesByIdRequest, GetUserRolesByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetUserRolesByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetUserRolesByIdResponse> Handle(GetUserRolesByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRole != "admin")
            {
                return new GetUserRolesByIdResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetUserRolesByIdQuery()
            {
                Id = request.Id
            };
            var user = this.queryExecutor.Execute(query).Result;

            if (user == null)
            {
                return new GetUserRolesByIdResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }

            return new GetUserRolesByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.UserRole>(user)
            };
        }
    }
}
