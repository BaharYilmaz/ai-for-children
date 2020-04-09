using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIForChildren.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MusteriPaneli.WebApi.Helpers;

namespace AIForChildren
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
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("appsettings:Token").Value);
            
            var connectionString = Environment.GetEnvironmentVariable(Keys.ConnectionString);
            
            if (string.IsNullOrEmpty(connectionString))
            {
                Console.WriteLine("Connection string is not found in environment variables 'AIFORCHILDREN_CONNECTIONSTRING'. I'm using default connection string.");
                connectionString = Configuration.GetConnectionString("DefaultConnection");
            }
            
            bool.TryParse(Environment.GetEnvironmentVariable(Keys.TestProject), out var isTestProject);

            if (!isTestProject)
            {
                //db bağlantı
                services.AddDbContext<DataContext>(x =>
                    x.UseSqlServer(connectionString));
            }
            else
            {
                services.AddDbContext<DataContext>(x =>
                    x.UseSqlServer("aiforchildren_test"));
            }
           

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddJsonOptions(opt =>
            {
                //reference looping hatasına karşı
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            services.AddCors(); //cors conf 
            services.AddScoped<IAppRepository, AppRepository>(); //dependency inversion
            services.AddScoped<IAuthRepository, AuthRepository>();

            //Standard jwt yazımı
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. Yisou may want to change th for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            //middlewares

            app.UseHttpsRedirection();

            //---------------------------yol değişecek------------------------------

            //cors conf. handshake 
            app.UseCors(x => x.WithOrigins("http://localhost:4200/").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
