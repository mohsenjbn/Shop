
using _0_Framework.Application;
using _01_framework.Infrastracture;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Domain.RoleAgg;

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
            return _context.Roles.Select(p=> new Edit
            {
                Id=p.Id,
                Name=p.Name
            }).FirstOrDefault(p=>p.Id == id);   
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
