using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrudPractice.Shared.Model
{
    public class EmployeeServiceList
    {
        public int RecId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeMiddleName { get; set; }
        public string EmployeeLastName { get; set; }
        public int EmployeeAge { get; set; }
        public DateTime EmployeeDateOfBirth { get; set; } = DateTime.Now;
        public string EmployeeDateOfBirthStr { get; set; } = string.Empty;
    }
}
