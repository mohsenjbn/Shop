using CommantManagement.Infrastracture.EfCore;
using CommantManagement.Infrastracture.EfCore.Repository;
using CommentManagement.Application;
using CommentManagement.Domain.CommentAgg;
using CommnetManagement.Application.Contracts.Comment;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CommentManagement.infrastracture.Configuration
{
    public static class CommentManagementBootStrapper
    {

        public static void Configure(IServiceCollection service,string connectionstring)
        {
            service.AddTransient<ICommentRepository, CommentRepository>();
            service.AddTransient<ICommentApplication, CommentApplication>();


            service.AddDbContext<CommentContext>(p => p.UseSqlServer(connectionstring));
        }
    }
}