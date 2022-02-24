using _01_ShopQuery.Contracts.ArticleCategory;
using _01_ShopQuery.Contracts.ProductCategory;

namespace _01_ShopQuery.Contracts
{
    public class Menu
    {
        public List<ArticleCategoryQueryModel> AericaleCatagories { get; set; }
        public List<ProductCategoryQueryModel> ProductCategories { get; set; }
    }
}
