using System;
using System.IO;
using Auspex.TripService.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Auspex.TripService
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {

            // app.UseMvc(config =>
            // {
            //      config.MapRoute(
            //          name: "default",
            //          template: "{controller=Car}/{action=GetAll}/{id?}"
            //      );
            // });
            //app.UseMiddleware()

            app.UseMvc();

        }

        public void ConfigureServices(IServiceCollection services)
        {          
            
            // services.AddAuthorization(config => {
            //     config.AddPolicy()
            // })

            services.AddMvc();

            services.AddSingleton<ICarRepository, CarRepository>();  
            services.AddSingleton<ILocationRepository, LocationRepository>();            
            services.AddSingleton<ITripRepository, TripRepository>();            
                      
        }
    }
}