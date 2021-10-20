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
    public class GetAllUserRolesHandler : IRequestHandler<GetAllUserRolesRequest, GetAllUserRolesResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetAllUserRolesHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetAllUserRolesResponse> Handle(GetAllUserRolesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetAllUserRolesQuery();
            var users = this.queryExecutor.Execute(query).Result;

            if (request.UserRole == "user")
            {
                return new GetAllUserRolesResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.Unauthorized)
                };
            }

            var mappedUsers = this.mapper.Map<List<Domain.Models.UserRole>>(users);

            return new GetAllUserRolesResponse()
            {
                Data = mappedUsers.ToList()
            };
        }
    }
}
