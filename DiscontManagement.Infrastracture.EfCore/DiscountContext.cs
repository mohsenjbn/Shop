using DiscontManagement.Infrastracture.EfCore.Mapping;
using DiscountManagment.Domain.ColleagueDiscountAgg;
using DiscountManagment.Domain.CustomerDiscountAgg;
using Microsoft.EntityFrameworkCore;

namespace DiscontManagement.Infrastracture.EfCore
{
    public class DiscountContext:DbContext
    {
        public DbSet<CustomerDiscount> CustomerDiscounts { get; set; }
        public DbSet<ColleagueDiscount> ColleagueDiscounts { get; set; }
        public DiscountContext(DbContextOptions<DiscountContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly= typeof(CustomerDiscountMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}