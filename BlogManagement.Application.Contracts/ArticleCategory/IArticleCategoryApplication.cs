using _01_framework.Application;

namespace BlogManagement.Application.Contracts.ArticleCategory
{
    public interface  IArticleCategoryApplication
    {
        OperationResult CreateArticleCategory(CreateArticleCategory command);
        OperationResult EditArticleCategory(EditArticleCategory command);
        EditArticleCategory GetDetails(long id);
        List<ArticleCategoryViewModel> GetAll(ArticleCategorySearchModel searchModel);
    }
}
