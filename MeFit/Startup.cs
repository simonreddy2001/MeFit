using MeFit.Models;
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
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace MeFit
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    //Access token for postman can be found at http://localhost:3000/#
                    //requires token from keycloak instance - location stored in secret manager
                    IssuerSigningKeyResolver = (token, securityToken, kid, parameters) =>
                    {
                        var client = new HttpClient();
                        var keyuri = "http://localhost:8083/auth/realms/MeFit/protocol/openid-connect/certs";
                        //Retrieves the keys from keycloak instance to verify token
                        var response = client.GetAsync(keyuri).Result;
                        var responseString = response.Content.ReadAsStringAsync().Result;
                        var keys = JsonConvert.DeserializeObject<JsonWebKeySet>(responseString);
                        return keys.Keys;
                    },

                    ValidIssuers = new List<string>
                {
                    "http://localhost:8083/auth/realms/MeFit"
                },

                    //This checks the token for a the 'aud' claim value
                    ValidAudience = "account"
                };
            });
            services.AddControllers();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MeFit", Version = "v1",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Simon reddy",
                        Email = string.Empty,
                        Url = new Uri("https://linkedin.com/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under SIT",
                        Url = new Uri("https://example.com/license"),
                    }
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            services.AddDbContext<MeFitDBContext>(
                opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MeFit v1"));
            }

            app.UseHttpsRedirection();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
