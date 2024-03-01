using BlazorCrudPractice.Client.Utility;
using BlazorCrudPractice.Shared.Enum;
using BlazorCrudPractice.Shared.Extension;
using BlazorCrudPractice.Shared.Model;

namespace BlazorCrudPractice.Client.Shared
{
    public partial class MainLayout
    {
        protected override async Task OnInitializedAsync()
        {
            LoginResult loginResult = await authService.ValidateToken();
            //await this.commonDataService.SetCommonOptions();
            if (loginResult != null && loginResult.ExpiredStatus == LoginExpiredStatus.TokenActive)
            {
                await this.ValidateAuthentication();

            }
            else
            {
                await this.authService.Logout();
                navigationManager.NavigateTo("/Login");
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


            //   AuthenticationState authenticationState = await  CustomAuthenticationStateProvider. .GetAuthenticationStateAsync();
            // ClaimsPrincipal user = authenticationState.User;

            //if (user.Identity != null && user.Identity.IsAuthenticated)
            //{   

            //    foreach(Claim claim in  user.Claims) { 

            //        var test = claim.Type + "/" + claim.Value;

            //    }

            //    navigationManager.NavigateTo("/");
            //}
        }
    }
}
