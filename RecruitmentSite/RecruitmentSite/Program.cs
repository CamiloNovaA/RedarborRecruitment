using RecruitmentSite.Infrastructure.Data;

namespace RecruitmentSite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            // Inicializar la base de datos con datos de prueba
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                DatabaseSeeder.Initialize(services);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
