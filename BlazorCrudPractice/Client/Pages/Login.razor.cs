using BlazorCrudPractice.Client.Services;
using BlazorCrudPractice.Client.State;
using BlazorCrudPractice.Shared.Model;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using System.Text.RegularExpressions;

namespace BlazorCrudPractice.Client.Pages
{
    public partial class Login
    {

        [Inject]
        private UserInfoState userInfoState { get; set; } = default!;

        [Inject]
        public UserInfo userInfo { get; set; }

        [Inject]
        private IAuthService AuthService { get; set; }

        [Inject]
        private AuthenticationStateProvider customAuthenticationStateProvider { get; set; }

        [Inject]
        private NavigationManager navigationManager { get; set; }

        private LoginModel loginModel = new LoginModel();
        private bool ShowErrors;
        private string Error = "";
        private bool loading = false;

        // Email Functions
        private bool IsInvalidEmail { get; set; } = false;

        //protected override async Task OnInitializedAsync()
        //{
        //    var authenticationState = await CustomAuthenticationStateProvider.GetAuthenticationStateAsync();
        //    var user = authenticationState.User;

        //    if(user.Identity == null && user.Identity.IsAuthenticated)
        //    {
        //        navigationManager.NavigateTo("/");
        //        //navigationManager.NavigateTo("/Login");
        //    }
        //    //else
        //    //{
        //    //    navigationManager.NavigateTo("/");
        //    //}


        //    //if (user.Identity == null || !user.Identity.IsAuthenticated)
        //    //{
        //    //    navigationManager.NavigateTo("/Login");
        //    //}
        //    //else
        //    //{
        //    //    navigationManager.NavigateTo("/");
        //    //}
        //}


        private string GetEmailBorderStyle()
        {
            return IsInvalidEmail ? "border: 1px solid red; outline: none !important; padding: 1rem 1.75rem; font-size: 15pt; margin-bottom: 15px;  box-shadow: 0px 0px 2px 2px rgba(110, 110, 110, 0.082);  border-radius: 8px; " : "padding: 1rem 1.75rem; font-size: 15pt;  box-shadow: 0px 0px 2px 2px rgba(110, 110, 110, 0.082);  border: 1px solid #C1C1C1; margin-bottom: 15px;  border-radius: 8px; ";
        }

        private string GetPasswordBorderStyle()
        {
            return "padding: 1rem 3rem 1rem 1.75rem; font-size: 15pt;  border: 1px solid #ced4da00; border-radius: 8px; background-color: transparent; ";
        }


        private bool IsValidEmail(string email)
        {
            string EmailValidationRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, EmailValidationRegex);
        }

        private void OnEmailInput(ChangeEventArgs e)
        {
            string inputValue = e.Value?.ToString() ?? "";
            IsInvalidEmail = !string.IsNullOrWhiteSpace(inputValue) && !IsValidEmail(inputValue);
        }

        // Password Functions

        private bool passwordVisible = false;

        private void TogglePasswordVisibility()
        {
            passwordVisible = !passwordVisible;
        }

        private string GetPasswordInputType()
        {
            return passwordVisible ? "text" : "password";
        }

        // Button Method




        private async Task HandleKeyPress(KeyboardEventArgs e)
        {
            if (e.Key == "Enter")
            {
                // Submit the form
                await HandleLogin();
            }
        }

        private void Return()
        {
            navigationManager.NavigateTo("/");
        }

    }
}
