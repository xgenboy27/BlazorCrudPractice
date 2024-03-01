using Microsoft.JSInterop;

namespace BlazorCrudPractice.Client.Pages
{
    public partial class Employee
    {
        protected override async Task OnInitializedAsync()
        {
            await M_GetEMployeeList();
          _jsModule =await jSRuntime.InvokeAsync<IJSObjectReference>("import", "./Pages/Employee.razor.js");
        }
    }
}
