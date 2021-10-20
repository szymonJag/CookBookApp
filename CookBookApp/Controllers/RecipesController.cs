using CookBookApp.ApplicationServices.API.Domain;
using CookBookApp.ApplicationServices.API.Domain.Recipes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CookBookApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ApiControllerBase
    {
        public RecipesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetRecipes([FromQuery] GetRecipesRequest request)
        {
            return this.HandleRequest<GetRecipesRequest, GetRecipesResponse>(request);
        }

        [HttpGet]
        [Route("{recipeId}")]
        public Task<IActionResult> GetRecipeById([FromRoute] int recipeId)
        {
            var request = new GetRecipeByIdRequest()
            {
                RecipeId = recipeId
            };
            return this.HandleRequest<GetRecipeByIdRequest, GetRecipeByIdResponse>(request);
        }

        [HttpGet]
        [Route("unaccepted")]
        public Task<IActionResult> GetUnacceptedRecipes([FromQuery] GetUnacceptedRecipesRequest request)
        {
            return this.HandleRequest<GetUnacceptedRecipesRequest, GetUnacceptedRecipesResponse>(request);
        }

        [HttpGet]
        [Route("randomRecipe")]
        public Task<IActionResult> GetRandomRecipe([FromQuery] GetRandomRecipeRequest request)
        {
            return this.HandleRequest<GetRandomRecipeRequest, GetRandomRecipeResponse>(request);
        }

        [HttpGet]
        [Route("name")]
        public Task<IActionResult>GetRecipeByName([FromBody]GetRecipeByNameRequest request)
        {
            return this.HandleRequest<GetRecipeByNameRequest, GetRecipeByNameResponse>(request);
        }

        [HttpGet]
        [Route("getRecipesByIngredients")]
        public Task<IActionResult>GetRecipesByIngredientsId([FromQuery]GetRecipesByProductsIdRequest request)
        {
            return this.HandleRequest<GetRecipesByProductsIdRequest, GetRecipesByProductsIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddRecipe([FromBody] AddRecipeRequest request)
        {
            return this.HandleRequest<AddRecipeRequest, AddRecipeResponse>(request);
        }

        [HttpDelete]
        [Route("{recipeId}")]
        public Task<IActionResult> DeleteRecipe([FromRoute] int recipeId)
        {
            var request = new DeleteRecipeRequest()
            {
                RecipeId = recipeId
            };
            return this.HandleRequest<DeleteRecipeRequest, DeleteRecipeResponse>(request);
        }

        [HttpPut]
        [Route("{recipeId}")]
        public Task<IActionResult> UpdateRecipe([FromRoute] int recipeId, [FromBody] UpdateRecipeRequest request)
        {
            request.RecipeId = recipeId;
            return this.HandleRequest<UpdateRecipeRequest, UpdateRecipeResponse>(request);
        }

        [HttpPut]
        [Route("changeIsAcceptedStatus/{recipeId}")]
        public Task<IActionResult> ChangeRecipeIsAcceptedStatus([FromRoute] int recipeId, ChangeRecipeIsAcceptedStatusRequest request)
        {
            request.RecipeId = recipeId;
            return this.HandleRequest<ChangeRecipeIsAcceptedStatusRequest, ChangeRecipeIsAcceptedStatusResponse>(request);
        }
    }
}
