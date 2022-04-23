using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.OrderAgg;

namespace ShopManagement.Infrastracture.EfCore.Mapping
{
    public class OrderMapping:IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.IssueTrackingNo).HasMaxLength(8).IsRequired(false);

            builder.OwnsMany(p => p.Items, modelBuilder =>
            {
                modelBuilder.ToTable("OrderItems");
                modelBuilder.HasKey(p => p.Id);

                modelBuilder.WithOwner(p => p.Order).HasForeignKey(p => p.OrderId);
            });

        }
    }
}
