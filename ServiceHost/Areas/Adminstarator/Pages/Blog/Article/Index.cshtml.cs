using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Adminstarator.Pages.Blog.Article
{
    public class IndexModel : PageModel
    {
        public ArticleSearchModel searchModel { get; set; }
        public List<ArticleViewModel> Articles { get; set; }
        public SelectList ArticleCategories { get; set; }
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        

        public IndexModel( IArticleApplication articleApplication,IArticleCategoryApplication articleCategoryApplication) 
        {
            _articleCategoryApplication=articleCategoryApplication;
            _articleApplication = articleApplication;
        }

        public void OnGet(ArticleSearchModel searchModel)
        {
            Articles = _articleApplication.GetAll(searchModel);
            ArticleCategories = new SelectList(_articleCategoryApplication.GetAll(), "Id", "Name");


        }
    }
}
