using Microsoft.AspNetCore.Mvc;
using TestApi.Models.DTOs.Request;
using TestApi.Models.DTOs.Response;
using TestApi.Services;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public async Task CreateUser([FromBody] UserRequest userRequest)
        {
            await userService.CreateUser(userRequest);
        }

        [HttpPut("{id}")]
        public async Task UpdateUser(int id, [FromBody] UserRequest userRequest)
        {
            await userService.UpdateUser(id, userRequest);
        }

        [HttpGet("{id}")]
        public async Task<UserResponse> GetUserById(int id)
        {
            return await userService.GetUserById(id);
        }

        [HttpGet]
        public async Task<List<UserResponse>> GetAllUsers()
        {
            return await userService.GetAllUsers();
        }

        [HttpPatch("{id}")]
        public async Task DeactivateUser(int id)
        {
            await userService.DeactivateUser(id);
        }

    }
}
