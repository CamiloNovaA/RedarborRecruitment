using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RecruitmentSite.Infrastructure.Data;

namespace RecruitmentSite
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
            // Configuraci�n de la base de datos en memoria para pruebas
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("RecruitmentDb"));

            // Configuraci�n de MediatR para manejar consultas y comandos
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // Configuraci�n de AutoMapper para mapeo de DTOs
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // Configuraci�n de rutas para los controladores
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Candidates}/{action=Index}/{id?}");
            });
        }
    }
} 