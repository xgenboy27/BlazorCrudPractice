using BlazorCrudPractice.Client.Services;
using BlazorCrudPractice.Shared.Model;
using Blazored.Modal;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using BlazorCrudPractice.Client.State;
using Blazored.Modal.Services;

namespace BlazorCrudPractice.Client.Shared
{
    public partial class MainLayout
    {

        [Inject]
        private UserInfoState userInfoState { get; set; } = default!;

        [Inject]
        public UserInfo userInfo { get; set; }

        [Inject]
        private AuthenticationStateProvider customAuthenticationStateProvider { get; set; }

        //[Inject]
        //public ICommonDataService commonDataService { get; set; }

        [Inject]
        private NavigationManager navigationManager { get; set; }

        [Inject]
        private IAuthService authService { get; set; }

        [CascadingParameter]
        public BlazoredModalInstance? modalInstance { get; set; }

        [CascadingParameter]
        public IModalService modal { get; set; } = default!;

        private string? title { get; set; }


        private IModalReference? modalRef;




    }
}
