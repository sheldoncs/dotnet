using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using jwrcore.Handler;
using jwtcore.Configuration.Library;
using jwtcore.Data;
using jwtcore.DBContextFactory;
using jwtcore.Kafka.Consumer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using jwtcore.CollectionFactory;
using jwtcore.Configuration;
using jwtcore.Data.Database;

namespace jwtcore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //KafkaConfiguration kafkaConfiguration = new KafkaConfiguration(Configuration);
            //services.AddSingleton(kafkaConfiguration);
            services.AddKafkaConsumer<AccountConsumer>().Addkafka();
            
            services.AddControllers().AddNewtonsoftJson(s => {
                  s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var secret = Configuration["Authenticate:Secret"];
                 
            // services.AddAuthentication(x=>{

            //     x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //     x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            // }).AddJwtBearer(x=>{

            //     x.RequireHttpsMetadata=false;
            //     x.SaveToken=true;
            //     x.TokenValidationParameters = new TokenValidationParameters
            //     {
            //         ValidateIssuerSigningKey =true,
            //         IssuerSigningKey = new SymmetricSecurityKey( Encoding.ASCII.GetBytes(secret)),
            //         ValidateIssuer = false,
            //         ValidateAudience = false,

            //     };

            // });
             

           services.AddAuthentication("Basic").AddScheme<BasicAuthenticationOptions,CustomAuthenticationHandler>("Basic",null);
          
            services.AddDbContext<DatabaseContext>(opt => {

                 opt.UseMySQL(Configuration.GetConnectionString("AdvisorConnection"));
            });
            
            services.AddAdvisorResourcesServices(Configuration);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "jwtcore", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "jwtcore v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

           
            
        }
    }
}
