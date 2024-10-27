using Microsoft.EntityFrameworkCore;
using UserService.API.DAL;
using UserService.API.DAL.Models;

namespace UserService.API.BL.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;

        public UserService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserModel> RegisterUser(UserRegisterModel model)
        {
            var user = new UserModel
            {
                UserName = model.UserName,
                Email = model.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password),
                RoleId = model.RoleId
            };

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> AuthenticateUser(string username, string password)
        {
            var user = await _dbContext.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.UserName == username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return null;
            }

            return user;
        }

        public async Task<UserModel> GetUserById(Guid userId)
        {
            return await _dbContext.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            return await _dbContext.Users.Include(u => u.Role).ToListAsync();
        }
    }
}
