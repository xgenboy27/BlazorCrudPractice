using BlazorCrudPractice.Business.Model;
using BlazorCrudPractice.DataSQL.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrudPractice.DataSQL
{
    public class DLMainBlazorCrudPractice : IDataAccess, IDLMainBlazorCrudPractice
    {
        private IDLRegisterEmployee _DLRegisterEmployee = new DLRegisterEmployee();
        public IDLRegisterEmployee DLRegisterEmployee { get{ return _DLRegisterEmployee; } }
    }
}
