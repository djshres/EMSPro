using EMSPro.Models.Model;

namespace EMSPro.Core.IService
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        void PrintAllEmployees(IEnumerable<Employee> roles);
        void AddEmployee();
        void UpdateEmployee();
        void DeleteEmployee();
    }
}
