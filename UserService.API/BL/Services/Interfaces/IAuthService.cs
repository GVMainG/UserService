using UserService.API.DAL.Models;

namespace UserService.API.BL.Services.Interfaces
{
    public interface IAuthService
    {
        string GenerateJwtToken(UserModel user);
    }
}
