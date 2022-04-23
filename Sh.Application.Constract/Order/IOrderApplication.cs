using ShopManagement.Application.Contracts.Product;

namespace ShopManagement.Application.Contracts.Order
{
    public interface  IOrderApplication
    {
        long PlaceOrder(Cart cart);
        string PaymentSucceeded(long orderId, long refId);
        double GetAmountBy(long orderId);
        List<OrderViewModel> GetAllOrders(OrderSearchModel searchModel);
        List<OrderItems> GetItemsBy(long OrderId);
        void IsCanceled(long Id);
    }
}
