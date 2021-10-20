using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.Users;
using CookBookApp.ApplicationServices.API.ErrorHandling;
using CookBookApp.DataAccess.CQRS;
using CookBookApp.DataAccess.CQRS.Queries.User;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Handlers.User
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersRequest, GetAllUsersResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetAllUsersHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetAllUsersResponse> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            //if (request.UserRole != "admin")
            //{
            //    return new GetAllUsersResponse()
            //    {
            //        Error = new Domain.ErrorModel(ErrorType.Unauthorized)
            //    };
            //}
            var query = new GetAllUsersQuery();
            var users = queryExecutor.Execute(query).Result;

            if (users == null)
            {
                return new GetAllUsersResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedUsers = this.mapper.Map<List<Domain.Models.User>>(users);

            return new GetAllUsersResponse()
            {
                Data = mappedUsers.ToList()
            };
        }
    }
}
