using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using jwtcore.Data.Database;
using jwtcore.Repository.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace jwtcore.Data
{
    public class AdvisorManagerRepo : IAdvisorManagerRepo
    {
        private readonly IAdvisorDbContext _context;
        private readonly IConfiguration _Configuration;

        public AdvisorManagerRepo(IAdvisorDbContext context, IConfiguration Configuration)
        {
            _context = context;
            _Configuration = Configuration;
        }

        public string Authenticate(string username, string password)
        {
             
            var obj =
                _context
                    .Authentications
                    .Where(a =>
                        a.Username == username && a.Password == password)
                    .SingleOrDefault();

                 
            if (obj != null)
            {
             
                var tokenHandler = new JwtSecurityTokenHandler();
                
                var secret = _Configuration["Authenticate:Secret"];
                 
                var tokenKey = Encoding.ASCII.GetBytes(secret);

                var tokenDescriptor =
                    new SecurityTokenDescriptor {
                        Subject =
                            new ClaimsIdentity(new Claim[] {
                                    new Claim(ClaimTypes.Name, username)
                                }),
                        Expires = DateTime.UtcNow.AddHours(1),
                        SigningCredentials =
                            new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                                SecurityAlgorithms.HmacSha256Signature)
                    };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            
            return null;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

      
    }
}
