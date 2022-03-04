using _0_Framework.Application;
using _01_ShopQuery.Contracts.Article;
using BlogManagement.Infrastracture.EFCore;
using CommantManagement.Infrastracture.EfCore;
using Microsoft.EntityFrameworkCore;

namespace _01_ShopQuery.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly BlogContext _blogContext;
        private readonly CommentContext _commentContext;
        public ArticleQuery(BlogContext blogContext, CommentContext commentContext)
        {
            _blogContext = blogContext;
            _commentContext = commentContext;
        }

        public List<ArticleQueryModel>  Search(string Val)
        {
           return _blogContext.Articles.Where(p=>p.Title.Contains(Val) || p.KeyWords.Contains(Val) || p.ShortDescribtion.Contains(Val)).Select(p=> new ArticleQueryModel
           {
               Title = p.Title,
               KeyWords = p.KeyWords,
               ShortDescribtion = p.ShortDescribtion,
               picture = p.picture,
               pictureTitle = p.pictureTitle,
               PictureAlt = p.PictureAlt,
               Slug = p.Slug
           }).ToList();
        }

        public ArticleQueryModel GetArticleBy(string slug)
        {
           var Article=  _blogContext.Articles.Include(p => p.Category).Select(p => new ArticleQueryModel
            {
                Title = p.Title,
                PictureAlt = p.PictureAlt,
                picture = p.picture,
                pictureTitle = p.pictureTitle,
                Category = p.Category.Name,
                Slug = p.Slug,
                CategorySlug = p.Category.Slug,
                PublishDate = p.PublishDate.ToFarsi(),
                Describtion = p.Describtion,
                Id = p.Id,
                KeyWords=p.KeyWords,
                
                MetaDescribtion=p.MetaDescribtion,
                

            }).FirstOrDefault(p => p.Slug == slug);

            Article.KeyWordList = Article.KeyWords.Split(",").ToList();

            var Comment = _commentContext.Comments.Where(p => !p.Cancel && p.Confirm).Where(p=> p.OwnerRecordId==Article.Id).ToList();

           var ArticleComment=Comment.Select(p => new Contracts.Comment.CommentQyeryModel
            {
                Id = p.Id,
                Message = p.Message,
                Name = p.Name,
                OwnerRecordId = p.OwnerRecordId,
                CreationDate = p.CreationDate.ToFarsi(),
                ParentId = p.ParentId,
               
               
                

            }).OrderByDescending(p=>p.Id).ToList();

            foreach(var item in ArticleComment)
            {
                if(item.ParentId > 0)
                {
                    item.ParentName= Comment.FirstOrDefault(p=>p.Id==item.ParentId).Name;
                }
            }

            Article.Comments = ArticleComment;


            return Article;
        }

        public List<ArticleQueryModel> LatestBlog()
        {
            //return _blogContext.Articles.Include(p => p.Category).Where(p=>p.PublishDate <= DateTime.Now).Select(p => new ArticleQueryModel
            //{
            //    Title=p.Title,
            //    PictureAlt=p.PictureAlt,
            //    picture=p.picture,
            //    pictureTitle=p.pictureTitle,
            //    Category=p.Category.Name,
            //    Slug=p.picture,
            //    CategorySlug=p.Slug,
            //    PublishDate=p.PublishDate.ToFarsi(),
            //    ShortDescribtion=p.ShortDescribtion.Substring(0,Math.Min(p.ShortDescribtion.Length,50))+"..."
            //}).OrderByDescending(p => p.Id).Take(8).ToList();
            var query= _blogContext.Articles
               .Include(x => x.Category)
               .Where(x => x.PublishDate <= DateTime.Now)
               .Select(x => new ArticleQueryModel
               {
                   Id=x.Id,
                   Title = x.Title,
                   Slug = x.Slug,
                   picture = x.picture,
                   PictureAlt = x.PictureAlt,
                   pictureTitle = x.pictureTitle,
                   PublishDate = x.PublishDate.ToFarsi(),
                   ShortDescribtion = x.ShortDescribtion.Substring(0, Math.Min(x.ShortDescribtion.Length, 50)) + "...",
               });

            return query.OrderByDescending(p=>p.Id).Take(7).ToList();
        }
    }
}
