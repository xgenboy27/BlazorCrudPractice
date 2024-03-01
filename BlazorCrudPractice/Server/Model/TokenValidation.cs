using BlazorCrudPractice.Shared.Enum;
using BlazorCrudPractice.Shared.Model;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace BlazorCrudPractice.Server.Model
{
    public class TokenValidation : BaseAuthentication //, ITokenValidation
    {
        private GetUserByClaim getUserByClaim;

        private User user;
        private bool isValid;
        private LoginResult loginResult = new LoginResult();

        public TokenValidation(UserManager<User> pUserManager,
                                  SignInManager<User> pSignInManager) : base(pUserManager, pSignInManager)
        {
            this.getUserByClaim = new GetUserByClaim(pUserManager);
        }


        public async Task<(LoginResult, User)> Validate(string pToken) //, string pTimeLeft)
        {
            this.loginResult.Token = pToken;

            this.Validation();
            await this.Initialize();

            return (this.loginResult, this.user);
        }

        private async Task Initialize()
        {
            if (this.isValid == false) { return; }

            DateTime dateUtcNow = DateTime.UtcNow;
            JwtSecurityTokenHandler securityTokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken securityToken = securityTokenHandler.ReadJwtToken(this.loginResult.Token);
            double diffTime = (securityToken.ValidTo - dateUtcNow).TotalMinutes;


            if (securityToken != null && diffTime < 0)
            {
                this.loginResult.ExpiredStatus = LoginExpiredStatus.TokenExpired;
                this.loginResult.IsLogout = true;
            }
            else
            {
                this.loginResult.ExpiredStatus = LoginExpiredStatus.TokenActive;
                this.loginResult.IsLogout = false;
                this.user = await this.getUserByClaim.Get(securityToken.Claims, "Email");
                //this.user = await this.getUserByClaim.Get(securityToken.Claims, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name");
            }

        }



        private void Validation()
        {
            isValid = false;

            if (!string.IsNullOrWhiteSpace(this.loginResult.Token))
            {
                isValid = true;

            }
        }

        //private async Task Initialize()
        //{
        //    //if (this.isValid == false) { return; }

        //    //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Configuration["JwtSecurityKey"]!));
        //    //var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    // Calculate time difference and JWT expiry minutes
        //    //DateTime storedDateTime = DateTime.ParseExact(this.timeLeft, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
        //    //DateTime currentTime = DateTime.UtcNow;
        //    //TimeSpan timeDifference = currentTime - storedDateTime;
        //   // double timeDifferenceMinutes = timeDifference.TotalMinutes;
        //    //double jwtExpiryMinutes = double.Parse(this.Configuration["JwtExpiryMinutes"] ?? "0");








        //    //if (timeDifferenceMinutes < jwtExpiryMinutes)
        //    //{

        //    //    // Read the existing token
        //    //    var tokenHandler = new JwtSecurityTokenHandler();
        //    //    var oldToken = tokenHandler.ReadJwtToken(this.token);

        //    //    // Create new claims based on the existing token
        //    //    var newClaims = oldToken.Claims;

        //    //    // Create a new identity with the existing claims
        //    //    var newIdentity = new ClaimsIdentity(newClaims, oldToken.SignatureAlgorithm);

        //    //    // Create a new claims principal with the new identity
        //    //    var newClaimsPrincipal = new ClaimsPrincipal(newIdentity);

        //    //    // Create a new JWT with the updated expiry time and new claims principal
        //    //    var newToken = new JwtSecurityToken(
        //    //        this.Configuration["JwtIssuer"],
        //    //        this.Configuration["JwtAudience"],
        //    //        newClaimsPrincipal.Claims,
        //    //        notBefore: oldToken.ValidFrom,
        //    //        expires: DateTime.UtcNow.AddMinutes(jwtExpiryMinutes),
        //    //        signingCredentials: creds
        //    //    );

        //    //    // Generate the token string
        //    //    this.token = tokenHandler.WriteToken(newToken);

        //    //}
        //    //else
        //    //{

        //    //    this.token = "TokenExpired";
        //    //}

        //}



    }
}
