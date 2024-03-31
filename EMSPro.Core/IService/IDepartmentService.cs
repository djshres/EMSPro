using EMSPro.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSPro.Core.IService
{
    public interface IDepartmentService
    {
        IEnumerable<Department> GetAllDepartments();
        void PrintAllDepartments(IEnumerable<Department> departments);
        int ChooseDepartment();
    }
}
