using Microsoft.AspNetCore.Identity;

namespace BlazorCrudPractice.Server.Model
{
    public abstract class BaseAuthentication
    {
        public UserManager<User> userManager { get; }
        public SignInManager<User> signInManager { get; }

        public IConfiguration Configuration = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json").Build();

        public bool isValid { get; set; }

        public BaseAuthentication(UserManager<User> pUserManager,
                                  SignInManager<User> pSignInManager)
        {
            this.userManager = pUserManager;
            this.signInManager = pSignInManager;
        }

        public BaseAuthentication(UserManager<User> pUserManager)
        {
            this.userManager = pUserManager;
        }

        public BaseAuthentication(SignInManager<User> pSignInManager)
        {
            this.signInManager = pSignInManager;
        }

        public BaseAuthentication()
        {
        }
    }
}
