using _01_framework.Domain;
using AccountManagement.Domain.AccountAgg;

namespace AccountManagement.Domain.RoleAgg
{

    public class Role:EntityBase
    {
        public string Name { get;private set; }

        public List<Account> Accounts { get;private set; }
        public List<Permossion> Permossions { get; set; }

        protected Role()
        {

        }

        public Role(string name,List<Permossion> permossions)
        {
            Name = name;
            Permossions = permossions;
            Accounts = new List<Account>();
        }

        public void Edit(string name, List<Permossion> permossions)
        {
            Name = name;
            Permossions = permossions;

        }
    }
}
