using CookBookApp.ApplicationServices.API.Domain.RecipeFoodType;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CookBookApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeFoodTypeController : ApiControllerBase
    {
        public RecipeFoodTypeController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("{recipeFoodTypeId}")]
        public Task<IActionResult>GetRecipeFoodTypeById([FromRoute]int recipeFoodTypeId)
        {
            var request = new GetRecipeFoodTypeByIdRequest()
            {
                RecipeFoodTypeId = recipeFoodTypeId
            };

            return this.HandleRequest<GetRecipeFoodTypeByIdRequest, GetRecipeFoodTypeByIdResponse>(request);
        }

        //[HttpGet]
        //[Route("{recipeId}")]
        //public Task<IActionResult>GetFoodTypesByRecipeId([FromRoute]int recipeId)
        //{
        //    var request = new GetFoodTypesByRecipeIdRequest()
        //    {
        //        RecipeId = recipeId
        //    };

        //    return this.HandleRequest<GetFoodTypesByRecipeIdRequest.GetFoodTypesByRecipeIdResponse>(request);
        //}

        [HttpPost]
        [Route("")]
        public Task<IActionResult>AddRecipeFoodType([FromBody]AddRecipeFoodTypeRequest request)
        {
            return this.HandleRequest<AddRecipeFoodTypeRequest, AddRecipeFoodTypeResponse>(request);
        }

        [HttpDelete]
        [Route("{recipeFoodTypeId}")]
        public Task<IActionResult>DeleteRecipeFoodType([FromRoute]int recipeFoodTypeId)
        {
            var request = new DeleteRecipeFoodTypeRequest()
            {
                RecipeFoodTypeId = recipeFoodTypeId
            };

            return this.HandleRequest<DeleteRecipeFoodTypeRequest, DeleteRecipeFoodTypeResponse>(request);
        }
        
        [HttpPut]
        [Route("{recipeFoodTypeId}")]
        public Task<IActionResult>UpdateRecipeFoodType([FromRoute]int recipeFoodTypeId, UpdateRecipeFoodTypeRequest request)
        {
            request.RecipeFoodTypeId = recipeFoodTypeId;

            return this.HandleRequest<UpdateRecipeFoodTypeRequest, UpdateRecipeFoodTypeResponse>(request);
        }
    }
}
