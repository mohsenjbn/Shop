using AccountManagement.Application.Contracts.Role;
using Microsoft.AspNetCore.Http;

namespace AccountManagement.Application.Contracts.Account
{
    public class Create
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string PassWord { get; set; }
        public IFormFile Profile { get; set; }
        public long RoleId { get; set; }
        public List<RoleViewModel> Roles { get; set; }

    }
}
