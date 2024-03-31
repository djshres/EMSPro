using EMSPro.Core.IService;
using EMSPro.Data;
using EMSPro.Models.Model;

namespace EMSPro.Core.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly EMSProContext _context;

        public DepartmentService(EMSProContext context)
        {
            _context = context;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _context.Departments.ToList();
        }

        public void PrintAllDepartments(IEnumerable<Department> departments)
        {
            foreach (var department in departments)
            {
                Console.WriteLine($"{department.Id}. {department.Name}");
            }
        }

        public int ChooseDepartment()
        {
            var departments = GetAllDepartments();
            Console.WriteLine("Choose a department:");
            foreach (var department in departments)
            {
                Console.WriteLine($"{department.Id}. {department.Name}");
            }

            int choice;
            while (true)
            {
                Console.Write("Enter department ID: ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if (departments.Any(d => d.Id == choice))
                    {
                        return choice;
                    }
                }
                Console.WriteLine("Invalid department ID. Please enter a valid ID.");
            }
        }
    }
}
