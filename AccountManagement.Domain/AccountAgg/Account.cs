using _01_framework.Domain;
using AccountManagement.Domain.RoleAgg;

namespace AccountManagement.Domain.AccountAgg
{
    public class Account : EntityBase
    {
        public string FullName { get; private set; }
        public string UserName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string PassWord { get; private set; }
        public string Profile { get; private set; }
        public long RoleId { get; private set; }
        public Role Role { get; private set; }

        protected Account() { }

        public Account(string fullName, string userName, string phoneNumber, string passWord, string profile, long roleId)
        {
            FullName = fullName;
            UserName = userName;
            PhoneNumber = phoneNumber;
            PassWord = passWord;
            Profile = profile;
            RoleId = roleId;
        }

        public void Edit(string fullName, string userName, string phoneNumber, string profile, long roleId)
        {
            FullName = fullName;
            UserName = userName;
            PhoneNumber = phoneNumber;
            if (!string.IsNullOrWhiteSpace(profile))
                Profile = profile;

            RoleId = roleId;
        }

        public void ChangePassword(string password)
        {
            PassWord = password;

        }
    }
}
