namespace _01_ShopQuery.Contracts.Product
{
    public interface IProductQuery
    {
        ProductQueryViewModel GetProducutBy(string slug);
        List<ProductQueryViewModel> LatestArrivals();

    }
}
