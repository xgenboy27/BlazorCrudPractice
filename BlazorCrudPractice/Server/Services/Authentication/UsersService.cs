using BlazorCrudPractice.Service;
using BlazorCrudPractice.Shared.Model;

namespace BlazorCrudPractice.Server.Services.Authentication
{
    public class UsersService : BaseDataAccessFactory /*IUsersService*/
    {
        //private IGetUserInfo getUserInfo;

        public UsersService()
        {
            //this.getUserInfo = new GetUserInfo(this.dataAcesses);
        }

        //public UserInfo GetUserInfo(int? pUserID)
        //{
        //    return this.getUserInfo.Get(pUserID);
        //}

    }
}
