using Blog.Management.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagement.Infrastracture.EFCore.Mapping
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(500);
            builder.Property(x => x.KeyWords).HasMaxLength(80);
            builder.Property(x => x.Slug).HasMaxLength(600);
            builder.Property(x => x.PictureAlt).HasMaxLength(200);
            builder.Property(x => x.pictureTitle).HasMaxLength(200);
            builder.Property(x => x.CanonicalAddress).HasMaxLength(1000).IsRequired(false);
            builder.Property(x => x.MetaDescribtion).HasMaxLength(150);
            builder.Property(x => x.picture).HasMaxLength(1000);

            builder.HasOne(p => p.Category).WithMany(p => p.Articles).HasForeignKey(p => p.CategoryId);
        }
    }
}
