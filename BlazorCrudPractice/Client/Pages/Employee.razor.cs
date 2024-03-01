using BlazorCrudPractice.Client.Services;
using BlazorCrudPractice.Shared;
using BlazorCrudPractice.Shared.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.NetworkInformation;
using System.Net.Http.Json;
using Blazorise;
using Microsoft.JSInterop;

namespace BlazorCrudPractice.Client.Pages
{
    public partial class Employee
    {
        private bool IsProceed { get; set; } = false;
        private string Message_Code { get; set; } = string.Empty;
        private EmployeeModel EmployeeModels { get; set; } = new EmployeeModel();
        private List<EmployeeServiceList> _Employee { get; set; } = new List<EmployeeServiceList>();
        [Inject]
        public IJSRuntime jSRuntime { get; set; }

        private IJSObjectReference _jsModule;
    }
}
