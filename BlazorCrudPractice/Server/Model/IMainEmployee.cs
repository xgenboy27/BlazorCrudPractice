using BlazorCrudPractice.Shared;
using BlazorCrudPractice.Shared.Model;

namespace BlazorCrudPractice.Server.Model
{
    public interface IMainEmployee
    {
        Task<List<EmployeeServiceList>> GetEmployeeList();
        Task<string> CreateEmplyees(EmployeeModel model);
        Task<string> UpdateEmplyees(EmployeeModel model);
        Task<string> DeleteEmplyees(int recid);
        Task<EmployeeModel> GetEmployeeByid(int recid);
    }
}
