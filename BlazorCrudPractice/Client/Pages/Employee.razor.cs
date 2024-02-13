using BlazorCrudPractice.Client.Services;
using BlazorCrudPractice.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using static System.Net.WebRequestMethods;

namespace BlazorCrudPractice.Client.Pages
{
    public class EmployeeBase : ComponentBase
    {
        [Inject] IService _service  { get; set; }
        [Inject] HttpClient Http { get; set; }
        [Inject] IJSRuntime JsRuntime { get; set; }


        public EmployeeModel EmployeeModel = new EmployeeModel();
        protected List<EmployeeModel> Employee= new List<EmployeeModel>();
        public bool IsProceed { get; set; } = false;
        public string Message_Code { get; set; } = string.Empty;
        protected override async Task OnInitializedAsync()
        {
           await M_GetEMployeeList();
        }

        public async Task M_GetEMployeeList()
        {

            var result = await _service.GetEmployeeList();
            Employee = result.Data;


        }
        public void ClearFields()
        {
            EmployeeModel.RecId = 0;
            EmployeeModel.EmployeeName = string.Empty;
            EmployeeModel.EmployeeMiddleName = string.Empty;
            EmployeeModel.EmployeeLastName = string.Empty;
            EmployeeModel.EmployeeAge = 0;
        }
        public async Task M_SaveEmployee()
        {


            bool confirmed = await JsRuntime.InvokeAsync<bool>("confirm", "Are you sure you want to save?");
            if (confirmed)
            {
                if (EmployeeModel.RecId > 0)
                {
                    var result = await _service.UpdateEmployee(EmployeeModel);
                    Message_Code = result;
                    await JsRuntime.InvokeVoidAsync("alert", Message_Code);
                   await M_GetEMployeeList();
                    ClearFields();
                }
                else
                {
                    var result = await _service.SaveEmployee(EmployeeModel);
                    Message_Code = result;
                    await JsRuntime.InvokeVoidAsync("alert", Message_Code);
                   await M_GetEMployeeList();
                    ClearFields();
                }
            }

        }



        public async Task M_GetEmployeeById(int recid)
        {
            var result = await _service.GetEmployeeById(recid);
            Message_Code = "EDIT";
            ClearFields();
            EmployeeModel = result.Data;
            StateHasChanged();

        }
        public async Task M_DeleteEmployee(int recid)
        {
            string prompted = await JsRuntime.InvokeAsync<string>("prompt", "Please put Delete Code"); // Prompt

            if (prompted.Equals("123456789"))
            {
                var result = await _service.DeleteEmployee(recid);
                Message_Code = result;
                await JsRuntime.InvokeVoidAsync("alert", Message_Code);
                ClearFields();
              await  M_GetEMployeeList();
                StateHasChanged();
            }
            else
            {
                await JsRuntime.InvokeVoidAsync("alert", "Invalid Code");
            }
            // bool confirmed = await JsRuntime.InvokeAsync<bool>("confirm", "Are you sure you want to Delete?");
            // if (confirmed)
            // {


            // }
        }

    }
}
