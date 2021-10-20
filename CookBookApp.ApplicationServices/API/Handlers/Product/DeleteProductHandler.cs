using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain;
using CookBookApp.ApplicationServices.API.ErrorHandling;
using CookBookApp.DataAccess.CQRS;
using CookBookApp.DataAccess.CQRS.Commands;
using CookBookApp.DataAccess.CQRS.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, DeleteProductResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public DeleteProductHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }
        public async Task<DeleteProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRole != "admin")
            {
                return new DeleteProductResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }
            var query = new GetProductByIdQuery()
            {
                Id = request.ProductId
            };
            var productToDelete = this.queryExecutor.Execute(query);

            if (productToDelete == null)
            {
                return new DeleteProductResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var command = new DeleteProductCommand()
            {
                Parameter = productToDelete.Result
            };
            var deletedProduct = await this.commandExecutor.Execute(command);

            return new DeleteProductResponse()
            {
                Data = this.mapper.Map<Domain.Models.Product>(deletedProduct)
            };
        }
    }
}
