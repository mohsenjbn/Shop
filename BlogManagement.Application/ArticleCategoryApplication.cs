using _0_Framework.Application;
using _01_framework.Application;
using Blog.Management.Domain.ArticleCategoryAgg;
using BlogManagement.Application.Contracts.ArticleCategory;

namespace BlogManagement.Application;

public class ArticleCategoryApplication : IArticleCategoryApplication
{
    private readonly IArticleCategoryRepository _articleCategoryRepository;
    private readonly IFileUploder _fileUploder;
    public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IFileUploder fileUploder)
    {
        _articleCategoryRepository = articleCategoryRepository;
        _fileUploder = fileUploder;
    }

    public OperationResult CreateArticleCategory(CreateArticleCategory command)
    {
        var operation=new OperationResult();
      
        if (_articleCategoryRepository.IsExist(p => p.Name == command.Name))
            return operation.Failed(ResultMessage.IsDoblicated);

        var slug=command.Slug.Slugify();
        var path = $"{"ArticleCategory"}/{slug}";
        var picture = _fileUploder.Upload(command.picture, path);

        var ArticleCategory = new ArticleCategory(command.Name, command.ShowOrder, picture, command.PictureAlt, command.pictureTitle, command.Describtion,
            command.KeyWords, command.MetaDescribtion, slug, command.CanonicalAddress);
        _articleCategoryRepository.Create(ArticleCategory);
        _articleCategoryRepository.Savechanges();

        return operation.IsSucssed();
            
            
    }

    public OperationResult EditArticleCategory(EditArticleCategory command)
    {
        var Operation=new OperationResult();    
    
        var ArticleCategory = _articleCategoryRepository.GetBy(command.Id);
        if (ArticleCategory == null)
            return Operation.Failed(ResultMessage.IsNotExistRecord);

        if (_articleCategoryRepository.IsExist(p => p.Name == command.Name && p.Id != command.Id))
            return Operation.Failed(ResultMessage.IsDoblicated);
        var slug = command.Slug.Slugify();
        var path = $"{"ArticleCategory"}/{slug}";
        var picture = _fileUploder.Upload(command.picture, path);
        ArticleCategory.Edit(command.Name, command.ShowOrder, picture, command.PictureAlt, command.pictureTitle, command.Describtion,
            command.KeyWords, command.MetaDescribtion, slug, command.CanonicalAddress);
        _articleCategoryRepository.Savechanges();

        return Operation.IsSucssed();
    }

    public List<ArticleCategoryViewModel> GetAll(ArticleCategorySearchModel searchModel)
    {
        return _articleCategoryRepository.GetAll(searchModel);
    }

    public EditArticleCategory GetDetails(long id)
    {
        return _articleCategoryRepository.GetDetails(id);
    }
}
