using _01_framework.Application;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Domain.RoleAgg;

namespace AccountManagement.Application
{
    public class RoleApplication : IRoleApplication
    {
        private readonly IRoleRepository _roleRepository;

        public RoleApplication(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public OperationResult Create(Create command)
        {
            var operation = new OperationResult();

            if (_roleRepository.IsExist(p => p.Name == command.Name))
                return operation.Failed(ResultMessage.IsDoblicated);

            var Role = new Role(command.Name,new List<Permossion>() );
            _roleRepository.Create(Role);
            _roleRepository.Savechanges();

            return operation.IsSucssed();
        }

        public OperationResult Edit(Edit command)
        {
            var operation=new OperationResult();
            var role = _roleRepository.GetBy(command.Id);
            if(role==null)
                return operation.Failed(ResultMessage.IsNotExistRecord);
            if (_roleRepository.IsExist(p => p.Name == command.Name && p.Id != command.Id))
                return operation.Failed(ResultMessage.IsDoblicated);
            var permissions = new List<Permossion>();
            command.Permissions.ForEach(Code => permissions.Add(new Permossion(Code)));
            role.Edit(command.Name, permissions);
            _roleRepository.Savechanges();

            return operation.IsSucssed();
        }

        public Edit GetDetails(long id)
        {
            return _roleRepository.GetDetails(id);
        }

        public List<RoleViewModel> GetRoles()
        {
            return _roleRepository.GetRoles();
        }
    }
}
