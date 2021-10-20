using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.RecipeFoodType;
using CookBookApp.ApplicationServices.API.ErrorHandling;
using CookBookApp.DataAccess.CQRS;
using CookBookApp.DataAccess.CQRS.Queries.RecipeFoodType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Handlers.RecipeFoodType
{
    public class GetRecipeFoodTypeByIdHandler : IRequestHandler<GetRecipeFoodTypeByIdRequest, GetRecipeFoodTypeByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetRecipeFoodTypeByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetRecipeFoodTypeByIdResponse> Handle(GetRecipeFoodTypeByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRole != "admin")
            {
                return new GetRecipeFoodTypeByIdResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotAuthenticated)
                };
            }

            var query = new GetRecipeFoodTypeByIdQuery()
            {
                RecipeFoodTypeId = request.RecipeFoodTypeId
            };
            var recipeFoodType = this.queryExecutor.Execute(query).Result;

            if (recipeFoodType == null)
            {
                return new GetRecipeFoodTypeByIdResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }

            return new GetRecipeFoodTypeByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.RecipeFoodType>(recipeFoodType)
            };
        }
    }
}
