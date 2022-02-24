using _01_ShopQuery.Contracts.Article;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class RecentPostsViewcomponent:ViewComponent
    {
        private readonly IArticleQuery _articleQuery;
        public List<ArticleQueryModel> RecentArticles { get; set; }

        public RecentPostsViewcomponent(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        public IViewComponentResult Invoke()
        {
            RecentArticles = _articleQuery.LatestBlog();
            return View(RecentArticles);
        }
    }
}
