using BlazorCrudPractice.Business.Model;
using BlazorCrudPractice.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrudPractice.Business.DomainService.RegisterEmployee
{
    public class GetEmployeeList : BaseEmployee, IGetEmployeeList
    {
        private List<EmployeeServiceList> employeelist;
        public GetEmployeeList(List<IDataAccess> pDataAccess) : base(pDataAccess)
        {
            employeelist = new List<EmployeeServiceList>();
        }
        public List<EmployeeServiceList> GetEmployee()
        {
            Validation();
            Initialize();

            return employeelist;
        }

        private void Initialize()
        {
            if (this.isValid == false) { return; }

            this.employeelist = this.DLRegisterEmployee.GetEmployeeList();
        }

        private void Validation()
        {
            this.isValid = false;
            if (this.employeelist != null)
            {
                this.isValid = true;
            }
        }
    }
}
