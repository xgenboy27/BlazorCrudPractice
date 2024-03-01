using Microsoft.AspNetCore.Components;

namespace BlazorCrudPractice.Client.Pages
{
    public partial class ErrorPage
    {
        [Inject]
        private NavigationManager navigationManager { get; set; }

        private void GoHome()
        {
            navigationManager.NavigateTo("/");
        }

    }
}
