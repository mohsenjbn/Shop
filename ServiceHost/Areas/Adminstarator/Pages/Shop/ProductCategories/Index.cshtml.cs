
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopiManagement.Application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Adminstarator.Pages.Shop.Products
{
    public class IndexModel : PageModel
    {
        public ProductCategorySearchModel Search { get ; set; }

        public List<ProductCategoryViewModel> ProductCategories { get; set; }
        private readonly IProductCategoryApplication _productCategoryApplication;
        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }
        public void OnGet(ProductCategorySearchModel search)
        {
            ProductCategories=_productCategoryApplication.GetAll(search);
        }


        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateProductCategory() );
        }

        public JsonResult OnpostCreate(CreateProductCategory command)
        {
            
           
                var result = _productCategoryApplication.Create(command);
                return new JsonResult(result);
          
          

        }

        public IActionResult OnGetEdit(long id)
        {
            var productCategory = _productCategoryApplication.GetDetail(id);
            
            return Partial("./Edit", productCategory);

        }
        public JsonResult OnPostEdit(EditProductCategory command)
        {

           
                var result = _productCategoryApplication.Edit(command);
                return new JsonResult(result);
            
                
                
            
            
        }
    }

   
}
