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

        public IActionResult OnGetCreate()
        {
            
            return Partial("./Create");
        }

        public JsonResult OnPostCreate(Create command)
        {
            var result = _roleApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var role = _roleApplication.GetDetails(id);
            
            return Partial("./Edit", role);

        }

        public JsonResult OnPostEdit(Edit command)
        {
            var result = _roleApplication.Edit(command);
            return new JsonResult(result);
        }
        

  
    }
}