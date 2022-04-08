using AccountManagement.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infrastracture.EfCore.Mapping
{
    public class RoleMapping : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Name).HasMaxLength(250);

            builder.OwnsMany(p => p.Permossions, modelbuilder =>
               {
                   modelbuilder.HasKey(x => x.Id);
                   modelbuilder.ToTable("RolePermissions");

                   modelbuilder.WithOwner(p => p.Role);
               });
        }
    }
}
