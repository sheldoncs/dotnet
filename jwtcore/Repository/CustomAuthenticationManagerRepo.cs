using System;
using System.Collections.Generic;
using System.Linq;
using jwtcore.Data.Database;
using jwtcore.Repository.Contracts;
using Microsoft.Extensions.Configuration;

namespace jwtcore.Data
{

    public class CustomAuthenticationManager : ICustomAuthenticationManager
    {

        private readonly DatabaseContext _context;
        private readonly IConfiguration _Configuration;
        private readonly IDictionary<string, string> tokens = new Dictionary<string,string>();
        public IDictionary<string, string> Tokens  => tokens;

        public CustomAuthenticationManager (DatabaseContext context, IConfiguration Configuration){
             
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

                 
            if (obj == null)
            {
                return null;
            }
           var token = Guid.NewGuid().ToString();
           tokens.Add(token,username); 
           
           return token;
        }


    }

    


    
}