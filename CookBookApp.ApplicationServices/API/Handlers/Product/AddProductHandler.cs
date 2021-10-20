using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain;
using CookBookApp.ApplicationServices.API.ErrorHandling;
using CookBookApp.DataAccess.CQRS;
using CookBookApp.DataAccess.CQRS.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductRequest, AddProductResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddProductHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }
        public async Task<AddProductResponse> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRole == null)
            {
                return new AddProductResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var product = this.mapper.Map<DataAccess.Entities.Product>(request);
            
            product.IsAcceptedByAdmin = false;
            product.Author = request.AuthenticatedUserName;

            var command = new AddProductCommand() { Parameter = product };
            var productFromDb = await this.commandExecutor.Execute(command);

            if (productFromDb == null)
            {
                return new AddProductResponse()
                {
                    Error = new ErrorModel(ErrorType.ValidationError)
                };
            }

            return new AddProductResponse()
            {
                Data = this.mapper.Map<API.Domain.Models.Product>(productFromDb)
            };
        }
    }
}
