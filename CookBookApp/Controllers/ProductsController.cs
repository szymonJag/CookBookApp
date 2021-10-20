using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain;
using CookBookApp.ApplicationServices.API.Domain.Products;
using CookBookApp.DataAccess.CQRS;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ApiControllerBase
    {

        public ProductsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        [Authorize(Roles ="admin,user")]
        public Task<IActionResult> GetAllProducts([FromQuery] GetProductsRequest request)
        {
            return this.HandleRequest<GetProductsRequest, GetProductsResponse>(request);
        }

        [HttpGet]
        [Route("{productId}")]
        public Task<IActionResult> GetById([FromRoute] int productId)
        {
            var request = new GetProductByIdRequest()
            {
                ProductId = productId
            };

            return this.HandleRequest<GetProductByIdRequest, GetProductByIdResponse>(request);
        }

        [HttpGet]
        [Route("unaccepted")]
        public Task<IActionResult> GetUnacceptedProducts([FromQuery] GetUnacceptedProductsRequest request)
        {
            return this.HandleRequest<GetUnacceptedProductsRequest, GetUnacceptedProductsResponse>(request);
        }

        [Authorize(Roles ="admin,user")]
        [HttpGet]
        [Route("allProductsAddedByUser")]
        public Task<IActionResult> GetAllProductsAddedByUser([FromQuery]GetAllProductsAddedByUserRequest request)
        {
            return this.HandleRequest<GetAllProductsAddedByUserRequest, GetAllProductsAddedByUserResponse>(request);
        }
        

        
        [Authorize(Roles ="admin,user")]
        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddProduct([FromBody] AddProductRequest request)
        {
            return this.HandleRequest<AddProductRequest, AddProductResponse>(request);
        }

        [HttpDelete]
        [Route("{productId}")]
        public Task<IActionResult> DeleteProduct([FromRoute] int productId)
        {
            var request = new DeleteProductRequest()
            {
                ProductId = productId
            };

            return this.HandleRequest<DeleteProductRequest, DeleteProductResponse>(request);
        }

        [HttpPut]
        [Route("{productId}")]
        public Task<IActionResult> UpdateProduct([FromRoute]int productId, [FromBody]UpdateProductRequest request)
        {
            request.ProductId = productId;

            return this.HandleRequest<UpdateProductRequest, UpdateProductResponse>(request);
        }

        [HttpPut]
        [Route("changeIsAcceptedStatus/{productId}")]
        public Task<IActionResult> ChangeProductIsAcceptedStatus([FromRoute] int productId)
        {
            var request = new ChangeProductIsAcceptedStatusRequest()
            {
                ProductId = productId
            };

            return this.HandleRequest<ChangeProductIsAcceptedStatusRequest, ChangeProductIsAcceptedStatusResponse>(request);
        }
    }
}
