

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.SlideAgg;

namespace ShopManagement.Infrastracture.EfCore.Mapping
{
    public class SlideMapping : IEntityTypeConfiguration<Slide>
    {
        public void Configure(EntityTypeBuilder<Slide> builder)
        {
            builder.ToTable("Slides");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.IsRemoved).IsRequired();
            builder.Property(p => p.Title).HasMaxLength(300).IsRequired();
            builder.Property(p => p.Picture).HasMaxLength(1000).IsRequired();
            builder.Property(p => p.PictureTitle).HasMaxLength(250).IsRequired();
            builder.Property(p => p.PictureAlt).HasMaxLength(250).IsRequired();
            builder.Property(p => p.CreationDate).HasMaxLength(300).IsRequired();
            builder.Property(p => p.CreationDate).HasMaxLength(300).IsRequired();
            builder.Property(p => p.Btntext).HasMaxLength(300).IsRequired();




        }
    }
}
