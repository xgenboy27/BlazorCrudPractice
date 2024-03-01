using BlazorCrudPractice.Client.Utility;
using BlazorCrudPractice.Shared.Model;
using System.Net.Http.Json;

namespace BlazorCrudPractice.Client.Services
{
    public class LoginService : BaseService
    {
        public LoginService(HttpClient pHttpClient) : base(pHttpClient)
        {

        }

        public async Task<RegisterResult> Register(RegisterModel registerModel)
        {
            HttpResponseMessage response = await this.httpClient.PostAsJsonAsync("api/Accounts/Create", registerModel);
            return await response.GetResponseData<RegisterResult>();
        }


        public async Task<LoginResult> Login(LoginModel loginModel)
        {
            HttpResponseMessage response = await this.httpClient.PostAsJsonAsync("api/Login/LoginAccount", loginModel);
            return await response.GetResponseData<LoginResult>();
        }

        public async ValueTask<LoginResult> ValidateLogin(string? token)
        {
            string url = string.Format("api/Login/ValidateToken?Token={0}", Uri.EscapeDataString(token));
            return await this.httpClient.GetFromJsonAsync<LoginResult>(url);
            //return await this.httpClient.GetFromJsonAsync<LoginResult>($"api/TokenValidation/ValidateToken/{Uri.EscapeDataString(token)}");
        }


    }
}
