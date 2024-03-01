using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BlazorCrudPractice.Server.Model
{
    public class GetUserByClaim : BaseAuthentication
    {
        private IGetUser getUser;
        private IEnumerable<Claim> claims;
        private User user;
        private string type;

        public GetUserByClaim(UserManager<User> pUserManager) : base(pUserManager, null)
        {
            this.getUser = new GetUser(this.userManager);
        }

        public async Task<User> Get(IEnumerable<Claim> pClaims, string pType)
        {
            this.type = pType;
            this.claims = pClaims;

            this.Validation();
            await this.Initialize();

            return this.user;
        }

        private async Task Initialize()
        {
            if (this.isValid == false) { return; }

            Claim claim = this.claims.Where(c => c.Type == this.type).FirstOrDefault();

            if (claim != null && !string.IsNullOrWhiteSpace(claim.Value))
            {
                this.user = await this.getUser.Get(claim.Value);
            }
        }


        private void Validation()
        {
            this.isValid = false;

            if (this.claims != null &&
               this.claims.Count() > 0 &&
               !string.IsNullOrWhiteSpace(this.type))
            {

                this.isValid = true;
            }
        }
    }
}
