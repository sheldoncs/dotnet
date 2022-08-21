
using jwtcore.Data;
using jwtcore.Repository.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace jwtcore.DBContextFactory {

     public static class ContextFactory{

        public static IServiceCollection AddAdvisorResourcesServices(this IServiceCollection services, IConfiguration configuration){
            
            
            // services.AddTransient<IAdvisorManagerRepo, AdvisorManagerRepo>();
            services.AddTransient<ICustomAuthenticationManager, CustomAuthenticationManager>();
           
            

            return services;

        }

     }

}