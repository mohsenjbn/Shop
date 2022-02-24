using _01_ShopQuery.Contracts.Article;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class LastestArticleViewComponent:ViewComponent
    {
        private readonly IArticleQuery _articleQuery;
        public List<ArticleQueryModel> Article { get; set; }
        public LastestArticleViewComponent(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        public IViewComponentResult Invoke()
        {
            Article = _articleQuery.LatestBlog();
            return View(Article);
        }
    }
}
