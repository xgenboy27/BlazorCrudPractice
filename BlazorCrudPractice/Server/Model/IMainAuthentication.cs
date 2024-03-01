using BlazorCrudPractice.Shared.Model;

namespace BlazorCrudPractice.Server.Model
{
    public interface IMainAuthentication
    {
        Task<(LoginResult, User)> Authenticate(string pEmailUserName, string pPassword);
    }
}
