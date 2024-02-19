using BlazorCrudPractice.Business.Model;
using BlazorCrudPractice.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrudPractice.Business.DomainService.RegisterEmployee
{
    public class CreateEmployee : BaseEmployee, ICreateEmployee
    {
        private string message_Code = string.Empty;
        private string JModel;
        public CreateEmployee(List<IDataAccess> pDataAccess) : base(pDataAccess)
        {
            JModel = string.Empty;
        }

        public string createEmployee(EmployeeModel model)
        {
            this.JModel = JsonConvert.SerializeObject(model);
            
            Validation();
            Initialize();
            return message_Code;
        }

        private void Initialize()
        {
            if (this.isValid == false) { return; }
            
            this.message_Code = this.DLRegisterEmployee.CreateEmployee(JModel);
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
