using BlazorCrudPractice.Client.Utility;
using BlazorCrudPractice.Shared.Enum;
using BlazorCrudPractice.Shared.Model;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;

namespace BlazorCrudPractice.Client.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        //[Inject]
        //public LoginService loginService { get; set; }
        public LoginService loginService;

        public AuthService(HttpClient pHttpClient,
                            AuthenticationStateProvider authenticationStateProvider,
                            ILocalStorageService localStorage)
        {
            // this.httpClient = pHttpClient;
            this.loginService = new LoginService(pHttpClient);
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<RegisterResult> Register(RegisterModel registerModel)
        {
            //var result = await _httpClient.PostAsJsonAsync("api/Accounts/Create", registerModel);
            //RegisterResult register = await result.GetResponseData<RegisterResult>();

            RegisterResult register = await this.loginService.Register(registerModel);



            if (register.Errors != null)
            {
                return new RegisterResult { Successful = false, Errors = register.Errors.ToList() };
            }

            return new RegisterResult { Successful = true, Errors = new List<string> { "Account Created Successfully" } };
        }

        public async Task<LoginResult> Login(LoginModel loginModel)
        {
            LoginResult loginResult = await this.loginService.Login(loginModel);



            if (loginResult.Token != null)
            {
                await _localStorage.SetItemAsync("UserToken", loginResult!.Token);
                ((CustomAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginModel.Email!);
                //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResult.Token);
                this.loginService.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResult.Token);
            }


            return loginResult;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("UserToken");
            ((CustomAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            //_httpClient.DefaultRequestHeaders.Authorization = null;
            this.loginService.httpClient.DefaultRequestHeaders.Authorization = null;
        }



        public async Task<LoginResult> ValidateToken()
        {
            var usertoken = await _localStorage.GetItemAsync<string>("UserToken");
            LoginResult loginResult = new LoginResult();
            loginResult.ExpiredStatus = LoginExpiredStatus.TokenExpired;
            loginResult.IsLogout = true;


            if (!string.IsNullOrEmpty(usertoken))
            {
                loginResult = await this.loginService.ValidateLogin(usertoken);
            }


            return loginResult;


        }

        //private async Task ValidateAuthentication()
        //{

        //    UserInfo userInfo = await CustomAuthenticationStateProvider.get

        //    AuthenticationState authenticationState = await CustomAuthenticationStateProvider.GetAuthenticationStateAsync();
        //    ClaimsPrincipal user = authenticationState.User;

        //    if (user.Identity != null && user.Identity.IsAuthenticated)
        //    {

        //        foreach (Claim claim in user.Claims)
        //        {

        //            var test = claim.Type + "/" + claim.Value;

        //        }

        //        navigationManager.NavigateTo("/");
        //    }
        //}

    }
}
