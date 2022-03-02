using CommentManagement.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommantManagement.Infrastracture.EfCore.Mapping
{
    public class CommentMapping : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Name).HasMaxLength(100);
            builder.Property(p => p.Email).HasMaxLength(250).IsRequired(false);
            builder.Property(p => p.WebSite).HasMaxLength(500).IsRequired(false);
            builder.Property(p=>p.Message).HasMaxLength(5000); 


        }
    }
}
