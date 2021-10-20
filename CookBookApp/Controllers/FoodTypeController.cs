using CookBookApp.ApplicationServices.API.Domain.FoodTypes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CookBookApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FoodTypeController : ApiControllerBase
    {
        public FoodTypeController(IMediator mediator) : base(mediator)
        {
        }
        
        [HttpGet]
        [Route("")]
        public Task<IActionResult>GetFoodTypes([FromQuery]GetFoodTypesRequest request)
        {
            return this.HandleRequest<GetFoodTypesRequest, GetFoodTypesResponse>(request);
        }

        [HttpGet]
        [Route("{foodTypeId}")]
        public Task<IActionResult>GedFoodTypeById([FromBody]int foodTypeId)
        {
            var request = new GetFoodTypeByIdRequest()
            {
                FoodTypeId = foodTypeId
            };
            return this.HandleRequest<GetFoodTypeByIdRequest, GetFoodTypeByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddFoodType([FromBody]AddFoodTypeRequest request)
        {
            return this.HandleRequest<AddFoodTypeRequest, AddFoodTypeResponse>(request);
        }

        [HttpDelete]
        [Route("{foodTypeId}")]
        public Task<IActionResult>DeleteFoodType([FromRoute]int foodTypeId)
        {
            var request = new DeleteFoodTypeRequest()
            {
                FoodTypeId = foodTypeId
            };

            return this.HandleRequest<DeleteFoodTypeRequest, DeleteFoodTypeResponse>(request);
        }

        [HttpPut]
        [Route("{foodTypeId}")]
        public Task<IActionResult>UpdateFoodType([FromRoute]int foodTypeId, UpdateFoodTypeRequest request)
        {
            request.FoodTypeId = foodTypeId;

            return this.HandleRequest<UpdateFoodTypeRequest, UpdateFoodTypeResponse>(request);
        }
    }
}
