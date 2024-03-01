using BlazorCrudPractice.Shared.Model;
using CommonTools;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlazorCrudPractice.Server.Model
{
    public class GetUserToken : BaseAuthentication, IGetUserToken
    {
        private string email;
        private string userToken;
        private User user;
        public GetUserToken()
        {

        }

        public string Get(User pUser)
        {
            this.user = pUser; //.email = pEmail;

            this.Validation();
            this.Initialize();


            return this.userToken;
        }

        private void Initialize()
        {
            if (this.isValid == false) { return; }

            UserInfo userInfo = new UserInfo()
            {
                UserID = this.user.UserID,
                FirstName = this.user.FirstName,
                LastName = this.user.LastName,
                MiddleName = this.user.MiddelName,
                UserName = this.user.UserName,
                Email = this.user.Email,
                Role = this.user.Role
            };




            var claims = new[] { new Claim("Email", this.user.Email) ,
                                 new Claim("UserInfo", JsonConvert.SerializeObject(userInfo))};


            //var claims = new[] { new Claim(ClaimTypes.Name, this.user.Email, "email",this.user.Email, "") ,
            //                     new Claim("UserRole", this.user.Role),
            //                     new Claim("LastName", this.user.LastName)};

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Configuration["JwtSecurityKey"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //var expiry = DateTime.Now.AddDays(Convert.ToInt32(this.Configuration["JwtExpiryInDays"]));
            int jwtExpiryMinutes = ValChk.Cast<int>(this.Configuration["JwtExpiryInMinutes"]);

            var expiry = DateTime.UtcNow.AddMinutes(jwtExpiryMinutes);


            try
            {
                var token = new JwtSecurityToken(this.Configuration["JwtIssuer"],
                                                this.Configuration["JwtAudience"],
                                                claims,
                                                notBefore: DateTime.UtcNow,
                                                expires: expiry,
                                                signingCredentials: creds
                                             );

                this.userToken = new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {

            }




        }

        private void Validation()
        {
            this.isValid = false;
            if (this.user != null)
            {

                this.isValid = true;
            }
        }


    }
}
