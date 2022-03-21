 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Core_tutorials.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication;

namespace ASP.NET_Core_tutorials { 
    public class Startup
    {
        public IConfiguration _config { get; set; }
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        { 
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("EmployeeDBConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;

            })
                .AddEntityFrameworkStores<AppDbContext>();
            //services.Configure<IdentityOptions>(options =>
            //{
            //    options.Password.RequiredLength = 6;

            //});

            services.AddMvc(options => {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
                });

            services.AddAuthentication().AddGoogle(options =>
            {
                options.ClientId = "594921267182-t76qdfhn76adsttc8hmbbksgkhuu4j8c.apps.googleusercontent.com";
                options.ClientSecret = "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";
            });


            //if someone wants an instance of IEmp.. crfeate an instance of Mock.. and inject that 
            services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithRedirects("/Error/{0 }");
            }

            app.UseRouting();
            //FileServerOptions fso = new FileServerOptions();
            //fso.DefaultFilesOptions.DefaultFileNames.Clear();
            //fso.DefaultFilesOptions.DefaultFileNames.Add("foo.html");
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();

            //doesn t work with UseEndpoints
            //app.UseMvcWithDefaultRoute();
            //app.UseFileServer(fso);

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello world");
                ////});
                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
