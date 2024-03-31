using EMSPro.Models.Model;

namespace EMSPro.Core.IService
{
    public interface IRoleService
    {
        IEnumerable<Role> GetAllRoles();
        void PrintAllRoles(IEnumerable<Role> roles);
        int ChooseRole();
    }
}
