using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApplication1.Data;
using WebApplication1.Services;

namespace WebApplication1
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeter, Greeter>();
            services.AddDbContext<WebApplication1DbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("WebApplication1")));
            services.AddScoped<IRestaurantData, SqlRestaurantData>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IGreeter greeter, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
//            else
//            {
//                app.UseExceptionHandler();
//            }
//            app.Use(next => { return async context =>
//            {
//                logger.LogInformation("Request incoming");
//                if (context.Request.Path.StartsWithSegments("/mym"))
//                {
//                    await context.Response.WriteAsync("Hit");
//                    logger.LogInformation("Request handled");
//                }
//                else
//                {
//                    await next(context);
//                    logger.LogInformation("Response outgoing");
//                }
//            }; });
//            app.UseWelcomePage(new WelcomePageOptions
//            {
//                Path = "/wp"
//            });
            app.UseRewriter(new RewriteOptions().AddRedirectToHttpsPermanent());
            app.UseStaticFiles();
           // app.UseMvcWithDefaultRoute();
            app.UseMvc(ConfigureRoutes);
            app.Run(async (context) =>
            {
//                throw new Exception("error");
                var greeting = greeter.GetTheMessageOfheDay();
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync($"Not found");
            });
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
