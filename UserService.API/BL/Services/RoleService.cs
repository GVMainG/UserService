using Microsoft.EntityFrameworkCore;
using System.Data;
using UserService.API.DAL;
using UserService.API.DAL.Models;

namespace UserService.API.BL.Services
{
    public class RoleService : IRoleService
    {
        private readonly AppDbContext _dbContext;

        public RoleService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<RoleModel>> GetRoles()
        {
            return await _dbContext.Roles.ToListAsync();
        }

        public async Task<RoleModel> GetRoleById(Guid roleId)
        {
            return await _dbContext.Roles.FirstOrDefaultAsync(r => r.Id == roleId);
        }

        public async Task<RoleModel> CreateRole(string roleName)
        {
            var role = new RoleModel { Name = roleName };
            _dbContext.Roles.Add(role);
            await _dbContext.SaveChangesAsync();
            return role;
        }

        public async Task DeleteRole(Guid roleId)
        {
            var role = await _dbContext.Roles.FirstOrDefaultAsync(r => r.Id == roleId);
            if (role == null) return;

            _dbContext.Roles.Remove(role);
            await _dbContext.SaveChangesAsync();
        }
    }
}
