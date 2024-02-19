using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrudPractice.Shared
{
    public class EmployeeModel
    {
        public int RecId { get; set; } = 0;
        //[Required]
        public string EmployeeName { get; set; } = string.Empty;
        //[Required]
        public string EmployeeMiddleName { get; set; } = string.Empty;
        //[Required]
        public string EmployeeLastName { get; set; } = string.Empty;
        //[Required]
        public int EmployeeAge { get; set; } = 0;
        public DateTime EmployeeDateOfBirth { get; set; }= DateTime.Now;
        public string EmployeeDateOfBirthStr { get; set; } = string.Empty;

    }
}
