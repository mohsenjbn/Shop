using _01_framework.Domain;
using AccountManagement.Application.Contracts.Role;

namespace AccountManagement.Domain.RoleAgg
{
    public interface IRoleRepository:IRepository<long,Role>
    {
        Edit GetDetails(long id);
        List<RoleViewModel> GetRoles();
    }
}
