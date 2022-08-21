using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using jwtcore.Repository.Contracts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace jwrcore.Handler {

  public class BasicAuthenticationOptions:AuthenticationSchemeOptions
  {

  }
    public class CustomAuthenticationHandler : AuthenticationHandler<BasicAuthenticationOptions>
    {
        ICustomAuthenticationManager _customAuthenticationManager;
        public CustomAuthenticationHandler(
            IOptionsMonitor<BasicAuthenticationOptions> options, 
            ILoggerFactory logger, 
            UrlEncoder encoder, 
            ISystemClock clock,
            ICustomAuthenticationManager customAuthenticationManager) : base(options, logger, encoder, clock)
        {
            _customAuthenticationManager = customAuthenticationManager;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
           if (!Request.Headers.ContainsKey("Authorization"))
               return AuthenticateResult.Fail("Unauthorized");
           

           string authorizationHeader = Request.Headers["Authorization"];
           if (string.IsNullOrEmpty(authorizationHeader))
               return AuthenticateResult.Fail("Unauthorized");
           
           if (!authorizationHeader.StartsWith("bearer",StringComparison.OrdinalIgnoreCase))
             return AuthenticateResult.Fail("Unauthorized");

           var token = authorizationHeader.Substring("bearer".Length).Trim();
           if (string.IsNullOrEmpty(token))
             return AuthenticateResult.Fail("Unauthorized");

           try {
             return await ValidateToken(token);
           } catch (Exception ex){

               return AuthenticateResult.Fail(ex.Message); 

           }
           
           
        }
        private Task<AuthenticateResult> ValidateToken(string token){
             var validatedToken = _customAuthenticationManager.Tokens.FirstOrDefault(t=>t.Key == token);
            if (validatedToken.Key == null) {
              return Task.FromResult(AuthenticateResult.Fail("Unauthorized"));
            }
            var claims = new List <Claim>
            {
              new Claim(ClaimTypes.Name,validatedToken.Value)
              
            };
            var identity = new ClaimsIdentity(claims,Scheme.Name);
            var principlal = new GenericPrincipal(identity,null);
            var ticket = new AuthenticationTicket(principlal, Scheme.Name);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}




