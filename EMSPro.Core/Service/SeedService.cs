using EMSPro.Core.IService;
using EMSPro.Data;
using EMSPro.Models.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSPro.Core.Service
{
    public class SeedService : ISeedService
    {
        private readonly EMSProContext _context;

        public SeedService(EMSProContext context)
        {
            _context = context;
        }
        public void SeedDepartment()
        {
            if (!_context.Departments.Any())
            {
                _context.Departments.AddRange(
                    new Department { Name = "HR" },
                    new Department { Name = "IT" },
                    new Department { Name = "Account" }
                );

                _context.SaveChanges();
            }
        }

        public void SeedRole()
        {
            if (!_context.Roles.Any())
            {
                _context.Roles.AddRange(
                    new Role { Name = "Software Engineer" },
                    new Role { Name = "HR Partner" },
                    new Role { Name = "Finance Manager" }
                );

                _context.SaveChanges();
            }
        }
    }
}
