using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductPicture;

namespace ServiceHost.Areas.Adminstarator.Pages.Shop.ProductPicture
{
    public class IndexModel : PageModel
    {
        public SelectList Products;
        public List<ProductPictureViewModel> ProductPictures { get; set; }
        public SearchProductPicture search;
        private readonly IProductPictureApplication _productPictureApplication;
        private readonly IProductApplication _productApplication;
        public IndexModel(IProductApplication productApplication, IProductPictureApplication productPictureApplication)
        {
            _productApplication = productApplication;
            _productPictureApplication = productPictureApplication;
        }
        public void OnGet(SearchProductPicture search)
        {
            Products = new SelectList(_productApplication.GetAllProducts(), "Id", "Name");
            ProductPictures = _productPictureApplication.GetAll(search);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateProductPicture
            {
               Products  = _productApplication.GetAllProducts()
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateProductPicture command)
        {
            var result = _productPictureApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var productPicture = _productPictureApplication.GetDetails(id);
            productPicture.Products=_productApplication.GetAllProducts();
            return Partial("./Edit", productPicture);

        }

        public JsonResult OnPostEdit(EditProductPicture command)
        {
            var result = _productPictureApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            var result = _productPictureApplication.IsRemove(id);
            return RedirectToPage("./Index", result);

        }
        public IActionResult OnGetRestore(long id)
        {
            var result = _productPictureApplication.Restore(id);
            return RedirectToPage("./Index", result);

        }
    }
}
