using EMSPro.Data;
using EMSPro.Models.Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSPro.App.Helper
{
    public static class SeedHelper
    {
        public static void SeedData(IServiceProvider services)
        {
            // Resolve necessary services
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
                    new Department { Name = "Department A" },
                    new Department { Name = "Department B" }
                // Add more departments as needed
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
                    new Role { Name = "Role A" },
                    new Role { Name = "Role B" }
                // Add more roles as needed
                );

                context.SaveChanges();
            }
        }
    }
}
