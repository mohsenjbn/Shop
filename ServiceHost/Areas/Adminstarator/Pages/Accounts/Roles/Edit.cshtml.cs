using _01_framework.Infrastracture;
using AccountManagement.Application.Contracts.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Adminstarator.Pages.Accounts.Roles
{
    public class EditModel : PageModel
    {
        private readonly IRoleApplication _roleApplication;
        public List<SelectListItem> Permissions { get; set; }=new List<SelectListItem>();
        private readonly IEnumerable<IPermissionExposer> _exposers;
        public Edit Command { get; set; }
        public EditModel(IRoleApplication roleApplication, IEnumerable<IPermissionExposer> exposers)
        {
            _roleApplication = roleApplication;
            _exposers = exposers;
        }

        public void OnGet(long id)
        {
            Command = _roleApplication.GetDetails(id);
            foreach (var exposer in _exposers)
            {
                var PermissionExposer = exposer.Expose();
                foreach (var (Key,value) in PermissionExposer)
                {
                    var group = new SelectListGroup() { Name = Key };
                    foreach (var permission in value)
                    {
                        var item = new SelectListItem(permission.Name, permission.Code.ToString()) { Group=group};
                        Permissions.Add(item);
                    }
                }
            }
        }

        public IActionResult OnPost(Edit Command)
        {
            _roleApplication.Edit(Command);
            return RedirectToPage("./Index");
        }
    }
}
