using EMSPro.Core.IService;
using EMSPro.Data;
using EMSPro.Models.Model;
using Microsoft.EntityFrameworkCore;

namespace EMSPro.Core.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EMSProContext _context;
        private readonly IRoleService _roleService;
        private readonly IDepartmentService _departmentService;

        public EmployeeService(EMSProContext context, IRoleService roleService,
            IDepartmentService departmentService)
        {
            _roleService = roleService;
            _departmentService = departmentService;
            _context = context;
        }

        // Time complexity: O(n)
        // Space complexity: O(n)
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees.Include(x => x.Department).Include(x => x.Role).ToList();
        }

        // Time complexity: O(n)
        // Space complexity: O(1)
        public void PrintAllEmployees(IEnumerable<Employee> employees)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine($"ID: {employee.Id}");
                Console.WriteLine($"Name: {employee.Name}");
                Console.WriteLine($"Position: {employee.Position}");
                Console.WriteLine($"Salary: {employee.Salary}");
                Console.WriteLine($"Contact Info: {employee.ContactInfo}");

                // Fetch the department name associated with the employee's department ID
                Console.WriteLine($"Department: {employee.Department.Name}");

                Console.WriteLine($"Role ID: {employee.Role.Name}");
                Console.WriteLine(); // Add an empty line for better readability between employees
            }

        }

        // Time complexity: O(1)
        // Space complexity: O(1)
        public void AddEmployee()
        {
            Console.WriteLine("Enter employee details:");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Position: ");
            string position = Console.ReadLine();

            Console.Write("Salary: ");
            decimal salary;
            while (!decimal.TryParse(Console.ReadLine(), out salary))
            {
                Console.WriteLine("Invalid input. Please enter a valid decimal value for salary.");
                Console.Write("Salary: ");
            }

            Console.Write("Contact Info: ");
            string contactInfo = Console.ReadLine();

            // Assuming you have a method to fetch departments and roles
            var departmentId = _departmentService.ChooseDepartment();
            var roleId = _roleService.ChooseRole();

            var employee = new Employee
            {
                Name = name,
                Position = position,
                Salary = salary,
                ContactInfo = contactInfo,
                DepartmentId = departmentId,
                RoleId = roleId
            };

            _context.Employees.Add(employee);
            _context.SaveChanges();

            Console.WriteLine("New employee added successfully.");
        }

        // Time complexity: O(1)
        // Space complexity: O(1)
        public void UpdateEmployee()
        {
            Console.WriteLine("Enter employee ID to update:");
            int employeeId;
            while (!int.TryParse(Console.ReadLine(), out employeeId))
            {
                Console.WriteLine("Invalid input. Please enter a valid employee ID.");
                Console.Write("Employee ID: ");
            }

            var employee = GetEmployeeById(employeeId);
            if (employee == null)
            {
                return;
            }

            Console.WriteLine("Current employee details:");
            Console.WriteLine($"Name: {employee.Name}");
            Console.WriteLine($"Position: {employee.Position}");
            Console.WriteLine($"Salary: {employee.Salary}");
            Console.WriteLine($"Contact Info: {employee.ContactInfo}");
            Console.WriteLine($"Department ID: {employee.DepartmentId}");
            Console.WriteLine($"Role ID: {employee.RoleId}");

            // You can prompt the user to update any field they want
            Console.WriteLine("Enter new details (leave blank to keep existing):");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
            {
                employee.Name = name;
            }

            Console.Write("Position: ");
            string position = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(position))
            {
                employee.Position = position;
            }

            Console.Write("Salary: ");
            decimal salary;
            string salaryInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(salaryInput) && decimal.TryParse(salaryInput, out salary))
            {
                employee.Salary = salary;
            }

            Console.Write("Contact Info: ");
            string contactInfo = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(contactInfo))
            {
                employee.ContactInfo = contactInfo;
            }

            var departmentId = _departmentService.ChooseDepartment();
            if (departmentId != 0)
            {
                employee.DepartmentId = departmentId;
            }

            var roleId = _roleService.ChooseRole();
            if (roleId != 0)
            {
                employee.RoleId = roleId;
            }

            _context.Employees.Update(employee);
            _context.SaveChanges();

            Console.WriteLine("Employee updated successfully.");
        }

        // Time complexity: O(1) on average, O(n) worst case
        // Space complexity: O(1)
        public Employee GetEmployeeById(int id)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.Id == id);
            return employee;
        }


        // Time complexity: O(1)
        // Space complexity: O(1)
        public void DeleteEmployee()
        {
            Console.WriteLine("Enter employee ID to delete:");
            int employeeId;
            while (!int.TryParse(Console.ReadLine(), out employeeId))
            {
                Console.WriteLine("Invalid input. Please enter a valid employee ID.");
                Console.Write("Employee ID: ");
            }

            _context.Employees.Remove(GetEmployeeById(employeeId));
            _context.SaveChanges();
            Console.WriteLine($"Employee with ID {employeeId} deleted successfully.");
        }
    }
}
