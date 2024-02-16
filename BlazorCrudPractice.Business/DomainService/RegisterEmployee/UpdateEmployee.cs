using BlazorCrudPractice.Business.Model;
using BlazorCrudPractice.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrudPractice.Business.DomainService.RegisterEmployee
{
    public class UpdateEmployee : BaseEmployee, IUpdateEmployee
    {
        private string message_Code = string.Empty;
        private EmployeeModel _model;
        public UpdateEmployee(List<IDataAccess> pDataAccess) : base(pDataAccess)
        {
            _model = new EmployeeModel();
        }
        public string updateEmployee(EmployeeModel model)
        {
            _model = model;
            Validation();
            Initialize();

            return message_Code;
        }

        private void Initialize()
        {
            if (this.isValid == false) { return; }

            this.message_Code = this.DLRegisterEmployee.UpdateEmployee(_model);
        }

        private void Validation()
        {
            this.isValid = false;
            if (this.message_Code != null)
            {
                this.isValid = true;
            }
        }
    }
}
