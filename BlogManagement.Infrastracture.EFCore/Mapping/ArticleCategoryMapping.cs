using Blog.Management.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagement.Infrastracture.EFCore.Mapping
{
    public class ArticleCategoryMapping : IEntityTypeConfiguration<ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.ToTable("ArticleCategories");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(500);   
            builder.Property(x => x.KeyWords).HasMaxLength(80);   
            builder.Property(x => x.Slug).HasMaxLength(600);   
            builder.Property(x => x.PictureAlt).HasMaxLength(200);   
            builder.Property(x => x.pictureTitle).HasMaxLength(200);   
            builder.Property(x => x.Describtion).HasMaxLength(10000);   
            builder.Property(x => x.CanonicalAddress).HasMaxLength(1000).IsRequired(false);
            builder.Property(x => x.MetaDescribtion).HasMaxLength(150);
            builder.Property(x => x.picture).HasMaxLength(1000);
        }
    }
}
