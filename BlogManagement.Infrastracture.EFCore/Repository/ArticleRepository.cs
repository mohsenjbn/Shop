using _0_Framework.Application;
using _01_framework.Infrastracture;
using Blog.Management.Domain.ArticleAgg;
using BlogManagement.Application.Contracts.Article;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastracture.EFCore.Repository
{
    public class ArticleRepository : RepositoryBase<long, Article>, IArticleRepository
    {
        private readonly BlogContext _context;

        public ArticleRepository(BlogContext context):base(context)
        {
            _context = context;
        }

        public List<ArticleViewModel> GetAll(ArticleSearchModel searchModel)
        {
            var query = _context.Articles.Include(p => p.Category).Select(p => new ArticleViewModel
            {
                Id= p.Id,
                Category=p.Category.Name,
                CategoryId= p.Category.Id,
                picture=p.picture,
                PublishDate= p.PublishDate.ToFarsi(),
                ShortDescribtion=p.ShortDescribtion,
                Title=p.Title
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Title))
                query = query.Where(p => p.Title == searchModel.Title);

            if (searchModel.CategoryId > 0)
                query = query.Where(p => p.CategoryId == searchModel.CategoryId);

            return query.OrderByDescending(p => p.Id).ToList();
        }

        public Article GetArticleAndCategoryBy(long id)
        {
            return _context.Articles.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
        }

        public EditArticle GetDetails(long Id)
        {
            return _context.Articles.Select(p => new EditArticle
            {
                CanonicalAddress=p.CanonicalAddress,
                Id=p.Id,
                CategoryId=p.CategoryId,
                Describtion=p.Describtion,
                KeyWords=p.KeyWords,
                MetaDescribtion=p.MetaDescribtion,
                //picture=p.picture,
                PictureAlt=p.PictureAlt,
                pictureTitle=p.pictureTitle,
                PublishDate=p.PublishDate.ToFarsi(),
                ShortDescribtion=p.ShortDescribtion,
                Slug=p.Slug,
                Title=p.Title
                
                
            }).FirstOrDefault(p => p.Id == Id);
        }
    }
}
