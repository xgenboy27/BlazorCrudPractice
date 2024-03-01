using BlazorCrudPractice.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrudPractice.Shared.Model
{
    public class LoginResult
    {
        public bool Successful { get; set; }
        public string? Error { get; set; }
        public string? Token { get; set; }

        public bool IsLogout { get; set; }

        public LoginExpiredStatus ExpiredStatus { get; set; }
    }
}
