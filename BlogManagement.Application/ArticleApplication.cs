using _0_Framework.Application;
using _01_framework.Application;
using Blog.Management.Domain.ArticleAgg;
using Blog.Management.Domain.ArticleCategoryAgg;
using BlogManagement.Application.Contracts.Article;

namespace BlogManagement.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleReposirory;
        private readonly IFileUploder _fileUploder;
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleApplication(IArticleRepository articleReposirory, IFileUploder fileUploder, IArticleCategoryRepository articleCategoryRepository)
        {
            _articleReposirory = articleReposirory;
            _fileUploder = fileUploder;
            _articleCategoryRepository = articleCategoryRepository;
        }

        public OperationResult CreateArticle(CreateArticle command)
        {
            var operation=new OperationResult();
            if (_articleReposirory.IsExist(p => p.Title == command.Title))
                return operation.Failed(ResultMessage.IsDoblicated);

            var slug=command.Slug.Slugify();
            var publishDate = command.PublishDate.ToGeorgianDateTime();
            var SlugCa = _articleCategoryRepository.GetSlugBy(command.CategoryId);
            var path = $"{"ArticleCategory"}/{SlugCa}/{command.Slug}";
            var picture = _fileUploder.Upload(command.picture, path);

            var Article = new Article(command.Title, command.Slug, command.ShortDescribtion, command.Describtion,
                picture, command.PictureAlt, command.pictureTitle, publishDate, command.MetaDescribtion, command.KeyWords, command.CanonicalAddress
                , command.CategoryId);

            _articleReposirory.Create(Article);
            _articleReposirory.Savechanges();

            return operation.IsSucssed();
            
        }

        public List<ArticleViewModel> GetAll(ArticleSearchModel searchModel)
        {
            return _articleReposirory.GetAll(searchModel);
        }

        public EditArticle GetDetails(long Id)
        {
            return _articleReposirory.GetDetails(Id);
        }

        public OperationResult EditArticle(EditArticle command)
        {
            var Operation = new OperationResult();
            var Article = _articleReposirory.GetArticleAndCategoryBy(command.Id);

            if (Article == null)
                return Operation.Failed(ResultMessage.IsNotExistRecord);

            if (_articleReposirory.IsExist(p => p.Title == command.Title && p.Id != command.Id))
                return Operation.Failed(ResultMessage.IsDoblicated);

            var slug = command.Slug.Slugify();
            var publishDate = command.PublishDate.ToGeorgianDateTime();
            var path = $"{"ArticleCategory"}/{Article.Category.Slug}/{command.Slug}";
            var picture = _fileUploder.Upload(command.picture, path);
            Article.Edit(command.Title, command.Slug, command.ShortDescribtion, command.Describtion,
                picture, command.PictureAlt, command.pictureTitle, publishDate, command.MetaDescribtion, command.KeyWords, command.CanonicalAddress
                , command.CategoryId);

            
            _articleReposirory.Savechanges();
            return Operation.IsSucssed();
        }
    }
}
