using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using AsyncInn.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AsyncInn
{
    public class Startup
    {
        // Property to enable DI for config file.
        public IConfiguration Configuration { get; }

        // Ctor to enable DI for config file with Configuration prop.
        public Startup()
        {
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();

            builder.AddUserSecrets<Startup>();

            Configuration = builder.Build();
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            // Tell our application to use MVC.
            services.AddMvc();

            // Tell our app to use our default connection string from app settings file.
            services.AddDbContext<AsyncInnDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            // Dependency Injection Mappings
            services.AddTransient<IHotelManager, HotelService>();
            services.AddTransient<IRoomManager, RoomService>();
            services.AddTransient<IAmenitiesManager, AmenitiesService>();
            services.AddTransient<IHotelRoomManager, HotelRoomService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // Tell our app to use controllers for routing, and give the controller URL path setup.
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
