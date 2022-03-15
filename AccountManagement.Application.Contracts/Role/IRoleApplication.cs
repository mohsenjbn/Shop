using _01_framework.Application;

namespace AccountManagement.Application.Contracts.Role
{
    public interface IRoleApplication
    {
        OperationResult Create(Create command);
        OperationResult Edit(Edit command); 
        Edit GetDetails(long id);
        List<RoleViewModel> GetRoles();

    }
}
