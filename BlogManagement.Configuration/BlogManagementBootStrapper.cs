using Blog.Management.Domain.ArticleCategoryAgg;
using BlogManagement.Application;
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

            service.AddDbContext<BlogContext>(p => p.UseSqlServer(connectionstring));
        }
            
    }


}
