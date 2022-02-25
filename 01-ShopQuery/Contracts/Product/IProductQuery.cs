namespace _01_ShopQuery.Contracts.Product
{
    public interface IProductQuery
    {
        List<ProductQueryViewModel> Search(string val);
        ProductQueryViewModel GetProducutBy(string slug);
        List<ProductQueryViewModel> LatestArrivals();

    }
}
