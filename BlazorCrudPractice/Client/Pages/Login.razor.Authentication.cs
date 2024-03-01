using BlazorCrudPractice.Client.Utility;
using BlazorCrudPractice.Shared.Extension;
using BlazorCrudPractice.Shared.Model;

namespace BlazorCrudPractice.Client.Pages
{
    public partial class Login
    {

        private async Task HandleLogin()
        {
            this.loading = true;

            ShowErrors = false;
            var results = await AuthService.Login(loginModel);

            this.loading = false;

            if (results.Successful)
            {
                await this.ValidateAuthentication();
            }
            else
            {
                Error = results.Error!;
                ShowErrors = true;
                loginModel.Password = string.Empty;
            }
        }

        private async Task ValidateAuthentication()
        {
            UserInfo tmpUserInfo = await ((CustomAuthenticationStateProvider)customAuthenticationStateProvider).GetUserInfo();

            if (tmpUserInfo != null)
            {
                this.userInfo.Initialize(tmpUserInfo);
                navigationManager.NavigateTo("/");
                this.userInfoState.ChangeUserInfo = this.userInfo;
            }
        }

    }
}
