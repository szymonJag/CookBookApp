using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.Products;
using CookBookApp.ApplicationServices.API.ErrorHandling;
using CookBookApp.DataAccess.CQRS;
using CookBookApp.DataAccess.CQRS.Queries.Product;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Handlers.Product
{
    public class GetUnacceptedProductsHandler : IRequestHandler<GetUnacceptedProductsRequest, GetUnacceptedProductsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetUnacceptedProductsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetUnacceptedProductsResponse> Handle(GetUnacceptedProductsRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRole != "admin")
            {
                return new GetUnacceptedProductsResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotAuthenticated)
                };
            }

            var query = new GetUnacceptedProductsQuery();
            var unacceptedProducts = this.queryExecutor.Execute(query).Result;

            return new GetUnacceptedProductsResponse()
            {
                Data = this.mapper.Map<List<Domain.Models.Product>>(unacceptedProducts)
            };
        }
    }
}
