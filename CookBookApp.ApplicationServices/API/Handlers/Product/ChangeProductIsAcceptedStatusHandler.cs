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

namespace CookBookApp.ApplicationServices.API.Handlers.Product
{
    public class ChangeProductIsAcceptedStatusHandler : IRequestHandler<ChangeProductIsAcceptedStatusRequest, ChangeProductIsAcceptedStatusResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public ChangeProductIsAcceptedStatusHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }
        public async Task<ChangeProductIsAcceptedStatusResponse> Handle(ChangeProductIsAcceptedStatusRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRole != "admin")
            {
                return new ChangeProductIsAcceptedStatusResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetProductByIdQuery()
            {
                Id = request.ProductId
            };

            var product = this.queryExecutor.Execute(query).Result;

            product.IsAcceptedByAdmin = product.IsAcceptedByAdmin ? product.IsAcceptedByAdmin = false : product.IsAcceptedByAdmin = true;

            var command = new UpdateProductCommand()
            {
                Parameter = product
            };

            var updatedProduct = this.commandExecutor.Execute(command).Result;

            return new ChangeProductIsAcceptedStatusResponse()
            {
                Data = this.mapper.Map<Domain.Models.Product>(updatedProduct)
            };
        }
    }
}
