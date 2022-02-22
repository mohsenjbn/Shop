using _0_Framework.Application;
using _01_framework.Infrastracture;
using Blog.Management.Domain.ArticleCategoryAgg;
using BlogManagement.Application.Contracts.ArticleCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Infrastracture.EFCore.Repository
{
    public class ArticleCategoryRepository : RepositoryBase<long, ArticleCategory>, IArticleCategoryRepository
    {
        private readonly BlogContext _context;
        public ArticleCategoryRepository(BlogContext context):base(context)
        {
            _context=context;
        }
        List<ArticleCategoryViewModel> IArticleCategoryRepository.GetAll(ArticleCategorySearchModel searchModel)
        {
            var query = _context.ArticleCategories.Select(p => new ArticleCategoryViewModel
            {
                CreationDate=p.CreationDate.ToFarsi(),
                Describtion=p.Describtion,
                Id=p.Id,
                Name=p.Name,
                picture=p.picture,
                ShowOrder=p.ShowOrder,
            });

            if(!string.IsNullOrEmpty(searchModel.Name))
                query=query.Where(p=>p.Name==searchModel.Name);

            return query.OrderByDescending(p=>p.Id).ToList();
        }

        EditArticleCategory IArticleCategoryRepository.GetDetails(long id)
        {
            return _context.ArticleCategories.Select(p=> new EditArticleCategory
            {
                Id=id,
                CanonicalAddress=p.CanonicalAddress,
                Describtion=p.Describtion,
                KeyWords=p.KeyWords,
                MetaDescribtion=p.MetaDescribtion,
                Name=p.Name,
                PictureAlt=p.PictureAlt,
                pictureTitle=p.pictureTitle,
                ShowOrder=p.ShowOrder,
                Slug=p.Slug
                
            }).FirstOrDefault(p=>p.Id==id);
        }
    }
}
