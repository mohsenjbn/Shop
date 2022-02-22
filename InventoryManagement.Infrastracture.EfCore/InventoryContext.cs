using InventoryManagement.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastracture.EfCore
{
    public class InventoryContext:DbContext
    {
        public DbSet<Inventory> Inventory { get; set; }
        public InventoryContext(DbContextOptions<InventoryContext> options):base(options)
        {

        }

    }
}