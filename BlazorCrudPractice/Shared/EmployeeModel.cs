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
        public int RecId { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string EmployeeMiddleName { get; set; }
        [Required]
        public string EmployeeLastName { get; set; }
        [Required]
        public int EmployeeAge { get; set; }

    }
}
