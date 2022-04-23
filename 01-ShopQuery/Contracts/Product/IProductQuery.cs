using ShopManagement.Application.Contracts.Product;

namespace _01_ShopQuery.Contracts.Product
{
    public interface IProductQuery
    {
        List<ProductQueryViewModel> Search(string val);
        ProductQueryViewModel GetProducutBy(string slug);
        List<ProductQueryViewModel> LatestArrivals();
        List<CartItem> CheckInStock (List<CartItem> cartItems);

    }
}
