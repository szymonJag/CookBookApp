using CookBookApp.ApplicationServices.API.Domain.FoodTypes;
using CookBookApp.ApplicationServices.API.Domain.ProductTypes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CookBookApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypesController : ApiControllerBase
    {
        public ProductTypesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        [Authorize(Roles ="admin,user")]
        public async Task<IActionResult> GetProductTypes([FromQuery]GetProductTypesRequest request)
        {
            return await HandleRequest<GetProductTypesRequest, GetProductTypesResponse>(request);
        }
    }
}
