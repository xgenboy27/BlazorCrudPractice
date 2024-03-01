using BlazorCrudPractice.Shared;
using BlazorCrudPractice.Shared.Enum;
using BlazorCrudPractice.Shared.Extension;
using Microsoft.JSInterop;

namespace BlazorCrudPractice.Client.Pages
{
    public partial class Employee
    {
        public async Task M_GetEMployeeList()
        {
            var result = await this._service.GetEmployeeList();
            _Employee = result;
            
        }

        private void ClearFields()
        {
            EmployeeModels.RecId = 0;
            EmployeeModels.EmployeeName = string.Empty;
            EmployeeModels.EmployeeMiddleName = string.Empty;
            EmployeeModels.EmployeeLastName = string.Empty;
            EmployeeModels.EmployeeAge = 0;
        }
        private async Task M_SaveEmployee()
        {
            bool confirmed = await JsRuntime.InvokeAsync<bool>("confirm", "Are you sure you want to save?");
            if (confirmed)
            {
                if (EmployeeModels.RecId > 0)
                {
                    var result = await _service.UpdateEmployee(EmployeeModels);
                    Message_Code = result;
                    await JsRuntime.InvokeVoidAsync("alert", Message_Code);

                    await M_GetEMployeeList();
                    ClearFields();
                    StateHasChanged();
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

                    Message_Code = result;
                    await JsRuntime.InvokeVoidAsync("alert", Message_Code);
                    await M_GetEMployeeList();
                    ClearFields();
                    StateHasChanged();
                }
            }
        }
        private async Task M_GetEmployeeById(int recid)
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
            StateHasChanged();
        }
        private async Task M_DeleteEmployee(int recid)
        {
            //string prompted = await JsRuntime.InvokeAsync<string>("prompt", "Please put Delete Code"); // Prompt
            //if (prompted.Equals("123456789"))
            //{
            var result = await _service.DeleteEmployee(recid);
            Message_Code = result;
            await JsRuntime.InvokeVoidAsync("alert", Message_Code);
            ClearFields();
            await M_GetEMployeeList();

            //}
            //else
            //{
            //    await JsRuntime.InvokeVoidAsync("alert", "Invalid Code");
            //}
        }
        void ShowMessage()
        {

            _jsModule.InvokeVoidAsync("showAlert", "Hello from Blazor!");
        }
    }
}
