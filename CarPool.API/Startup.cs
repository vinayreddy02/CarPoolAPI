using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CarPoolApplication.Services;
using CarPoolApplication.Services.Intefaces;
using CarPoolApplication.DataBase;
using Microsoft.EntityFrameworkCore;

namespace CarPoolWebAPI
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
            services.AddControllers();
            services.AddTransient<IUserServices, UserServices>();
            services.AddTransient<IOfferServices,OfferServices>();
            services.AddTransient<IBooKingServices,BookingServices>();
            services.AddTransient<ILocationServices,LocationServices>();
            services.AddTransient<IVehicleServices, VehicleServices>();
            services.AddTransient<IStationServices, StationServices>();
            services.AddDbContext<CarpoolDBContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("SQLConnection")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
