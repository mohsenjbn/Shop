using AccountManagement.Application.Contracts.Account;
using AccountManagement.Application.Contracts.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Adminstarator.Pages.Accounts.Users
{
    public class IndexModel : PageModel
    {
        public SelectList Roles;
        public List<AccountViewModel> Accounts { get; set; }
        public AccountSearchModel search;
        private readonly IAccountApplication _accountApplication;
        private readonly IRoleApplication _roleApplication;
        public IndexModel(IAccountApplication accountApplication, IRoleApplication roleApplication)
        {
            _accountApplication = accountApplication;
            _roleApplication = roleApplication;
        }
        public void OnGet(AccountSearchModel search)
        {
            Roles = new SelectList(_roleApplication.GetRoles(), "Id", "Name");
            Accounts = _accountApplication.GetAccounts(search);
        }

        public IActionResult OnGetCreate()
        {
            var command = new AccountManagement.Application.Contracts.Account.Create
            {
                Roles = _roleApplication.GetRoles()
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(AccountManagement.Application.Contracts.Account.Create command)
        {
            var result = _accountApplication.CreateAccount(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var Account = _accountApplication.GetDetails(id);
            Account.Roles = _roleApplication.GetRoles();
            return Partial("./Edit", Account);

        }

        public JsonResult OnPostEdit(AccountManagement.Application.Contracts.Account.Edit command)
        {
            var result = _accountApplication.EditAccount(command);
            return new JsonResult(result);
        }
        

         public IActionResult OnGetChangePassword(long id)
        {
            var password = new ChangePassword()
            {
                Id = id
            };
            return Partial("./ChangePassword", password);

        }

        public JsonResult OnPostChangePassword(AccountManagement.Application.Contracts.Account.ChangePassword command)
        {
            var result = _accountApplication.ChanagePassword(command);
            return new JsonResult(result);
        }

    }
}