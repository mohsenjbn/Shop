using _01_ShopQuery.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class ArticleCategoriessidebarViewComponent:ViewComponent
    {
        public List<ArticleCategoryQueryModel> ArticleCategoryQueries { get; set; }
        private readonly IArticlecategoryQuery _articlecategoryQuery;

        public ArticleCategoriessidebarViewComponent(IArticlecategoryQuery articlecategoryQuery)
        {
            _articlecategoryQuery = articlecategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            ArticleCategoryQueries=_articlecategoryQuery.GetAll();
            return View(ArticleCategoryQueries);
        }
    }
}
