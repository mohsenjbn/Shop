using AccountManagement.Application.Contracts.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Order;

namespace ServiceHost.Areas.Adminstarator.Pages.Shop.Order
{
    public class IndexModel : PageModel
    {
        public OrderSearchModel SearchModel { get; set; }
        public List<OrderViewModel> Orders { get; set; }
        public SelectList Accounts { get; set; }
        private readonly IOrderApplication _orderApplication;
        private readonly IAccountApplication _accountApplication;

        public IndexModel(IOrderApplication orderApplication,IAccountApplication accountApplication)
        {
            _orderApplication = orderApplication;
            _accountApplication= accountApplication;
        }

        public void OnGet(OrderSearchModel SearchModel)
        {
            Orders = _orderApplication.GetAllOrders(SearchModel);
            Accounts = new SelectList(_accountApplication.GetAccounts(), "Id", "FullName");
        }

        public IActionResult OnGetConfirm(long id)
        {
            _orderApplication.PaymentSucceeded(id, 0);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetCancel(long id)
        {
            _orderApplication.IsCanceled(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetItems(long id)
        {
            var items = _orderApplication.GetItemsBy(id);
            return Partial("Items", items);
        }
    }
}
