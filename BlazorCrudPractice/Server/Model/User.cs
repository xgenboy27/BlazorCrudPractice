using Microsoft.AspNetCore.Identity;

namespace BlazorCrudPractice.Server.Model
{
    public class User : IdentityUser
    {
        public int UserID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddelName { get; set; }
        public string? Password { get; set; }

        public string? Role { get; set; }
    }
}
