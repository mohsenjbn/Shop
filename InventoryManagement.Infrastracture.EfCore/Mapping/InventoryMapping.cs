using InventoryManagement.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Infrastracture.EfCore.Mapping
{
    public class InventoryMapping : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("Inventory");
            builder.HasKey(x => x.Id);


            builder.OwnsMany(p => p.Operations, modelbuilder =>
               {
                   modelbuilder.ToTable("InventoryOperations");
                   modelbuilder.HasKey(x => x.Id);

                   modelbuilder.Property(p => p.Describtion).HasMaxLength(1000);
                   modelbuilder.WithOwner(p=>p.Inventory).HasForeignKey(p => p.InventoryId);
               });
        }
    }
}
