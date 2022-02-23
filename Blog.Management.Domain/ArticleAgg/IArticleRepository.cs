using _01_framework.Domain;
using BlogManagement.Application.Contracts.Article;

namespace Blog.Management.Domain.ArticleAgg
{
    public interface IArticleRepository:IRepository<long,Article>
    {
        Article GetArticleAndCategoryBy(long id);
        EditArticle GetDetails(long Id);
        List<ArticleViewModel> GetAll(ArticleSearchModel searchModel);
    }
}
