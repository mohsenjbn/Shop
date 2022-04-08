using AccountManagement.Application.Contracts.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Adminstarator.Pages.Accounts.Roles
{
    public class CreateModel : PageModel
    {
        private readonly IRoleApplication _roleApplication;
        public Create Command { get; set; }
        public CreateModel(IRoleApplication roleApplication)
        {
            _roleApplication = roleApplication;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost(Create command)
        {
            _roleApplication.Create(command);
            return RedirectToPage("./Index");
        }
    }
}
