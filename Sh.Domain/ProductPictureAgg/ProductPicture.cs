

using _01_framework.Domain;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public  class ProductPicture:EntityBase
    {
        public string Picture { get; private set; }
        public string PictureTitle { get; private set; }
        public string PictureAlt { get; private set; }
        public bool IsDeleted { get; private set; }
        public long ProductId { get; private set; }



        public Product  product { get; private set; }



        protected ProductPicture()
        {

        }

        public ProductPicture(string picture, string pictureTitle, string pictureAlt, long productId)
        {
            Picture = picture;
            PictureTitle = pictureTitle;
            PictureAlt = pictureAlt;
            IsDeleted = false;
            ProductId = productId;
        }

        public void Edit(string picture, string pictureTitle, string pictureAlt, long productId)
        {
            if (!string.IsNullOrWhiteSpace(picture))
            {
                Picture = picture;
            }
            PictureTitle = pictureTitle;
            PictureAlt = pictureAlt;
            ProductId = productId;
        }

        public void Remove()
        {
            IsDeleted = true;
        }
        public void Restore()
        {
            IsDeleted  = false;

        }
    }

   
}
