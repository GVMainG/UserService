using UserService.API.DAL.Models;

namespace UserService.API.BL.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(UserModel user);
    }
}
