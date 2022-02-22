using DiscountManagement.Application.Contracts.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;

namespace ServiceHost.Areas.Adminstarator.Pages.Discounts.CustomerDiscounts
{
    public class IndexModel : PageModel
    {
        public List<CustomerDiscountViewModel> CustomerDisCounts { get; set; }
        public SearchCustomerDiscunt Search { get; set; }
        public SelectList Products;

        private readonly ICustomerDiscountApplication _customerDiscountApplication;
        private readonly IProductApplication _productApplication;

        public IndexModel(ICustomerDiscountApplication customerDiscountApplication, IProductApplication productApplication)
        {
            _customerDiscountApplication = customerDiscountApplication;
            _productApplication = productApplication;
        }

        public void OnGet(SearchCustomerDiscunt Search)
        {
            CustomerDisCounts = _customerDiscountApplication.GetAll(Search);
            Products = new SelectList(_productApplication.GetAllProducts(), "Id", "Name");
        }


        public IActionResult OnGetCreate()
        {
            var Define = new DefineCustomerDiscount()
            {
                Products = _productApplication.GetAllProducts()
            };
           
            return Partial("./Create",Define);
        }

        public JsonResult OnPostCreate(DefineCustomerDiscount command)
        {
           var result= _customerDiscountApplication.Define(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var CustomerDiscount = _customerDiscountApplication.GetDetails(id);
            CustomerDiscount.Products = _productApplication.GetAllProducts();
            return Partial("./Edit", CustomerDiscount);
        }

        public JsonResult OnPostEdit(EditCustomerDiscount command)
        {
            var result = _customerDiscountApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
