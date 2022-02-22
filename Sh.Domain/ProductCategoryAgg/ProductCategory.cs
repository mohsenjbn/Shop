

using _01_framework.Domain;
using ShopManagement.Domain.ProductAgg;

namespace Sh.Domain.ProductCategoryAgg
{
    public class ProductCategory:EntityBase
    {
        public string Name { get;private set; }
        public string Picture { get; private set; }
        public string Describtion { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string KeyWords { get; private set; }
        public string MetaDescribtion { get; private set; }
        public string Slug { get; private set; }

        public List<Product> Products { get; private set; }

        protected ProductCategory()
        {
                
        }

        public ProductCategory(string name,string picture,string describtion,string pictureAlt,
            string picturetitle,string slug,string keywords,string metadescribtion)
        {
            Name = name;
            PictureAlt = pictureAlt;
            PictureTitle=picturetitle;
            Picture=picture;
            Describtion = describtion;
            Slug=slug;
            MetaDescribtion=metadescribtion;
            KeyWords=keywords;
        }

        public void Edit(string name, string picture, string describtion, string pictureAlt,
            string picturetitle, string slug, string keywords, string metadescribtion)
        {
            Name = name;
            PictureAlt = pictureAlt;
            PictureTitle = picturetitle;
            if(!string.IsNullOrWhiteSpace(picture))
            {
                Picture = picture;
            }

            Describtion = describtion;
            Slug = slug;
            MetaDescribtion = metadescribtion;
            KeyWords = keywords;
        }
    }
}
