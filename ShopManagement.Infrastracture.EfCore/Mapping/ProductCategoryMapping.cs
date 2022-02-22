

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sh.Domain.ProductCategoryAgg;

namespace ShopManagement.Infrastracture.EfCore.Mapping
{
    public class ProductCategoryMapping : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategories");
            builder.HasKey(x => x.Id);

            builder.Property(p=>p.Name).HasMaxLength(255).IsRequired();
            builder.Property(p => p.Describtion).HasMaxLength(500);
            builder.Property(p => p.PictureAlt).HasMaxLength(255);
            builder.Property(p => p.PictureTitle).HasMaxLength(255);
            builder.Property(p => p.Picture).HasMaxLength(1000);
            builder.Property(p => p.KeyWords).HasMaxLength(80).IsRequired();
            builder.Property(p => p.CreationDate).IsRequired();
            builder.Property(p => p.MetaDescribtion).HasMaxLength(150).IsRequired();
            builder.Property(p => p.Slug).HasMaxLength(300).IsRequired();


            builder.HasMany(p=>p.Products).WithOne(p=>p.ProductCategory).HasForeignKey(p=>p.ProductCatagoryId);

        }
    }
}
