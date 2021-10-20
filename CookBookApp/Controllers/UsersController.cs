using CookBookApp.ApplicationServices.API.Domain.UserRoles;
using CookBookApp.ApplicationServices.API.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CookBookApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ApiControllerBase
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUsersRequest request)
        {
            return await this.HandleRequest<GetAllUsersRequest, GetAllUsersResponse>(request);
        }

        [HttpGet]
        [Route("getByName/{userName}")]
        public async Task<IActionResult> GetUserByName([FromRoute] string userName)
        {
            var request = new GetUserByNameRequest()
            {
                Name = userName
            };

            return await this.HandleRequest<GetUserByNameRequest, GetUserByNameResponse>(request);
        }

        [HttpGet]
        [Route("getById/{userId}")]
        public async Task<IActionResult>GetUserById([FromRoute]int userId)
        {
            var request = new GetUserByIdRequest()
            {
                UserId = userId
            };
            return await this.HandleRequest<GetUserByIdRequest, GetUserByIdResponse>(request);
        }

        [HttpGet]
        [Route("aboutMe")]
        public async Task<IActionResult>AboutMe([FromQuery] AboutMeRequest request)
        {
            return await this.HandleRequest<AboutMeRequest, AboutMeResponse>(request);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult>AddUser([FromBody]AddUserRequest request)
        {
            return await this.HandleRequest<AddUserRequest, AddUserResponse>(request);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult>ValidateUser([FromBody]ValidateUserRequest request)
        {
            return await this.HandleRequest<ValidateUserRequest, ValidateUserResponse>(request);
        }
        
        [Authorize(Roles ="admin")]
        [HttpPut]
        [Route("changeRole/{userId}")]
        public async Task<IActionResult>ChangeUserRole([FromRoute]int userId)
        {
            var request = new ChangeUserRoleRequest()
            {
                UserId = userId
            };

            return await this.HandleRequest<ChangeUserRoleRequest, ChangeUserRoleResponse>(request);
        }

        [Authorize(Roles ="admin")]
        [HttpDelete]
        [Route("{userId}")]
        public async Task<IActionResult> DeleteUser([FromRoute]int userId)
        {
            var request = new DeleteUserRequest()
            {
                UserId = userId
            };
            return await this.HandleRequest<DeleteUserRequest, DeleteUserResponse>(request);
        }
    }
}
