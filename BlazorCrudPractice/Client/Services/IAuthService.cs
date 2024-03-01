using BlazorCrudPractice.Shared.Model;

namespace BlazorCrudPractice.Client.Services
{
    public interface IAuthService
    {
        Task<RegisterResult> Register(RegisterModel registerModel);

        Task<LoginResult> Login(LoginModel loginModel);

        Task<LoginResult> ValidateToken();

        Task Logout();
    }
}
