using BlazorCrudPractice.Shared;
using BlazorCrudPractice.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrudPractice.Service.Employee
{
    public interface IEmployeeService
    {
        List<EmployeeServiceList> GetEmployeeList();
        string CreateEmployees(EmployeeModel model);
        string UpdateEmployees(EmployeeModel model);

        string DeleteEmployees(int recid);
        EmployeeModel GetEmployeeByid(int recid);
      
    }
}
