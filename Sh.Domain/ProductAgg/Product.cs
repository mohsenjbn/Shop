
using _01_framework.Domain;
using Sh.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Domain.ProductAgg
{
    public class Product:EntityBase
    {
        
        public string Name { get; private set; }
        public string Code { get; private set; }
        public string ShortDescribtion { get; private set; }
        public string Describtion { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string MetaDescribtion { get;private set; }
        public string keyWords { get; private set; }
        public string Slug { get; private set; }
        public long ProductCatagoryId { get; private set; }

        public ProductCategory ProductCategory { get; set; }
        public List<ProductPicture> ProductPictures { get; private set; }

        protected Product()
        {
        }

        public Product(string name, string code, 
            string shortDescribtion, string describtion, string picture,
            string pictureAlt, string pictureTitle, string metaDescribtion, 
            string keyWords, string slug, long productCatagoryId)
        {
            Name = name;
            Code = code;
            ShortDescribtion = shortDescribtion;
            Describtion = describtion;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            MetaDescribtion = metaDescribtion;
            this.keyWords = keyWords;
            Slug = slug;
            ProductCatagoryId = productCatagoryId;
        }

    

        public void Edit(string name, string code, 
            string shortDescribtion, string describtion, string picture,
            string pictureAlt, string pictureTitle, string metaDescribtion,
            string keyWords, string slug, long productCatagoryId)
        {
            Name = name;
            Code = code;
            ShortDescribtion = shortDescribtion;
            Describtion = describtion;
            if (!string.IsNullOrWhiteSpace(picture))
            {
                Picture = picture;
            }
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            MetaDescribtion = metaDescribtion;
            this.keyWords = keyWords;
            Slug = slug;
            ProductCatagoryId = productCatagoryId;
        }

      
    }
}
