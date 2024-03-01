using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrudPractice.Shared.Model
{
    public class LoginModel
    {
        // [Required]
        public string? Email { get; set; }

        //[Required]
        public string? Password { get; set; }

        public bool RememberMe { get; set; } = false;
    }
}
