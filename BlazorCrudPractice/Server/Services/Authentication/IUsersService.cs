using BlazorCrudPractice.Shared.Model;

namespace BlazorCrudPractice.Server.Services.Authentication
{
    public interface IUsersService
    {
        UserInfo GetUserInfo(int? pUserID);
    }
}
