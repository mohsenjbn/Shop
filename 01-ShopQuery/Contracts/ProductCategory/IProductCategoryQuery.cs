using _01_ShopQuery.Contracts.Product;

namespace _01_ShopQuery.Contracts.ProductCategory
{
    public interface IProductCategoryQuery
    {
        List<ProductCategoryQueryModel> GetCategoriesWhitProductForMenu();
        List<ProductCategoryQueryModel> GetAllCategories();
        List<ProductCategoryQueryModel> GetAllCategoryWithProducts();
        ProductCategoryQueryModel GetProductCategoryandProductsBy(string value);


    }
}
