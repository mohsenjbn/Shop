using _01_framework.Infrastracture;

namespace AccountManagement.Application.Contracts.Role
{
    public class Edit : Create
    {
        public long Id { get; set; }
        public List<PermissionDto> MapPermissions { get; set; }
    }


}
