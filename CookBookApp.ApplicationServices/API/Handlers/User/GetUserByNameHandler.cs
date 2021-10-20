using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain;
using CookBookApp.ApplicationServices.API.Domain.Users;
using CookBookApp.ApplicationServices.API.ErrorHandling;
using CookBookApp.DataAccess.CQRS;
using CookBookApp.DataAccess.CQRS.Queries.User;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Handlers.User
{
    public class GetUserByNameHandler : IRequestHandler<GetUserByNameRequest, GetUserByNameResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetUserByNameHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetUserByNameResponse> Handle(GetUserByNameRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRole == null)
            {
                return new GetUserByNameResponse()
                {
                    Error = new ErrorModel(ErrorType.NotAuthenticated)
                };
            }

            var query = new GetUserByNameQuery()
            {
                UserName = request.Name
            };
            var user = this.queryExecutor.Execute(query).Result;

            if (user == null)
            {
                return new GetUserByNameResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            return new GetUserByNameResponse()
            {
                Data = this.mapper.Map<Domain.Models.User>(user)
            };
        }
    }
}
