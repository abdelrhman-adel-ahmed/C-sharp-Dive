using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace WebApiCore
{

    class CustomeMiddleWare : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Hellow from Custom Middleware");
            await next(context);
        }
    }
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            //our custome middleware before it hit the routing middleware and after that
            //so the first time here the UseRouting middleware is not called yet so we didnot match a route 
            //to the request path. 
            app.UseMiddleware<EndpointLogging>();

            app.UseRouting();
            
            app.UseMiddleware<EndpointLogging>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context => 
                {
                    //if it use iisexpress it will print iisexperss ,if it use kestral it will print the same name of the project
                    await context.Response.WriteAsync(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
                });
            });
        }

    }
}
