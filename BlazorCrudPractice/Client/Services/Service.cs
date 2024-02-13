using BlazorCrudPractice.Shared;
using System.Net.Http.Json;

namespace BlazorCrudPractice.Client.Services
{
    public class Service : IService
    {
        private readonly HttpClient _http;
        public Service(HttpClient http)
        {

            _http = http;

        }
        public List<EmployeeModel> Employee { get; set; } = new List<EmployeeModel>();

        public async Task<string> DeleteEmployee(int recid)
        {
            var response = await _http.DeleteAsync($"api/Employee/DeleteEmployee/{recid}");

            if (response.IsSuccessStatusCode)
            {
                return (await response.Content
                .ReadFromJsonAsync<ServiceResponse<string>>()).Message;
            }
            return "";
        }

        public async Task<ServiceResponse<EmployeeModel>> GetEmployeeById(int recid)
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<EmployeeModel>>($"api/Employee/EmployeeById/{recid}");
            return response;
        }

        public async Task GetEmployeeList()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<EmployeeModel>>>("api/Employee/EmployeeList");
            if (response != null && response.Data != null)
                Employee = response.Data;
        }

        public async Task<string> SaveEmployee(EmployeeModel employee)
        {
            var response = await _http.PostAsJsonAsync("api/Employee/SaveEmployee", employee);

            if (response.IsSuccessStatusCode)
            {
                return (await response.Content
                .ReadFromJsonAsync<ServiceResponse<string>>()).Message;
            }
            return "";
        }

        public async Task<string> UpdateEmployee(EmployeeModel employee)
        {
            var response = await _http.PutAsJsonAsync("api/Employee/UpdateEmployee", employee);
            if (response.IsSuccessStatusCode)
            {
                return (await response.Content
                .ReadFromJsonAsync<ServiceResponse<string>>()).Message;
            }
            return "";
        }
    }
}
