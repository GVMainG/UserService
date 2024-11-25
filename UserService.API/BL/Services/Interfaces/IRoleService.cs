using UserService.API.DAL.Models;

namespace UserService.API.BL.Services.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleModel>> GetRoles();
        Task<RoleModel> GetRoleById(Guid roleId);
        Task<RoleModel> CreateRole(string roleName);
        Task DeleteRole(Guid roleId);
    }
}
