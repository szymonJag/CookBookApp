using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.FoodTypes;
using CookBookApp.ApplicationServices.API.ErrorHandling;
using CookBookApp.DataAccess.CQRS;
using CookBookApp.DataAccess.CQRS.Queries.FoodType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Handlers.FoodType
{
    public class GetFoodTypesHandler : IRequestHandler<GetFoodTypesRequest, GetFoodTypesResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetFoodTypesHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetFoodTypesResponse> Handle(GetFoodTypesRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRole != "admin")
            {
                return new GetFoodTypesResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetFoodTypesQuery();
            var foodTypes = this.queryExecutor.Execute(query).Result;

            return new GetFoodTypesResponse()
            {
                Data = this.mapper.Map<List<Domain.Models.FoodType>>(foodTypes)
            };
        }
    }
}
