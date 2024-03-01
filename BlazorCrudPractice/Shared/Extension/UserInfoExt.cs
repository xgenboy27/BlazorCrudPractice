using BlazorCrudPractice.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrudPractice.Shared.Extension
{
    public static class UserInfoExt
    {
        public static void Initialize(this UserInfo destination, UserInfo source)
        {
            destination.UserID = source.UserID;
            destination.FirstName = source.FirstName;
            destination.LastName = source.LastName;
            destination.MiddleName = source.MiddleName;
            destination.UserName = source.UserName;
            destination.Email = source.Email;
            destination.Role = source.Role;
        }
    }
}
