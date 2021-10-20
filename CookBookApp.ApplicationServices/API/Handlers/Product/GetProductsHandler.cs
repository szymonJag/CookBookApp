using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain;
using CookBookApp.ApplicationServices.API.ErrorHandling;
using CookBookApp.DataAccess.CQRS;
using CookBookApp.DataAccess.CQRS.Queries;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsRequest, GetProductsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetProductsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRole == null)
            {
                return new GetProductsResponse()
                {
                    Error = new ErrorModel(ErrorType.NotAuthenticated)
                };
            }

            var query = new GetProductsQuery()
            {
                Name = request.Name
            };
            var products = await this.queryExecutor.Execute(query);

            if (products == null)
            {
                return new GetProductsResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            return new GetProductsResponse()
            {
                Data = this.mapper.Map<List<Domain.Models.Product>>(products).ToList()
            };

        }
    }
}
