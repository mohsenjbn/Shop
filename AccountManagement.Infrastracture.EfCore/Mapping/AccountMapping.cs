using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infrastracture.EfCore.Mapping
{
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.UserName).HasMaxLength(250);
            builder.Property(p => p.FullName).HasMaxLength(250);
            builder.Property(p => p.PhoneNumber).HasMaxLength(30);

            builder.HasOne(p=>p.Role).WithMany(p=>p.Accounts).HasForeignKey(p=>p.RoleId);
        }
    }
}
