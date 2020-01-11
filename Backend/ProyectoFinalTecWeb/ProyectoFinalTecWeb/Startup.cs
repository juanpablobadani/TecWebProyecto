using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProyectoFinalTecWeb.Data;
using ProyectoFinalTecWeb.Data.Repository;
using ProyectoFinalTecWeb.Services;

namespace ProyectoFinalTecWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IGuestService, GuestService>();
            services.AddTransient<IRoomsService, RoomsService>();
            services.AddTransient<IHotelRepository, HotelRepository>();

            services.AddEntityFrameworkSqlServer();
            services.AddDbContext<HotelDBContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("HotelDataBase"))
            );

            services.AddAutoMapper(typeof(Startup));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCors(c => { c.AddPolicy("AllowOrigin", options => { options.AllowAnyOrigin(); options.AllowAnyMethod(); options.AllowAnyHeader(); }); });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors(options => { options.AllowAnyOrigin(); options.AllowAnyMethod(); options.AllowAnyHeader(); });
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

        }
    }
}
