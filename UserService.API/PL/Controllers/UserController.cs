using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.API.BL.Services;
using UserService.API.DAL.Models;
using UserService.API.PL.Models;

namespace UserService.API.PL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public UserController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserModel>> Register(UserRegisterModel model)
        {
            var role = await _roleService.GetRoleById(model.RoleId);
            if (role == null)
            {
                return BadRequest("Invalid role ID.");
            }

            var user = await _userService.RegisterUser(model);
            return Ok(user);
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<UserModel>> Authenticate(UserLoginModel model)
        {
            var user = await _userService.AuthenticateUser(model.Login, model.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(user);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<UserModel>> GetUserById(Guid id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }
    }
}
