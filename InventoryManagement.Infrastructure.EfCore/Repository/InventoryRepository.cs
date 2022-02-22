using _0_Framework.Application;
using _01_framework.Infrastracture;
using InventoryManagement.Domain.InventoryAgg;
using Invertory.Application.Contracts.Inventory;
using ShopManagement.Infrastracture.EfCore;

namespace InventoryManagement.Infrastructure.EfCore.Repository
{
    public class InventoryRepository : RepositoryBase<long, Inventory>, IInventoryRepository
    {
        private readonly InventoryContext _inventoryContext;
        private readonly ShopContext _shopContext;

        public InventoryRepository(InventoryContext inventoryContext, ShopContext shopContext) : base(inventoryContext)
        {
            _shopContext = shopContext;
            _inventoryContext = inventoryContext;
        }

        public List<InventoryViewModel> GetAll(InventorySeacrModel seacrhmodel)
        {
            var Products = _shopContext.Products.Select(x => new { x.Id, x.Name });
            var query = _inventoryContext.Inventory.Select(x => new InventoryViewModel
            {
                Id = x.Id,
                Instock = x.Instock,
                CurrentCount = x.CurrentCountInventory(),
                ProductId = x.ProductId,
                CreationDate=x.CreationDate.ToFarsi(),
                UnitPrice=x.UnitPrice

            });

            if (seacrhmodel.ProductId > 0)
                query = query.Where(p => p.ProductId == seacrhmodel.ProductId);

            if (seacrhmodel.Instock)
                query = query.Where(p => p.Instock == false);

            var Inventory = query.OrderByDescending(x => x.Id).ToList();

            Inventory.ForEach(p => p.Product = Products.FirstOrDefault(x => x.Id == p.ProductId)?.Name);
            return Inventory;
        }

        public UpdateInventory GetDetails(long id)
        {
            return _inventoryContext.Inventory.Select(p => new UpdateInventory
            {
                Id = id,
                ProductId = p.ProductId,
                UnitPrice = p.UnitPrice,
            }).FirstOrDefault(p => p.Id == id);
        }

        public Inventory Getfrom(long ProductId)
        {
            return _inventoryContext.Inventory.FirstOrDefault(p => p.ProductId == ProductId);
        }

        public List<InventoryOperationViewModel> InventoryOperations(long InventoryId)
        {
            var Inventory=_inventoryContext.Inventory.FirstOrDefault(p=>p.Id == InventoryId);
            return Inventory.Operations.Select(p => new InventoryOperationViewModel
            {
                Id=p.Id,
                Count=p.Count,
                CreationDate=p.CreationDate.ToFarsi(),
                CurrentCount=p.CurrentCount,
                Describtion=p.Describtion,
                InventoryId=p.InventoryId,
                Operation=p.Operation,
                OperatorId=p.OperatorId,
                OrderId=p.OrderId,
               Operator="Admin" 
            }).OrderByDescending(p=>p.Id).ToList();

        }
    }
}
