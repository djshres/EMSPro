using EMSPro.Core.IService;
using EMSPro.Data;
using EMSPro.Models.Model;

namespace EMSPro.Core.Service
{

    public class RoleService : IRoleService
    {
        private readonly EMSProContext _context;

        public RoleService(EMSProContext context)
        {
            _context = context;
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return _context.Roles.ToList();
        }

        public void PrintAllRoles(IEnumerable<Role> roles)
        {
            foreach (var role in roles)
            {
                Console.WriteLine($"{role.Id}. {role.Name}");
            }
        }

        public int ChooseRole()
        {
            var roles = GetAllRoles();
            Console.WriteLine("Choose a role:");
            foreach (var role in roles)
            {
                Console.WriteLine($"{role.Id}. {role.Name}");
            }

            int choice;
            while (true)
            {
                Console.Write("Enter role ID: ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if (roles.Any(r => r.Id == choice))
                    {
                        return choice;
                    }
                }
                Console.WriteLine("Invalid role ID. Please enter a valid ID.");
            }
        }
    }
}

