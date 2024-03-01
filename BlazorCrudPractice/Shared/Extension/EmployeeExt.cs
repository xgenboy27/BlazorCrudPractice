using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrudPractice.Shared.Extension
{
    public static class EmployeeExt
    {
        public static void Initialize(this EmployeeModel target, EmployeeModel source)
        {
            target.EmployeeName = source.EmployeeName;
            target.EmployeeMiddleName = source.EmployeeMiddleName;

        }
    }
}
