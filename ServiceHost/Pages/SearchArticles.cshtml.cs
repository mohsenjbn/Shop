using _01_ShopQuery.Contracts.Article;
using _01_ShopQuery.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages;

public class SearchArticles : PageModel
{
    private readonly IArticleQuery _articleQuery;
    public string value { get; set; }
    public List<ArticleQueryModel> Articles { get; set; }
    public SearchArticles(IArticleQuery articleQuery)
    {
        _articleQuery = articleQuery;
    }

    public void OnGet(string id)
    {
        Articles = _articleQuery.Search(id);
        value = id;
    }
}
