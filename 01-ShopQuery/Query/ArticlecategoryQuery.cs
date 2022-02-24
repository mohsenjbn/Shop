using _0_Framework.Application;
using _01_ShopQuery.Contracts.Article;
using _01_ShopQuery.Contracts.ArticleCategory;
using Blog.Management.Domain.ArticleAgg;
using BlogManagement.Infrastracture.EFCore;
using Microsoft.EntityFrameworkCore;

namespace _01_ShopQuery.Query
{
    public class ArticlecategoryQuery : IArticlecategoryQuery
    {
        private readonly BlogContext _blogContext;

        public ArticlecategoryQuery(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public List<ArticleCategoryQueryModel> GetAll()
        {
            return _blogContext.ArticleCategories.Include(p => p.Articles).Select(p => new ArticleCategoryQueryModel
            {
                Id = p.Id,
                ArticlesCount=p.Articles.Count(),
                Name = p.Name,
                Slug=p.Slug
            }).ToList();
        }

        public ArticleCategoryQueryModel GetArticlesBy(string slug)
        {
            var query= _blogContext.ArticleCategories.Include(p => p.Articles).Select(p => new ArticleCategoryQueryModel
            {
                Id=p.Id,
                Slug=p.Slug,
                MetaDescribtion=p.MetaDescribtion,
                KeyWords=p.KeyWords,
                Name=p.Name,
                Articles=MapArticles(p.Articles)

            }).FirstOrDefault(p => p.Slug == slug);
            if(query.KeyWords !=null)
            {
                query.KeyWordsList = query.KeyWords.Split(",").ToList();

            }
            return query;
        }

        private static List<ArticleQueryModel> MapArticles(List<Article> articles)
        {
            return articles.Select(p => new ArticleQueryModel
            {
                Id=p.Id,
                Slug=p.Slug,
                picture=p.picture,
                pictureTitle=p.pictureTitle,
                PictureAlt=p.PictureAlt,
                PublishDate=p.PublishDate.ToFarsi(),
                Title=p.Title,
                ShortDescribtion=p.ShortDescribtion.Substring(0,Math.Min(p.ShortDescribtion.Length,50))+"..."
            }).ToList();
        }
    }
}
