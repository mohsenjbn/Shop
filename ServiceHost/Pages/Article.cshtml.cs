using _01_ShopQuery.Contracts.Article;
using CommnetManagement.Application.Contracts.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ArticleModel : PageModel
    {
        public ArticleQueryModel Article;
        private readonly IArticleQuery _articleQuery;
        private readonly ICommentApplication _commentApplication;

        public ArticleModel(IArticleQuery articleQuery,ICommentApplication commentApplication)
        {
            _articleQuery = articleQuery;
            _commentApplication = commentApplication;
        }

        public void OnGet(string id)
        {
            Article=_articleQuery.GetArticleBy(id);
        }

        public IActionResult OnPost(AddComment command,string ArticleSlug)
        {
            command.Type = CommentTypes.Article;
            _commentApplication.AddComment(command);

            return RedirectToPage("/Article", new { Id = ArticleSlug });
        }
        
    }
}
