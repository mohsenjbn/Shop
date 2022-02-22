using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopiManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.Contracts.Product;

namespace ServiceHost.Areas.Adminstarator.Pages.Shop.Product
{
    public class IndexModel : PageModel
    {
        public SelectList Categories;
        public List<ProductViewModel> Products { get; set; }
        public SearchModelProduct search;
        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;
        public IndexModel(IProductApplication productApplication,IProductCategoryApplication productCategoryApplication)
        {
            _productApplication=productApplication;
            _productCategoryApplication=productCategoryApplication;
        }
        public void OnGet(SearchModelProduct search)
        {
            Categories=new SelectList(_productCategoryApplication.GetCategories(),"Id","Name");
            Products = _productApplication.GetAll(search);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateProduct
            {
                Categories = _productCategoryApplication.GetCategories()
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateProduct commnd)
        {
            var result = _productApplication.Create(commnd);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var product =_productApplication.GetDetails(id);
            product.Categories = _productCategoryApplication.GetCategories();
            return Partial("./Edit", product);
            
        }

        public JsonResult OnPostEdit(EditProduct command)
        {
            var result=_productApplication.Edit(command);
            return new JsonResult(result);
        }


    }
}
