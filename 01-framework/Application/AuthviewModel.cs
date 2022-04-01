namespace _01_framework.Application
{
    public class AuthviewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public long RoleId { get; set; }
        public string Role { get; set; }

        public AuthviewModel(long id, string name, string userName, string phoneNumber, long roleId, string role)
        {
            Id = id;
            Name = name;
            UserName = userName;
            PhoneNumber = phoneNumber;
            RoleId = roleId;
            Role = role;
        }
    }
}
