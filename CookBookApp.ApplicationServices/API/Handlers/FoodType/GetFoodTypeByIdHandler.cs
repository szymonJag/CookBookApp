using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.FoodTypes;
using CookBookApp.ApplicationServices.API.ErrorHandling;
using CookBookApp.DataAccess.CQRS;
using CookBookApp.DataAccess.CQRS.Queries.FoodType;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Handlers.FoodType
{
    public class GetFoodTypeByIdHandler : IRequestHandler<GetFoodTypeByIdRequest, GetFoodTypeByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetFoodTypeByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetFoodTypeByIdResponse> Handle(GetFoodTypeByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRole != "admin")
            {
                return new GetFoodTypeByIdResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetFoodTypeByIdQuery()
            {
                FoodTypeId = request.FoodTypeId
            };
            var foodType = this.queryExecutor.Execute(query).Result;

            if (foodType == null)
            {
                return new GetFoodTypeByIdResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }

            return new GetFoodTypeByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.FoodType>(foodType)
            };
        }
    }
}
