namespace _01_ShopQuery.Contracts.Article
{
    public interface  IArticleQuery
    {
        List<ArticleQueryModel> Search(string Val);

        ArticleQueryModel GetArticleBy(string slug);
        List<ArticleQueryModel> LatestBlog();
    }
}
