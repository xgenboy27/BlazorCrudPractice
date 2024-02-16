using BlazorCrudPractice.Client.Pages;
using BlazorCrudPractice.Shared;
using BlazorCrudPractice.Shared.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;

namespace BlazorCrudPractice.Client.Services
{
    public class Service : BaseService, IService
    {
        public Service(HttpClient pHttpClient) : base(pHttpClient)
        {
        }
        /*Done Multi Service*/
        public async Task<string> DeleteEmployee(int recid)
        {
            //var response = await httpClient.DeleteAsync($"api/Employee/save-deleteEmployee/{recid}");     
            var response = await this.httpClient.DeleteAsync($"api/Employee/save-deleteEmployee/{recid}");
            response.EnsureSuccessStatusCode();
            var contentTemp = await response.Content.ReadAsStringAsync();
            //var result = JsonConvert.DeserializeObject<EmployeeResponse<string>>(contentTemp);
            return contentTemp;

            //else
            //{
            //    var contentTemp = await response.Content.ReadAsStringAsync();
            //    var errorModel = JsonConvert.DeserializeObject<ErrorModel>(contentTemp);
            //    throw new Exception(errorModel.ErrorMessage);
            //}
        }
        /*Done Multi Service*/
        public async Task<EmployeeModel> GetEmployeeById(int recid)
        {
            var response = await httpClient.GetAsync($"api/Employee/get-EmployeeById/{recid}");          
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var rooms = JsonConvert.DeserializeObject<EmployeeModel>(content);
            return rooms;
        }

        /*Done Multi Service*/
        public async Task<List<EmployeeServiceList>> GetEmployeeList()
        {
            var response = await this.httpClient.GetAsync("api/Employee/get-employeeList");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var rooms = JsonConvert.DeserializeObject<EmployeeListResponse<List<EmployeeServiceList>>>(content);
            return rooms.Result;
        }

        /*Done Multi Service*/
        public async Task<string> SaveEmployee(EmployeeModel employee)
        {
            var content = JsonConvert.SerializeObject(employee);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await this.httpClient.PostAsync("api/Employee/save-createEmployee", bodyContent);

            response.EnsureSuccessStatusCode();
            var contentTemp = await response.Content.ReadAsStringAsync();
            //var result = JsonConvert.DeserializeObject<EmployeeResponse<string>>(contentTemp);
            return contentTemp;

            //else
            //{
            //    var contentTemp = await response.Content.ReadAsStringAsync();
            //    var errorModel = JsonConvert.DeserializeObject<ErrorModel>(contentTemp);
            //    throw new Exception(errorModel.ErrorMessage);
            //}
        }

        /*Done Multi Service*/
        public async Task<string> UpdateEmployee(EmployeeModel employee)
       {
           
            var content = JsonConvert.SerializeObject(employee);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await this.httpClient.PutAsync("api/Employee/save-updateEmployee", bodyContent);

            response.EnsureSuccessStatusCode();
            var contentTemp = await response.Content.ReadAsStringAsync();
            //var result = JsonConvert.DeserializeObject<EmployeeResponse<string>>(contentTemp);
            return contentTemp;

            //else
            //{
            //    var contentTemp = await response.Content.ReadAsStringAsync();
            //    var errorModel = JsonConvert.DeserializeObject<ErrorModel>(contentTemp);
            //    throw new Exception(errorModel.ErrorMessage);
            //}
        }
    }
}
