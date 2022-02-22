using InventoryManagement.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Infrastructure.EfCore.Mappings
{
    public class InventoryMapping : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("Inventory");
            builder.HasKey(x => x.Id);



            builder.OwnsMany(P => P.Operations, modelbuilder =>
               {
                   modelbuilder.ToTable("InventoryOperations");
                   modelbuilder.HasKey(x => x.Id);
                   modelbuilder.Property(p => p.Describtion).HasMaxLength(1000);

                   modelbuilder.WithOwner(p => p.inventory).HasForeignKey(p => p.InventoryId);

               });

        }
    }
}
