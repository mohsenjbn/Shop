using _01_ShopQuery.Contracts.Product;
using _01_ShopQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class CategoryModel : PageModel
    {
        public ProductCategoryQueryModel Category { get; set; }
        private readonly IProductCategoryQuery _productCateguryquery;

        public CategoryModel(IProductCategoryQuery productCateguryquery)
        {
            _productCateguryquery = productCateguryquery;
        }

        public void OnGet(string id)
        {
            Category = _productCateguryquery.GetProductCategoryandProductsBy(id);

        }
    }
}
