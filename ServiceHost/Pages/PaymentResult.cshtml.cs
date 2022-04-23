using _01_framework.Application.Zarinpal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class PaymentResultModel : PageModel
    {
        public PaymentResult Result;
        public void OnGet(PaymentResult result)
        {
            Result = result;
        }
    }
}
