using BlazorCrudPractice.Service.Employee;
using BlazorCrudPractice.Shared;
using BlazorCrudPractice.Shared.Model;

namespace BlazorCrudPractice.Server.Model
{
    public class MainEmployee : BaseEmployee, IMainEmployee
    {
        private IEmployeeService employeeService;
        public MainEmployee()
        {
            this.employeeService = new EmployeeService();     
        }

        public async Task<string> CreateEmplyees(EmployeeModel model)
        {
            return this.employeeService.CreateEmployees(model);
        }

        public async Task<string> DeleteEmplyees(int recid)
        {
            return this.employeeService.DeleteEmployees(recid);
        }

        public async Task<EmployeeModel> GetEmployeeByid(int recid)
        {
            return this.employeeService.GetEmployeeByid(recid);
        }

        public async Task<List<EmployeeServiceList>> GetEmployeeList()
        {        
            return this.employeeService.GetEmployeeList();
        }

        public async Task<string> UpdateEmplyees(EmployeeModel model)
        {
            return this.employeeService.UpdateEmployees(model);
        }
    }
}
