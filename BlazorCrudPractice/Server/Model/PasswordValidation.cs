using Microsoft.AspNetCore.Identity;

namespace BlazorCrudPractice.Server.Model
{
    public class PasswordValidation : BaseAuthentication, IPasswordValidation
    {

        public User user;
        public string password;

        public PasswordValidation(SignInManager<User> pSignInManager) : base(pSignInManager)
        {

        }

        public async Task<bool> Validate(User pUser, string pPassword)
        {
            this.user = pUser;
            this.password = pPassword;

            this.Validation();
            await this.Initialize();

            return isValid;
        }

        private async Task Initialize()
        {
            if (this.isValid == false) { return; }

            SignInResult result = null;
            this.isValid = false;

            await signInManager.SignOutAsync();
            result = await signInManager.PasswordSignInAsync(this.user, this.password, false, false);

            if (result.Succeeded)
            {

                //var claimEmail = new Claim(ClaimTypes.Email, this.user.Email); ;
                //var claimNameIdentifier = new Claim(ClaimTypes.NameIdentifier, this.user.Id);
                //var claimsIdentity = new ClaimsIdentity(new[] { claimEmail, claimNameIdentifier }, "serverAuth");
                //var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                //await HttpContext.SignInAsync



                this.isValid = true;
            }
        }


        private void Validation()
        {
            this.isValid = false;

            if (this.user != null && !string.IsNullOrWhiteSpace(this.password))
            {
                this.isValid = true;
            }

        }

    }
}
