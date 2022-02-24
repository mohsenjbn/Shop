using _01_ShopQuery.Contracts;
using _01_ShopQuery.Contracts.ArticleCategory;
using _01_ShopQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class MenuViewComponent:ViewComponent
    {
        private readonly IArticlecategoryQuery _articlecategoryQuery;
        private readonly IProductCategoryQuery _productCategoryQuery;

        public MenuViewComponent(IArticlecategoryQuery articlecategoryQuery, IProductCategoryQuery productCategoryQuery)
        {
            _articlecategoryQuery = articlecategoryQuery;
            _productCategoryQuery = productCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var result = new Menu()
            {
                AericaleCatagories = _articlecategoryQuery.GetAll(),
                ProductCategories=_productCategoryQuery.GetCategoriesWhitProductForMenu()
            };
            return View(result);
        }
    }
}
