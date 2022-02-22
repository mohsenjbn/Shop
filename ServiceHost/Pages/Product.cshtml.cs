using _01_ShopQuery.Contracts.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ProductModel : PageModel
    {
        public ProductQueryViewModel product { get; set; }
        private readonly IProductQuery _productQuery;

        public ProductModel( IProductQuery productQuery)
        {
            
            _productQuery = productQuery;
        }

        public void OnGet(string id)
        {
            product=_productQuery.GetProducutBy(id);
        }
    }
}
