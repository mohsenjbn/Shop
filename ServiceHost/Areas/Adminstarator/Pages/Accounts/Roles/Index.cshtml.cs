using AccountManagement.Application.Contracts.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Adminstarator.Pages.Accounts.Roles
{
    public class IndexModel : PageModel
    {

        public List<RoleViewModel> Roles { get; set; }

        private readonly IRoleApplication _roleApplication;

        public IndexModel(IRoleApplication roleApplication)
        {

            _roleApplication = roleApplication;
        }
        public void OnGet()
        {

            Roles = _roleApplication.GetRoles();
        }






    }
}