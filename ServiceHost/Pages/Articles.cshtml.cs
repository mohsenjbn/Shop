using _01_ShopQuery.Contracts.Article;
using _01_ShopQuery.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ArticlesModel : PageModel
    {
        private readonly IArticlecategoryQuery _articleCategoryQuery;
        public ArticleCategoryQueryModel ArticleCategory { get; set; }
        public ArticlesModel(IArticlecategoryQuery articlecategoryQuery)
        {
            _articleCategoryQuery = articlecategoryQuery;
        }

        public void OnGet(string id)
        {
            ArticleCategory=_articleCategoryQuery.GetArticlesBy(id);
        }
    }
}
