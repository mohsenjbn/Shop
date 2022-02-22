using _0_Framework.Application;
using _01_framework.Infrastracture;
using InventoryManagement.Application.Contracts.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using ShopManagement.Infrastracture.EfCore;

namespace InventoryManagement.Infrastracture.EfCore.Repository
{
    public class InventoryRepository : RepositoryBase<long, Inventory>, IInventoryRepository
    {
        private readonly InventoryContext _inventoryContext;
        private readonly ShopContext _shopContext;

        public InventoryRepository(InventoryContext inventoryContext,ShopContext shopContext):base(inventoryContext)
        {
            _shopContext = shopContext;
            _inventoryContext = inventoryContext;
        }

        public List<InventoryViewModel> GetAll(InventorySearchModel searchModel)
        {
            var Product = _shopContext.Products.Select(p => new { p.Id, p.Name }).ToList();
            var query = _inventoryContext.Inventory.Select(x => new InventoryViewModel
            {
                CreationDate = x.CreationDate.ToFarsi(),
                CurrentCount=x.CurrentCountInventory(),
                Id = x.Id,
                ProductId= x.ProductId,
                UnitPrice= x.UnitPrice,
            });

            if(searchModel.ProductId > 0)
                query=query.Where(p=>p.ProductId == searchModel.ProductId);

            if (searchModel.Operation)
                query = query.Where(p => p.Operation == searchModel.Operation);

            var Inventory = query.OrderByDescending(p => p.Id).ToList();

            Inventory.ForEach(item=> item.Product=Product.FirstOrDefault(x=>x.Id==item.ProductId)?.Name);
            return Inventory;

        }

        public EditInventory GetDetails(long Id)
        {
            return _inventoryContext.Inventory.Select(p=> new EditInventory
            {
                Id = p.Id,
                ProductId=p.ProductId,
                UnitPrice=p.UnitPrice,
            }).FirstOrDefault(p=>p.Id==Id);
        }

        public List<InventoryOperationViewModel> GetInventoryLogs(long InventoryId)
        {
            var Inventory=_inventoryContext.Inventory.FirstOrDefault(x=>x.Id==InventoryId);
           return Inventory.Operations.Select(p => new InventoryOperationViewModel
            {
                Id = p.Id,
                Count = p.Count,
                OperationDate = p.OperationDate.ToFarsi(),
                CurrentCount = p.CurrentCount,
                Describtion = p.Describtion,
                InventoryId = p.InventoryId,
                Operation = p.Operation,
                OperatorId = p.OperatorId,
                OrderId = p.OrderId,
                Operator = "Admin"
            }).OrderByDescending(p=>p.Id).ToList();
        }
    }
}
