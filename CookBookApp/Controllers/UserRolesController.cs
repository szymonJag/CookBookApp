using CookBookApp.ApplicationServices.API.Domain.UserRoles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
    public class UserRolesController : ApiControllerBase
    {
        public UserRolesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllUserRoles([FromQuery]GetAllUserRolesRequest request)
        {
            return await this.HandleRequest<GetAllUserRolesRequest, GetAllUserRolesResponse>(request);
        }

        [HttpGet]
        [Route("{userRoleId}")]
        public async Task<IActionResult> GetUserRoleById([FromRoute]int userRoleId)
        {
            var request = new GetUserRolesByIdRequest()
            {
                Id = userRoleId
            };
            return await this.HandleRequest<GetUserRolesByIdRequest, GetUserRolesByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddUserRole([FromBody] AddUserRolesRequest request)
        {
            return await this.HandleRequest<AddUserRolesRequest, AddUserRolesResponse>(request);
        }

        [HttpDelete]
        [Route("{userRoleId}")]
        public async Task<IActionResult>DeleteUserRole([FromRoute]int userRoleId)
        {
            var request = new DeleteUserRolesRequest()
            {
                UserRoleId = userRoleId
            };
            return await this.HandleRequest<DeleteUserRolesRequest, DeleteUserRolesResponse>(request);
        }

    }
}
