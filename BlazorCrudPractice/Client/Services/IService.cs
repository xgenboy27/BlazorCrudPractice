using BlazorCrudPractice.Shared;

namespace BlazorCrudPractice.Client.Services
{
    public interface IService
    {
        //List<EmployeeModel> Employee { get; set; }
      
        Task<ServiceResponse<List<EmployeeModel>>>  GetEmployeeList();
        Task<string> SaveEmployee(EmployeeModel employee);
        Task<string> UpdateEmployee(EmployeeModel employee);
        Task<string> DeleteEmployee(int recid);
        Task <ServiceResponse<EmployeeModel>> GetEmployeeById(int recid);
    }
}
