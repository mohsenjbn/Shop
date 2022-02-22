using _01_ShopQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;


namespace ServiceHost.ViewComponents
{
    public class ProductCategoryWithProducts:ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;

        public ProductCategoryWithProducts(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var CategoryWithProducts=_productCategoryQuery.GetAllCategoryWithProducts();
            return View(CategoryWithProducts);
        }
    }
}
