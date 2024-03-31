using EMSPro.Data;
using EMSPro.Models.Model;
using Microsoft.Extensions.DependencyInjection;

namespace EMSPro.App.Helper
{
    public static class SeedHelper
    {
        public static void SeedData(IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                // Seed departments
                SeedDepartments(serviceProvider);

                // Seed roles
                SeedRoles(serviceProvider);
            }
        }

        private static void SeedDepartments(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<EMSProContext>();
            if (!context.Departments.Any())
            {
                context.Departments.AddRange(
                    new Department { Name = "IT" },
                    new Department { Name = "Account" },
                     new Department { Name = "HR" }
                );

                context.SaveChanges();
            }
        }

        private static void SeedRoles(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<EMSProContext>();
            if (!context.Roles.Any())
            {
                context.Roles.AddRange(
                    new Role { Name = "Software Engineer" },
                    new Role { Name = "Accountant" },
                    new Role { Name = "QA Engineer" }
                );

                context.SaveChanges();
            }
        }
    }
}
