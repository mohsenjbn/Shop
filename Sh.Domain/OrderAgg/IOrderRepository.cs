using _01_framework.Domain;
using ShopManagement.Application.Contracts.Order;

namespace ShopManagement.Domain.OrderAgg
{
    public interface  IOrderRepository:IRepository<long,Order>
    {
        double GetAmountBy(long orderId);
        List<OrderViewModel> GetAllOrders(OrderSearchModel searchModel);
        List<OrderItems> GetItemsBy(long OrderId);


    }
}
