using EMSPro.Models.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EMSPro.Data
{
    public class EMSProContext : DbContext
    {
        public EMSProContext(DbContextOptions<EMSProContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<PerformanceReview> PerformanceReviews { get; set; }
    }

    class HRProContextFactory : IDesignTimeDbContextFactory<EMSProContext>
    {
        public EMSProContext CreateDbContext(string[]? args = null)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var optionsBuilder = new DbContextOptionsBuilder<EMSProContext>();
            optionsBuilder
                // Uncomment the following line if you want to print generated
                // SQL statements on the console.
                // .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                .UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);

            return new EMSProContext(optionsBuilder.Options);
        }
    }
}
