using _01_framework.Application;
using InventoryManagement.Application.Contracts.Inventory;
using InventoryManagement.Domain.InventoryAgg;

namespace InventoryManagement.Application
{
    public class InventoryApplication : IInventoryApplication
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryApplication(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }


        public OperationResult CreateInventory(CreateInventory command)
        {
            var Operation = new OperationResult();
            if (_inventoryRepository.IsExist(p => p.ProductId == command.ProductId && p.UnitPrice == command.UnitPrice))
                return Operation.Failed(ResultMessage.IsDoblicated);

            var Inventory = new Inventory(command.ProductId, command.UnitPrice);
            _inventoryRepository.Create(Inventory);
            _inventoryRepository.Savechanges();
            return Operation.IsSucssed();

        }

        public OperationResult EditInventory(EditInventory command)
        {
            var Operation = new OperationResult();
            var Inventory = _inventoryRepository.GetBy(command.Id);
            if (Inventory == null)
                return Operation.Failed(ResultMessage.IsNotExistRecord);

            if (_inventoryRepository.IsExist(p => p.ProductId == command.ProductId && p.UnitPrice == command.UnitPrice && p.Id != command.Id))
                return Operation.Failed(ResultMessage.IsDoblicated);
            Inventory.Edit(command.ProductId, command.UnitPrice);
            _inventoryRepository.Savechanges();
            return Operation.IsSucssed();
        }

        public List<InventoryViewModel> GetAll(InventorySearchModel searchModel)
        {
            return _inventoryRepository.GetAll(searchModel);
        }

        public EditInventory GetDetails(long Id)
        {
            return _inventoryRepository.GetDetails(Id);
        }

        public List<InventoryViewModel> GetInventoryLogs(long InventoryId)
        {
            return _inventoryRepository.GetInventoryLogs(InventoryId);
        }

        public OperationResult IncreaseInventory(IncreaseInventory command)
        {
            var Operation = new OperationResult();
            var Inventory = _inventoryRepository.GetBy(command.InventoryId);
            if (Inventory == null)
                return Operation.Failed(ResultMessage.IsNotExistRecord);

            Inventory.IncreaceInventory(command.Count, 0, command.Describtion);
            _inventoryRepository.Savechanges();
            return Operation.IsSucssed();

        }

        public OperationResult ReduceInventory(ReduceInventory command)
        {
            var Operation = new OperationResult();
            var Inventory = _inventoryRepository.GetBy(command.InventoryId);
            return Operation.Failed(ResultMessage.IsNotExistRecord);
            if (Inventory == null)
                return Operation.Failed(ResultMessage.IsNotExistRecord);
            Inventory.ReduceInventory(command.Count, 0, command.Describtion, 0);
            _inventoryRepository.Savechanges();
            return Operation.IsSucssed();

        }

        public OperationResult ReduceInventory(List<ReduceInventory> command)
        {
            var Operation = new OperationResult();

            foreach (var inventory in command)
            {
                var Inventory = _inventoryRepository.GetBy(inventory.InventoryId);
                return Operation.Failed(ResultMessage.IsNotExistRecord);
                if (Inventory == null)
                    return Operation.Failed(ResultMessage.IsNotExistRecord);
                Inventory.ReduceInventory(inventory.Count, 0, inventory.Describtion, inventory.OederId);
                
            }
            _inventoryRepository.Savechanges();
            return Operation.IsSucssed();
        }
    }
}