using DiscountManagment.Domain.CustomerDiscountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscontManagement.Infrastracture.EfCore.Mapping
{
    internal class CustomerDiscountMapping : IEntityTypeConfiguration<CustomerDiscount>
    {
        public void Configure(EntityTypeBuilder<CustomerDiscount> builder)
        {
            builder.ToTable("CustomerDisconts");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Reason).HasMaxLength(10000);
        }
    }
}
