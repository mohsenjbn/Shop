namespace _01_ShopQuery.Contracts.Article
{
    public interface  IArticleQuery
    {
        ArticleQueryModel GetArticleBy(string slug);
        List<ArticleQueryModel> LatestBlog();
    }
}
