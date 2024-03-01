using BlazorCrudPractice.Server.Model;
using BlazorCrudPractice.Shared.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCrudPractice.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : BaseController // ControllerBase
    {
        private IMainAuthentication mainAuthentication;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private TokenValidation tokenValidation;

        public LoginController(UserManager<User> pUserManager,
                               SignInManager<User> signInManager)
        {
            this.tokenValidation = new TokenValidation(pUserManager, signInManager);
            this.mainAuthentication = new MainAuthentication(pUserManager, signInManager);

        }


        [HttpGet("ValidateToken")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResult>> ValidateToken(string? Token)
        {

            (LoginResult loginResult, this.UserInfo) = await this.tokenValidation.Validate(Token);

            return loginResult;
        }


        [HttpPost("LoginAccount")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResult>> LoginAccount([FromBody] LoginModel loginModel)
        {

            var resourcePath = new Uri($"{Request.Scheme}://{Request.Host}/");
            (LoginResult loginResult, this.UserInfo) = await this.mainAuthentication.Authenticate(loginModel.Email, loginModel.Password);



            return new CreatedResult(resourcePath.ToString(), loginResult);




            //User user = new User()
            //{
            //    Email = login.Email,
            //    UserName = "joey"
            //};

            //var user = await this.userManager.FindByEmailAsync(login.Email);

            //var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);

            //if (!result.Succeeded) return BadRequest(new LoginResult { Successful = false, Error = "Username and password are invalid." });

            //var claims = new[]
            //{
            //    new Claim(ClaimTypes.Name, login.Email!)
            //};

            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]!));
            //var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JwtExpiryInDays"]));

            //var token = new JwtSecurityToken(
            //    _configuration["JwtIssuer"],
            //    _configuration["JwtAudience"],
            //    claims,
            //    expires: expiry,
            //    signingCredentials: creds
            //);

            //return Ok(new LoginResult { Successful = true, Token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
    }
}
