using Invertory.Application.Contracts.Inventory;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.Services;

namespace ShopManagement.Infarstracture.Acl
{
    public class ShopInventoryAcl:IShopInventoryAcl
    {
        private readonly IInventoryApplication _inventoryApplication;
        public ShopInventoryAcl(IInventoryApplication inventoryApplication)
        {
            _inventoryApplication = inventoryApplication;
        }
        public bool ReduceInventory(List<OrderItem> items)
        {
            var command = new List<Reduce>();
            foreach (var item in items)
            {
                var reduce=new Reduce(item.ProductId,item.Count,"خرید مشتری",item.OrderId);
                command.Add(reduce);
            }

            return _inventoryApplication.Reduce(command).Sucssesed;
        }
    }
}