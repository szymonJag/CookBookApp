using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.Products;
using CookBookApp.ApplicationServices.API.ErrorHandling;
using CookBookApp.DataAccess.CQRS;
using CookBookApp.DataAccess.CQRS.Queries.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Handlers.Product
{
    public class GetAllProductsAddedByUserHandler : IRequestHandler<GetAllProductsAddedByUserRequest, GetAllProductsAddedByUserResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetAllProductsAddedByUserHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetAllProductsAddedByUserResponse> Handle(GetAllProductsAddedByUserRequest request, CancellationToken cancellationToken)
        {
            var query = new GetAllProductsAddedByUserQuery()
            {
                Username = request.Username
            };

            var products = await this.queryExecutor.Execute(query);

            if (products == null)
            {
                return new GetAllProductsAddedByUserResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }

            return new GetAllProductsAddedByUserResponse()
            {
                Data = this.mapper.Map<List<Domain.Models.Product>>(products)
            };
        }
    }
}
