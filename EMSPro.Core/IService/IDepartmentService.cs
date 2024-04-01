using EMSPro.Models.Model;

namespace EMSPro.Core.IService
{
    public interface IDepartmentService
    {
        IEnumerable<Department> GetAllDepartments();
        void PrintAllDepartments(IEnumerable<Department> departments);
        int ChooseDepartment();
    }
}
