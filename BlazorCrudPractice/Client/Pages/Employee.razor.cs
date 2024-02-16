using BlazorCrudPractice.Client.Services;
using BlazorCrudPractice.Shared;
using BlazorCrudPractice.Shared.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.NetworkInformation;
using static System.Net.WebRequestMethods;
using System.Net.Http.Json;

namespace BlazorCrudPractice.Client.Pages
{
    public class EmployeeBase : ComponentBase
    {
        [Inject] IService _service { get; set; }
        [Inject] IJSRuntime JsRuntime { get; set; }

        public EmployeeModel EmployeeModels { get; set; }= new EmployeeModel();
        protected List<EmployeeServiceList> Employee = new List<EmployeeServiceList>();
        public bool IsProceed { get; set; } = false;
        public string Message_Code { get; set; } = string.Empty;
        protected override async Task OnInitializedAsync()
        {
            await M_GetEMployeeList();
        }
        public async Task M_GetEMployeeList()
        {
            var result = await _service.GetEmployeeList();
            Employee = result;
        }
        public void ClearFields()
        {
            EmployeeModels.RecId = 0;
            EmployeeModels.EmployeeName = string.Empty;
            EmployeeModels.EmployeeMiddleName = string.Empty;
            EmployeeModels.EmployeeLastName = string.Empty;
            EmployeeModels.EmployeeAge = 0;
        }
        public async Task M_SaveEmployee()
        {
            bool confirmed = await JsRuntime.InvokeAsync<bool>("confirm", "Are you sure you want to save?");
            if (confirmed)
            {
                if (EmployeeModels.RecId > 0)
                {                
                    var result = await _service.UpdateEmployee(EmployeeModels);
                    Message_Code = result;
                    await JsRuntime.InvokeVoidAsync("alert", Message_Code);
                    StateHasChanged();
                    await M_GetEMployeeList();
                    ClearFields();
                }
                else
                {
                    var models = new EmployeeModel();

                    models.EmployeeName = EmployeeModels.EmployeeName;
                    models.EmployeeMiddleName = EmployeeModels.EmployeeMiddleName;
                    models.EmployeeLastName = EmployeeModels.EmployeeLastName;
                    models.EmployeeAge = EmployeeModels.EmployeeAge;
                    models.EmployeeDateOfBirth = EmployeeModels.EmployeeDateOfBirth;

                    var result = await _service.SaveEmployee(models);
                    StateHasChanged();
                    Message_Code = result;
                    await JsRuntime.InvokeVoidAsync("alert", Message_Code);
                    await M_GetEMployeeList();
                    ClearFields();
                }
            }
        }
        public async Task M_GetEmployeeById(int recid)
        {

            EmployeeModels = await _service.GetEmployeeById(recid);              
            Message_Code = "EDIT";
            //EmployeeModels.RecId = recid;
            //EmployeeModels.EmployeeName = result.EmployeeName;
            //EmployeeModels.EmployeeMiddleName = result.EmployeeMiddleName;
            //EmployeeModels.EmployeeLastName = result.EmployeeLastName;
            //EmployeeModels.EmployeeAge = result.EmployeeAge;
            //EmployeeModels.EmployeeDateOfBirth = result.EmployeeDateOfBirth;
            //ClearFields();         
            //StateHasChanged();
        }
        public async Task M_DeleteEmployee(int recid)
        {
            //string prompted = await JsRuntime.InvokeAsync<string>("prompt", "Please put Delete Code"); // Prompt
            //if (prompted.Equals("123456789"))
            //{
            var result = await _service.DeleteEmployee(recid);
            Message_Code = result;
            await JsRuntime.InvokeVoidAsync("alert", Message_Code);
            ClearFields();
            await M_GetEMployeeList();
            StateHasChanged();
            //}
            //else
            //{
            //    await JsRuntime.InvokeVoidAsync("alert", "Invalid Code");
            //}
        }
    }
}
