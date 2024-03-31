using EMSPro.App;
using EMSPro.App.Helper;
using EMSPro.Core.IService;
using EMSPro.Core.Service;
using EMSPro.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MyApp
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var services = CreateServices();

            SeedHelper.SeedData(services); // Seed departments and roles

            EMSProContext context = services.GetRequiredService<EMSProContext>();
            context.Database.Migrate();

            Application app = services.GetRequiredService<Application>();
            app.Processer();
        }

        private static ServiceProvider CreateServices()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            var serviceProvider = new ServiceCollection()
                .AddDbContext<EMSProContext>(options =>
                {
                    options.UseSqlServer(connectionString);
                })
                .AddScoped<IEmployeeService, EmployeeService>()
                .AddScoped<IDepartmentService, DepartmentService>()
                .AddScoped<IRoleService, RoleService>()// Register IEmployeeService and EmployeeService
                .AddSingleton<Application>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
