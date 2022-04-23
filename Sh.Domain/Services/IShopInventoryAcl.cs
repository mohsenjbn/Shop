using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.OrderAgg;

namespace ShopManagement.Domain.Services
{
    public interface IShopInventoryAcl
    {
        bool ReduceInventory(List<OrderItem> items);
    }
}
