using BlazorCrudPractice.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrudPractice.Business.DomainService.RegisterEmployee
{
    public class DeleteEmployee : BaseEmployee, IDeleteEmployee
    {
        private string message_Code = string.Empty;
        private int _recid;
        public DeleteEmployee(List<IDataAccess> pDataAccess) : base(pDataAccess)
        {

        }
        public string deleteEmployee(int recid)
        {
            _recid = recid;
            Validation();
            Initialize();
            return message_Code;
        }

        private void Initialize()
        {
            if (this.isValid == false) { return; }
            this.message_Code = this.DLRegisterEmployee.DeleteEmployee(_recid);
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
