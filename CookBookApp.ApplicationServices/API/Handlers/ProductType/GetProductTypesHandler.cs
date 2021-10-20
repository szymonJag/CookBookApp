using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.ProductTypes;
using CookBookApp.ApplicationServices.API.ErrorHandling;
using CookBookApp.DataAccess.CQRS;
using CookBookApp.DataAccess.CQRS.Queries.ProductType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Handlers.ProductType
{
    public class GetProductTypesHandler : IRequestHandler<GetProductTypesRequest, GetProductTypesResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetProductTypesHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetProductTypesResponse> Handle(GetProductTypesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProductTypesQuery();
            var productTypes = await this.queryExecutor.Execute(query);
            
            if (productTypes == null)
            {
                return new GetProductTypesResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }

            return new GetProductTypesResponse()
            {
                Data = this.mapper.Map<List<Domain.Models.ProductType>>(productTypes)
            };
        }
    }
}
