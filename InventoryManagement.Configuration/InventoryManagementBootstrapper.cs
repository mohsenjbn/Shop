using InventoryManagement.Application;
using InventoryManagement.Application.Contracts.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastracture.EfCore;
using InventoryManagement.Infrastracture.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagement.Configuration
{
    public class InventoryManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionstring)
        {
            services.AddTransient<IInventoryApplication, InventoryApplication>();
            services.AddTransient<IInventoryRepository, InventoryRepository>();

            services.AddDbContext<InventoryContext>(p => p.UseSqlServer(connectionstring));
        }
    }
}
