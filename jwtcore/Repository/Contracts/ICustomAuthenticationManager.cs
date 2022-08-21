using System.Collections.Generic;

namespace jwtcore.Repository.Contracts
{

   public interface ICustomAuthenticationManager {
        

        string Authenticate(string username,string password);

        IDictionary<string, string> Tokens {get; }

   }

}