using BlazorCrudPractice.Shared.Model;
using Microsoft.AspNetCore.Identity;

namespace BlazorCrudPractice.Server.Model
{
    public class MainAuthentication : BaseAuthentication, IMainAuthentication
    {

        //private int? userID;
        private string emailUserName;
        private string password;
        private User user;
        private IGetUser getUser;
        private IPasswordValidation passwordValidation;
        //private IUsersService usersService;
        private LoginResult loginResult;
        private IGetUserToken getUserToken;

        public MainAuthentication(UserManager<User> pUserManager,
                                  SignInManager<User> pSignInManager) : base(pUserManager, pSignInManager)
        {
            this.getUser = new GetUser(this.userManager);
            this.passwordValidation = new PasswordValidation(this.signInManager);
            //this.usersService = new UsersService();
            this.getUserToken = new GetUserToken();
        }


        public async Task<(LoginResult, User)> Authenticate(string pEmailUserName, string pPassword)
        {
            this.emailUserName = pEmailUserName;
            this.password = pPassword;

            this.Validation();
            await this.Initialize();

            return (this.loginResult, this.user);
        }




        //public async Task<(UserInfo, bool)> Authenticate(int? pUserID)
        //{
        //    this.userInfo = this.usersService.GetUserInfo(pUserID);

        //    this.Validation();
        //    await this.Initialize();

        //    return (this.userInfo, this.isValid);
        //}

        private async Task Initialize()
        {
            if (this.isValid == false) { return; }

            this.user = await this.getUser.Get(this.emailUserName);
            this.isValid = await this.passwordValidation.Validate(user, this.password);

            this.loginResult = new LoginResult();
            this.loginResult.Successful = this.isValid;

            if (this.isValid)
            {

                //generate the jwt token
                this.loginResult.Token = this.getUserToken.Get(this.user);
            }
            else
            {
                this.loginResult.Error = "Username and password are invalid.";
            }
        }

        private void Validation()
        {
            this.isValid = false;
            this.loginResult = new LoginResult();

            if (!string.IsNullOrWhiteSpace(this.emailUserName) &&
                !string.IsNullOrWhiteSpace(this.password))
            {
                this.isValid = true;
            }

            else if (string.IsNullOrWhiteSpace(this.emailUserName) || string.IsNullOrWhiteSpace(this.password))
            {
                this.loginResult.Error = "Email and password should not be empty";
                this.isValid = false;
            }

            else
            {
                this.loginResult.Error = "Something weng wrong";
                this.isValid = false;
            }

        }


    }
}
