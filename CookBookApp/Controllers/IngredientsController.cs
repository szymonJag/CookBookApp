using CookBookApp.ApplicationServices.API.Domain;
using CookBookApp.ApplicationServices.API.Domain.Ingredients;
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
    public class IngredientsController : ApiControllerBase
    {
        public IngredientsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetIngredients([FromQuery] GetIngredientsRequest request)
        {
            return this.HandleRequest<GetIngredientsRequest, GetIngredientsResponse>(request);
        }

        [HttpGet]
        [Route("{ingredientId}")]
        public Task<IActionResult> GetIngredientById([FromRoute] int ingredientId)
        {
            var request = new GetIngredientByIdRequest()
            {
                IngredientId = ingredientId
            };

            return this.HandleRequest<GetIngredientByIdRequest, GetIngredientByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddIngredient([FromBody] AddIngredientRequest request)
        {
            return this.HandleRequest<AddIngredientRequest, AddIngredientResponse>(request);
        }

        [HttpDelete]
        [Route("{ingredientId}")]
        public Task<IActionResult> DeleteIngredient([FromRoute] int ingredientId)
        {
            var request = new DeleteIngredientRequest()
            {
                IngredientId = ingredientId
            };
            
            return this.HandleRequest<DeleteIngredientRequest, DeleteIngredientResponse>(request);
        }

        [HttpPut]
        [Route("{ingredientId}")]
        public Task<IActionResult> UpdateIngredient([FromRoute] int ingredientId, [FromBody]UpdateIngredientRequest request)
        {
            request.Id = ingredientId;
            return this.HandleRequest<UpdateIngredientRequest, UpdateIngredientResponse>(request);
        }
    }
}
