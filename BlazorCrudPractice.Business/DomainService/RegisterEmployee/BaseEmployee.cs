using BlazorCrudPractice.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrudPractice.Business.DomainService.RegisterEmployee
{
    public class BaseEmployee : BaseDataInfo
    {
        public IDLRegisterEmployee DLRegisterEmployee { get { return this.dlMainBlazorCrudPractice.DLRegisterEmployee; } }
        public BaseEmployee(List<IDataAccess> pDataAccess) : base(pDataAccess)
        {

        }
        public BaseEmployee()
        {
            
        }
    }
}
