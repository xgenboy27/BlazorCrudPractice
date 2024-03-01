using BlazorCrudPractice.Shared.Model;
using Microsoft.AspNetCore.Components;

namespace BlazorCrudPractice.Client.Pages
{
    public partial class LoginDisplay
    {

        [Inject]
        public NavigationManager navigationManager { get; set; }

        [Inject]
        public UserInfo userInfo { get; set; }


        private void Login()
        {
            navigationManager.NavigateTo("/Login");
        }

        private void Logout()
        {
            navigationManager.NavigateTo("/Logout");
        }

        private void Register()
        {
            navigationManager.NavigateTo("/Register");
        }
    }
}
