using Microsoft.AspNetCore.Identity;

namespace BlazorCrudPractice.Server.Model
{
    public static class IdentityDefaultUser
    {
        public static async Task CreateDefaultAccount(IApplicationBuilder app)
        {
            IServiceScopeFactory scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();

            using (IServiceScope scope = scopeFactory.CreateScope())
            {
                UserManager<User> userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                RoleManager<IdentityRole> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                string username = "markjason"; // configuration["Data:AdminUser:Name"];
                string email = "markjasonn@mail.com"; // configuration["Data:AdminUser:Email"];
                string password = "Letmein!1797"; // configuration["Data:AdminUser:Password"];
                string role = "Administrator"; ; // configuration["Data:AdminUser:Role"];


                if (await userManager.FindByNameAsync(username) == null)
                {
                    if (await roleManager.FindByNameAsync(role) == null)
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }

                    User user = new User
                    {
                        UserName = username,
                        Email = email,
                        FirstName = "mark",
                        LastName = "gelisanga",
                        MiddelName = "",
                        UserID = 26319

                    };

                    IdentityResult result = await userManager.CreateAsync(user, password);

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, role);
                    }
                }
            }
        }

    }
}
