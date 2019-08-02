using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using APITest.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace APITest
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<APITestContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddAuthentication(options => { 
                options.DefaultScheme = "Cookies"; 
            }).AddCookie("Cookies", options => {
                options.Cookie.Name = "auth_cookie";
                options.Cookie.SameSite = SameSiteMode.None;
                options.Events = new CookieAuthenticationEvents
                {                          
                    OnRedirectToLogin = redirectContext =>
                    {
                        redirectContext.HttpContext.Response.StatusCode = 401;
                        return Task.CompletedTask;
                    }
                };               
            });
            services.AddCors(); 
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            app.UseCors(policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
                policy.AllowCredentials();
            });

            app.UseAuthentication();
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
