using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Adminstarator.Pages.Blog.ArticleCategories;

public class IndexModel : PageModel
{
    public ArticleCategorySearchModel Search { get; set; }

    public List<ArticleCategoryViewModel> ArticleCategories { get; set; }
    private readonly IArticleCategoryApplication _articleCategoryApplication;
    public IndexModel(IArticleCategoryApplication articleCategoryApplication)
    {
        _articleCategoryApplication = articleCategoryApplication;
    }
    public void OnGet(ArticleCategorySearchModel search)
    {
        ArticleCategories = _articleCategoryApplication.GetAll(search);
    }


    public IActionResult OnGetCreate()
    {
        return Partial("./Create", new CreateArticleCategory());
    }

    public JsonResult OnpostCreate(CreateArticleCategory command)
    {


        var result = _articleCategoryApplication.CreateArticleCategory(command);
        return new JsonResult(result);



    }

    public IActionResult OnGetEdit(long id)
    {
        var ArticleCategory = _articleCategoryApplication.GetDetails(id);

        return Partial("./Edit", ArticleCategory);

    }
    public JsonResult OnPostEdit(EditArticleCategory command)
    {


        var result = _articleCategoryApplication.EditArticleCategory(command);
        return new JsonResult(result);

    }
}
