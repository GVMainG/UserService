using UserService.API.DAL.Models;

namespace UserService.API.BL.Services
{
    public interface IUserService
    {
        Task<UserModel> RegisterUser(UserRegisterModel model);
        Task<UserModel> AuthenticateUser(string username, string password);
        Task<UserModel> GetUserById(Guid userId);
        Task<IEnumerable<UserModel>> GetAllUsers();
    }
}
