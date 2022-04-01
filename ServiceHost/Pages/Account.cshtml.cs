using AccountManagement.Application.Contracts.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class AccountModel : PageModel
    {
        private readonly IAccountApplication _accountApplication;
        [TempData]
        public string Message { get; set; }
        public AccountModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostRegister(Create command)
        {
          
            command.RoleId= 1;

            var result = _accountApplication.CreateAccount(command);
            if(result.Sucssesed)
            {
                Message = result.Message;
                return RedirectToPage("./Account");
            }
            else
            {
                Message = result.Message;
            }

            return RedirectToPage("./Account");
        }

        public IActionResult OnPostLogin(Login command)
        {
            var result = _accountApplication.Login(command);
            if (result.Sucssesed)
            {
                return RedirectToPage("/Index");
            }
            else
            {
                Message = "نام کاربری یا رمز عبور صحیح نمی باشد";
                return RedirectToPage("./Account");
            }
        }

        public IActionResult OnGetSingout()
        {
            _accountApplication.Logout();
            return RedirectToPage("/Index");
        }
    }
}
