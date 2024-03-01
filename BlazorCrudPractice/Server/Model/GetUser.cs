using Microsoft.AspNetCore.Identity;

namespace BlazorCrudPractice.Server.Model
{
    public class GetUser : BaseAuthentication, IGetUser
    {
        private User user;
        private string emailUserName;

        public GetUser(UserManager<User> pUserManager) : base(pUserManager)
        {

        }

        public async Task<User> Get(string pEmailUserName)
        {
            this.emailUserName = pEmailUserName;

            this.Validation();
            await this.Initialize();

            return this.user;
        }

        private async Task Initialize()
        {
            if (this.isValid == false) { return; }

            this.user = null;
            this.user = await userManager.FindByNameAsync(this.emailUserName);

            if (this.user == null)
            {
                this.user = await this.userManager.FindByEmailAsync(this.emailUserName);
            }
        }


        private void Validation()
        {
            this.isValid = false;

            if (!string.IsNullOrWhiteSpace(this.emailUserName))
            {
                this.isValid = true;
            }

        }


    }
}
