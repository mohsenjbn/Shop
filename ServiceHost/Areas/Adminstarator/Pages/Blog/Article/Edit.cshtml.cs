using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Adminstarator.Pages.Blog.Article
{
    public class EditModel : PageModel
    {
        public EditArticle command { get; set; }

        public SelectList ArticleCategories { get; set; }
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;


        public EditModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(long id)
        {
            command = _articleApplication.GetDetails(id);
            ArticleCategories = new SelectList(_articleCategoryApplication.GetAll(), "Id", "Name");

        }

        public IActionResult OnPost(EditArticle command)
        {
            _articleApplication.EditArticle(command);
            return RedirectToPage("./Index");
        }
    }
}
