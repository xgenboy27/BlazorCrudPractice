using BlazorCrudPractice.Business.Model;
using BlazorCrudPractice.Shared;
using BlazorCrudPractice.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrudPractice.Business.DomainService.RegisterEmployee
{
    public class GetEmployeeById : BaseEmployee, IGetEmployeeById
    {
        private EmployeeModel employeelist;
        private int _recid;
        public GetEmployeeById(List<IDataAccess> pDataAccess) : base(pDataAccess)
        {
            employeelist = new EmployeeModel();
        }

        public EmployeeModel getEmployeeById(int recid)
        {
            _recid = recid;
            Validation();
            Initialize();

            return employeelist;
        }


        private void Initialize()
        {
            if (this.isValid == false) { return; }

            this.employeelist = this.DLRegisterEmployee.GetEmployeeById(_recid);
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
