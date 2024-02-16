using BlazorCrudPractice.Shared;
using BlazorCrudPractice.Shared.Model;

namespace BlazorCrudPractice.Client.Services
{
    public interface IService
    {
        //List<EmployeeModel> Employee { get; set; }
      
        Task<List<EmployeeServiceList>>  GetEmployeeList();
        Task<string> SaveEmployee(EmployeeModel employee);
        Task<string> UpdateEmployee(EmployeeModel employee);
        Task<string> DeleteEmployee(int recid);
        Task <EmployeeModel> GetEmployeeById(int recid);
    }
}
