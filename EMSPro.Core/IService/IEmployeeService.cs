using EMSPro.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
