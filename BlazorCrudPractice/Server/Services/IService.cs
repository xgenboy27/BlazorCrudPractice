using BlazorCrudPractice.Shared;

namespace BlazorCrudPractice.Server.Services
{
    public interface IService
    {
        Task<ServiceResponse<string>> DeleteEmployee(int recid);
        Task<ServiceResponse<string>> SaveEmployee(EmployeeModel employee);
        Task<ServiceResponse<string>> UpdateEmployee(EmployeeModel employee);
        Task<ServiceResponse<List<EmployeeModel>>> GetEmployeeList();
        Task<ServiceResponse<EmployeeModel>> GetEmployeeById(int recid);
    }
}
