using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain;
using CookBookApp.ApplicationServices.API.ErrorHandling;
using CookBookApp.DataAccess.CQRS;
using CookBookApp.DataAccess.CQRS.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdRequest, GetProductByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetProductByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetProductByIdResponse> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRole != "admin")
            {
                return new GetProductByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }
            var query = new GetProductByIdQuery()
            {
                Id = request.ProductId
            };
            var product = await this.queryExecutor.Execute(query);

            if(product == null)
            {
                return new GetProductByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedProduct = this.mapper.Map<Domain.Models.Product>(product);
            var response = new GetProductByIdResponse()
            {
                Data = mappedProduct
            };
            return response;
        }
    }
}
