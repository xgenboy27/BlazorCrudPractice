
using BlazorCrudPractice.Shared;
using BlazorCrudPractice.Shared.Model;

namespace BlazorCrudPractice.Business.Model
{
    public interface IDLRegisterEmployee
    {
        List<EmployeeServiceList> GetEmployeeList();
        string CreateEmployee(EmployeeModel model);
        string UpdateEmployee(EmployeeModel model);
        string DeleteEmployee(int recid);
        EmployeeModel GetEmployeeById(int recid);
    }
}
