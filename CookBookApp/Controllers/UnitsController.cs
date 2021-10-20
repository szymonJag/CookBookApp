using CookBookApp.ApplicationServices.API.Domain;
using CookBookApp.ApplicationServices.API.Domain.Units;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CookBookApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ApiControllerBase
    {
        public UnitsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetUnits([FromQuery] GetUnitsRequest request)
        {
            return this.HandleRequest<GetUnitsRequest, GetUnitsResponse>(request);
        }
        [HttpGet]
        [Route("{unitId}")]
        public Task<IActionResult> GetUnitById([FromRoute] GetUnitByIdRequest request)
        {
            return this.HandleRequest<GetUnitByIdRequest, GetUnitByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddUnit([FromBody] AddUnitRequest request)
        {
            return this.HandleRequest<AddUnitRequest, AddUnitResponse>(request);
        }

        [HttpDelete]
        [Route("{unitId}")]
        public Task<IActionResult> DeleteUnit([FromRoute] int unitId)
        {
            var request = new DeleteUnitRequest()
            {
                UnitId = unitId
            };
            return this.HandleRequest<DeleteUnitRequest, DeleteUnitResponse>(request);
        }

        [HttpPut]
        [Route("{unitId}")]
        public Task<IActionResult> UpdateUnit([FromRoute] int unitId, [FromBody] UpdateUnitRequest request)
        {
            request.Id = unitId;
            return this.HandleRequest<UpdateUnitRequest, UpdateUnitResponse>(request);
        }
    }
}
