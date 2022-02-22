using _01_framework.Domain;
using BlogManagement.Application.Contracts.ArticleCategory;

namespace Blog.Management.Domain.ArticleCategoryAgg
{
    public interface  IArticleCategoryRepository:IRepository<long,ArticleCategory>
    {
        EditArticleCategory GetDetails(long id);
        List<ArticleCategoryViewModel> GetAll(ArticleCategorySearchModel searchModel);
    }
}
