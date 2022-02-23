using _01_framework.Domain;
using BlogManagement.Application.Contracts.ArticleCategory;

namespace Blog.Management.Domain.ArticleCategoryAgg
{
    public interface  IArticleCategoryRepository:IRepository<long,ArticleCategory>
    {
        string GetSlugBy(long CategoruId);
        EditArticleCategory GetDetails(long id);
        List<ArticleCategoryViewModel> GetAll(ArticleCategorySearchModel searchModel);
    }
}
