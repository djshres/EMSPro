using EMSPro.Models.Model;
using Microsoft.EntityFrameworkCore;

namespace EMSPro.Data
{
    public class EMSProContext : DbContext
    {
        public EMSProContext(DbContextOptions<EMSProContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
