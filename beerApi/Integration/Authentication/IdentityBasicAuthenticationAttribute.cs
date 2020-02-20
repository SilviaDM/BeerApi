using beerApi.Integration.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace beerApi.Integration.Authentication
{
    public class IdentityBasicAuthenticationAttribute: BasicAuthenticationAttribute
    {
        protected override async Task<IPrincipal> AuthenticateAsync(string username,
                string password, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested(); // Unfortunately, UserManager doesn't support CancellationTokens.
           
            using (var db = new BeerEntities())
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    return null;
                }

                var userInfo = db.Users.Where(x => x.Username == username && 
                                                    x.Password == password && 
                                                    x.IdStatus == (int)enumGeneralStatus.Active)
                                .FirstOrDefault();
                if (userInfo == null)
                {
                    return null;
                }
            }           

            // Create a ClaimsIdentity with all the claims for this user.
            cancellationToken.ThrowIfCancellationRequested(); // Unfortunately, IClaimsIdenityFactory doesn't support CancellationTokens.
            var identity = new BasicAuthenticationIdentity(username)
            {
               
            };
            return new ClaimsPrincipal(identity);
        }
    }

    public class BasicAuthenticationIdentity : GenericIdentity
    {
        public BasicAuthenticationIdentity(string name) : base(name, "Basic") { }
      
        public string Username { get; set; }       
        public string Fullname { get; set; }        
    }
}