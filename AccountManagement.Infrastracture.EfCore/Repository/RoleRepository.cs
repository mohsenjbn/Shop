
using _0_Framework.Application;
using _01_framework.Infrastracture;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Infrastracture.EfCore.Repository
{
    public class RoleRepository : RepositoryBase<long, Role>, IRoleRepository
    {
        private readonly AccountContext _context;

        public RoleRepository(AccountContext context):base(context)
        {
            _context = context;
        }

        public Edit GetDetails(long id)
        {
            var role= _context.Roles.Select(p=> new Edit
            {
                Id=p.Id,
                Name=p.Name,
                MapPermissions=MapPermissions(p.Permossions)
            }).AsNoTracking()
            .FirstOrDefault(p=>p.Id == id); 
            
            role.Permissions=role.MapPermissions.Select(p=>p.Code).ToList();

            return role;
        }

        private static List<PermissionDto> MapPermissions(IEnumerable<Permossion> permossions)
        {
            return permossions.Select(p => new PermissionDto(p.Code, p.Id.ToString())).ToList();

           
        }

        public List<RoleViewModel> GetRoles()
        {
            return _context.Roles.Select(p => new RoleViewModel
            {
                CreationDate=p.CreationDate.ToFarsi(),
                Name=p.Name,
                Id=p.Id
                

            }).ToList();
        }
    }
}
