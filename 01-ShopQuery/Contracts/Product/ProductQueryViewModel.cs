using _01_ShopQuery.Contracts.ProductCategory;

namespace _01_ShopQuery.Contracts.Product
{
    public class ProductQueryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Code { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string UnitPrice { get; set; }
        public string PriceWithDiscoint { get; set; }
        public int DiscountRate { get; set; }
        public string Slug { get; set; }
        public bool Discount { get; set; }
        public string Category { get; set; }
        public string EndDateDiscount { get; set; }
        public bool IsInStock { get; set; }
        public string Describtion { get; set; }
        public string ShortDescribtion { get; set; }
        public string KeyWords { get; set; }
        public string MetaDescribtion { get; set; }
        public long ProductCategoryId { get; set; }
        public string ProductCategorySlug{ get; set; }
        public List<ProducPictureQueryModel> ProducPictures { get; set; }


    }

    public class ProducPictureQueryModel
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string Picture { get; set; }
        public string picturetitle { get; set; }
        public string pictureAlt { get; set; }
        public bool IsRemove { get; set; }
    }
}
