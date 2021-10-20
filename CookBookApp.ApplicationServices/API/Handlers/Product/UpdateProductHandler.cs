using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.Products;
using CookBookApp.ApplicationServices.API.ErrorHandling;
using CookBookApp.DataAccess.CQRS;
using CookBookApp.DataAccess.CQRS.Commands;
using CookBookApp.DataAccess.CQRS.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Handlers.Products
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public UpdateProductHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }
        public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRole != "admin")
            {
                return new UpdateProductResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetProductByIdQuery()
            {
                Id = request.ProductId
            };
            
            var productToUpdate = this.queryExecutor.Execute(query).Result;

            if (productToUpdate == null)
            {
                return new UpdateProductResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }
            productToUpdate = this.mapper.Map<DataAccess.Entities.Product>(request);

            var command = new UpdateProductCommand()
            {
                Parameter = productToUpdate
            };
            
            var updatedProduct = this.commandExecutor.Execute(command).Result;
            
            return new UpdateProductResponse()
            {
                Data = this.mapper.Map<Domain.Models.Product>(updatedProduct)
            };
        }
    }
}
