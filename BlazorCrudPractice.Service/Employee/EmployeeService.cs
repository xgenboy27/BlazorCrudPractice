using BlazorCrudPractice.Business.DomainService.RegisterEmployee;
using BlazorCrudPractice.Business.Model;
using BlazorCrudPractice.Shared;
using BlazorCrudPractice.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrudPractice.Service.Employee
{
    public class EmployeeService : BaseDataAccessFactory, IEmployeeService
    {

        private IGetEmployeeList employeeList;
        private ICreateEmployee createEmployee;
        private IGetEmployeeById getEmployeeById;
        private IUpdateEmployee updateEmployee;
        private IDeleteEmployee deleteEmployee;
        public EmployeeService()
        {
            this.employeeList = new GetEmployeeList(this.dataAcesses);
            this.createEmployee = new CreateEmployee(this.dataAcesses);
            this.getEmployeeById = new GetEmployeeById(this.dataAcesses);
            this.updateEmployee = new UpdateEmployee(this.dataAcesses);
            this.deleteEmployee = new DeleteEmployee(this.dataAcesses);
        }

        public string CreateEmployees(EmployeeModel model)
        {
            return this.createEmployee.createEmployee(model);
        }

        public string DeleteEmployees(int recid)
        {
           return this.deleteEmployee.deleteEmployee(recid);
        }

        public EmployeeModel GetEmployeeByid(int recid)
        {
            return this.getEmployeeById.getEmployeeById(recid);
        }

        public List<EmployeeServiceList> GetEmployeeList()
        {
            return this.employeeList.GetEmployee();
        }

        public string UpdateEmployees(EmployeeModel model)
        {
            return this.updateEmployee.updateEmployee(model);
        }
    }
}
