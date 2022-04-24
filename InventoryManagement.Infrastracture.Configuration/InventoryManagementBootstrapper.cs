using _01_framework.Infrastracture;
using _01_ShopQuery.Contracts.Inventory;
using InventoryManagement.Application;
using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastracture.Configuration.Permissions;
using InventoryManagement.Infrastructure.EfCore;
using InventoryManagement.Infrastructure.EfCore.Repository;
using Invertory.Application.Contracts.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagement.Infrastracture.Configuration
{
    public class InventoryManagementBootstrapper
    {
        public  static void Configure(IServiceCollection services,string connectionstring)
        {
            services.AddTransient<IInventoryApplication, InventoryApplication>();
            services.AddTransient<IInventoryRepository, InventoryRepository>();
            services.AddTransient<IPermissionExposer, InventoryPermissionExposer>();
            services.AddTransient<IInventoryQuery, InventoryQuery>();

            services.AddDbContext<InventoryContext>(p=>p.UseSqlServer(connectionstring));
        }
    }
}