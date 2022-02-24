using _01_ShopQuery.Contracts.Article;
using _01_ShopQuery.Contracts.ArticleCategory;
using _01_ShopQuery.Query;
using Blog.Management.Domain.ArticleAgg;
using Blog.Management.Domain.ArticleCategoryAgg;
using BlogManagement.Application;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Infrastracture.EFCore;
using BlogManagement.Infrastracture.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlogManagement.Configuration
{
    public class BlogManagementBootStrapper
    {
        public static void Configure (IServiceCollection service, string connectionstring)
        {
            service.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            service.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            service.AddTransient<IArticleRepository, ArticleRepository>();
            service.AddTransient<IArticleApplication, ArticleApplication>();

            service.AddTransient<IArticleQuery, ArticleQuery>();
            service.AddTransient<IArticlecategoryQuery, ArticlecategoryQuery>();



            service.AddDbContext<BlogContext>(p => p.UseSqlServer(connectionstring));
        }
            
    }


}
