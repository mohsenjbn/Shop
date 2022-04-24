using InventoryManagement.Infrastructure.EfCore;
using ShopManagement.Infrastracture.EfCore;

namespace _01_ShopQuery.Contracts.Inventory
{
    public interface IInventoryQuery
    {
        StockStatus IsInStock(CheckStatus command);
    }

    public class InventoryQuery : IInventoryQuery
    {
        private readonly InventoryContext _inventoryContext;
        private readonly ShopContext _shopContext;

        public InventoryQuery(InventoryContext inventoryContext,ShopContext shopContext)
        {
            _shopContext=shopContext;
            _inventoryContext = inventoryContext;
        }

        public StockStatus IsInStock(CheckStatus command)
        {
            var Inventory = _inventoryContext.Inventory.FirstOrDefault(p => p.ProductId == command.ProductId);
            if (Inventory == null || Inventory.CurrentCountInventory() < command.Count)
            {
                var Product = _shopContext.Products.Select(p => new { p.Id, p.Name })
                    .FirstOrDefault(p => p.Id == command.ProductId).Name;
                return new StockStatus
                {
                    IsStock = false,
                    ProductName = Product
                };
            }

            return new StockStatus
            {
                IsStock = true
            };
        }
    }

    public class CheckStatus 
    {
        public long ProductId { get; set; }
        public int Count { get; set; }
    }

    public class StockStatus
    {
        public bool IsStock { get; set; }
        public string ProductName { get; set; }
    }
}
