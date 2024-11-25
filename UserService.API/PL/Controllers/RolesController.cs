using Microsoft.AspNetCore.Mvc;
using UserService.API.BL.Services.Interfaces;
using UserService.API.DAL.Models;

namespace UserService.API.PL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleModel>>> GetRoles()
        {
            var roles = await _roleService.GetRoles();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleModel>> GetRole(Guid id)
        {
            var role = await _roleService.GetRoleById(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        [HttpPost]
        public async Task<ActionResult<RoleModel>> CreateRole([FromBody] string roleName)
        {
            var role = await _roleService.CreateRole(roleName);
            return CreatedAtAction(nameof(GetRole), new { id = role.Id }, role);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            await _roleService.DeleteRole(id);
            return NoContent();
        }
    }
}
