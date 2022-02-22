using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Infrastracture.EfCore.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);
            builder.Property(p => p.Name).HasMaxLength(255).IsRequired();
            builder.Property(p => p.Picture).HasMaxLength(1000).IsRequired();
            builder.Property(p => p.Code).HasMaxLength(20).IsRequired();
            builder.Property(p => p.keyWords).HasMaxLength(80).IsRequired();
            builder.Property(p => p.Describtion).HasMaxLength(20000).IsRequired();
            builder.Property(p => p.MetaDescribtion).HasMaxLength(150).IsRequired();
            builder.Property(p => p.Slug).HasMaxLength(300).IsRequired();
            builder.Property(p => p.PictureAlt).HasMaxLength(250).IsRequired();
            builder.Property(p => p.PictureTitle).HasMaxLength(500).IsRequired();
            builder.Property(p => p.ShortDescribtion).HasMaxLength(500).IsRequired();


            builder.HasOne(p => p.ProductCategory).WithMany(p => p.Products).HasForeignKey(p => p.ProductCatagoryId);
            builder.HasMany(p => p.ProductPictures).WithOne(p => p.product).HasForeignKey(p => p.ProductId);

        }
    }
}
