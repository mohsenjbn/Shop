using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Infrastracture.EfCore.Mapping
{
    public class ProductPictureMapping : IEntityTypeConfiguration<ProductPicture>
    {
        public void Configure(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.ToTable("ProductPicture");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Picture).HasMaxLength(1000).IsRequired();
            builder.Property(p => p.PictureAlt).HasMaxLength(250).IsRequired();
            builder.Property(p => p.PictureTitle).HasMaxLength(250).IsRequired();
            builder.Property(p => p.CreationDate).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();
            builder.Property(p => p.ProductId).HasMaxLength(10000000).IsRequired();

            builder.HasOne(p => p.product).WithMany(p=>p.ProductPictures).HasForeignKey(p => p.ProductId);




        }
    }
}
